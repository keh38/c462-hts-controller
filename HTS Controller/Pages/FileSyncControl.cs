using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using Serilog;
using KLib.IO;
using KLib.Net;

using HTS.Tcp;
using Newtonsoft.Json;
using C462.Shared;
using C462.Shared.Protocol.DTOs;
using C462.Shared.ProjectManagement;

namespace HTSController.Pages
{
    public partial class FileSyncControl : UserControl
    {
        private HTSNetwork _network;

        private SynchronizationContext _synchronizationContext;
        private CancellationTokenSource _cts;

        private List<ResourceItem> _remoteResources;

        public FileSyncControl()
        {
            InitializeComponent();

            fileBrowser.Visible = false;
            progressBar.Visible = false;
            progressBarLabel.Visible = false;
            logBox.Visible = false;

            startButton.Enabled = false;
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;

            var updatePath = HTSControllerSettings.GetLastUsed("Update");
            if (updatePath != null)
            {
                fileBrowser.DefaultFolder = Path.GetDirectoryName(updatePath);
            }
        }

        private void syncOptionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = syncOptionDropDown.SelectedItem.ToString();
            fileBrowser.Visible = option.Equals("Update");
            startButton.Enabled = !option.Equals("Update") || !string.IsNullOrEmpty(fileBrowser.Value);
        }

        private void fileBrowser_ValueChanged(object sender, EventArgs e)
        {
            startButton.Enabled = !string.IsNullOrEmpty(fileBrowser.Value);
            if (!string.IsNullOrEmpty(fileBrowser.Value))
            {
                HTSControllerSettings.SetLastUsed("Update", fileBrowser.Value);
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("ChangeScene", "Admin Tools");

            cancelButton.Enabled = true;
            startButton.Visible = false;

            _cts = new CancellationTokenSource();

            string syncWhich = syncOptionDropDown.SelectedItem.ToString();

            try
            {
                logBox.Visible = true;
                if (syncWhich.Equals("Resources"))
                {
                    await SyncResources(_cts);
                }
                else if (syncWhich.Equals("Update"))
                {
                    await UpdateApp(_cts);
                }
            }
            catch (OperationCanceledException ex)
            {
                Log.Information($"{syncWhich} sync canceled");
                AppendLogText("Canceled.");
            }
            catch (Exception ex)
            {
                Log.Error($"{syncWhich} sync stopped with error: {ex.Message}");
                AppendLogText($"Error: {ex.Message}");
            }
            finally
            {
                _cts.Dispose();
            }

            startButton.Visible = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                cancelButton.Enabled = false;
            }
        }

        private async Task SyncResources(CancellationTokenSource cts)
        {
            _network.SendMessage("StartResourceSync");

            Log.Information("Syncing resources");
            AppendLogText("Syncing resources");

            AppendLogText("Enumerating local resources");
            var localResources = EnumerateLocalResources();

            AppendLogText("Enumerating remote resources");
            var payload = _network.SendRequest<ResourceListPayload>("SendResourceList");
            if (payload == null)
            {
                Log.Error("Failed to get remote resource list");
                AppendLogText("Failed to get remote resource list");
                return;
            }

            _remoteResources = payload.Resources;

            var toDelete = EnumerateUnusedRemoteResources(_remoteResources, localResources);
            if (toDelete.Count > 0)
            {
                AppendLogText($"Deleting {toDelete.Count} remote files");
                progressBar.Visible = true;
                progressBarLabel.Visible = true;
                progressBar.Maximum = toDelete.Count;
                progressBar.Value = 0;
                foreach (var remoteItem in toDelete)
                {
                    progressBar.Value++;
                    progressBarLabel.Text = remoteItem.Name;
                    var fileInfoPayload = new FileInfoPayload()
                    {
                        Destination = FileDestination.ProjectResources,
                        SubPath = remoteItem.Type,
                        Filename = remoteItem.Name
                    };
                    _network.SendMessage("DeleteFile", fileInfoPayload);
                }
            }

            AppendLogText($"Syncing files");
            progressBar.Visible = true;
            progressBarLabel.Visible = true;
            progressBar.Maximum = localResources.Count;
            progressBar.Value = 0;
            int numUploaded = 0;
            foreach (var localItem in localResources)
            {
                var fileInfoPayload = new FileInfoPayload()
                {
                    Destination = FileDestination.ProjectResources,
                    SubPath = localItem.Type,
                    Filename = localItem.Name
                };
                string fullLocalPath = Path.Combine(SharedFileLocations.HtsResourcesFolder, localItem.Type, localItem.Name);

                progressBar.Value++;
                progressBarLabel.Text = localItem.Name;

                bool upload = false;
                try
                {
                    var response = _network.SendRequest<FileInfoPayload>("FileExists", fileInfoPayload);
                    if (response == null)
                    {
                        upload = true;
                    }
                    else
                    {
                        DateTime localTime = File.GetLastWriteTime(fullLocalPath);
                        upload = (localTime > response.LastModified);
                    }
                }
                catch
                {
                    upload = true;
                }

                if (upload)
                {
                    var success = await _network.SendBufferedFile(fullLocalPath, localItem.Name, FileDestination.ProjectResources, localItem.Type);
                    if (success)
                    {
                        numUploaded++;
                    }
                    else
                    {
                        AppendLogText($"error uploading {localItem.Name}");
                    }
                }
            }
            AppendLogText($"Updated {numUploaded} files");

            Log.Information("Resource sync finished");
            AppendLogText("Finished");
        }

        private async Task UpdateApp(CancellationTokenSource cancellationToken)
        {
            _network.SendMessage("StartResourceSync");

            Log.Information("Sending installer to tablet app");
            AppendLogText("Sending installer to tablet");

            if (File.Exists(fileBrowser.Value))
            {
                var success = await _network.SendBufferedFile(fileBrowser.Value, Path.GetFileName(fileBrowser.Value), FileDestination.Downloads);
                if (success)
                {
                    _network.SendMessage("RunInstaller", Path.GetFileName(fileBrowser.Value));
                }
                Log.Information("Update app finished");
                AppendLogText("Finished");
            }
            else
            {
                Log.Information("Update installer does not exist");
                AppendLogText("Update installer does not exist");
            }
        }

        private void AppendLogText(string message)
        {
            logBox.AppendText($"{message}{Environment.NewLine}");
        }

        private List<ResourceItem> EnumerateLocalResources()
        {
           var resources = new List<ResourceItem>();

            foreach (var resourceFolder in SharedFileLocations.HtsProjectResourceFolders)
            {
                string folder = Path.Combine(SharedFileLocations.HtsResourcesFolder, resourceFolder);
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    resources.Add(
                        new ResourceItem() 
                        { 
                            Name = Path.GetFileName(file), 
                            Type = resourceFolder
                        });
                }
            }

            return resources;
        }

        private List<ResourceItem> EnumerateUnusedRemoteResources(List<ResourceItem> remoteItems, List<ResourceItem> localItems)
        {
            var toDelete = new List<ResourceItem>();
            foreach (var remoteItem in remoteItems)
            {
                if (localItems.Find(item => item.IsEqual(remoteItem)) == null)
                {
                    toDelete.Add(remoteItem);
                }
            }
            return toDelete;
        }
    }
}
