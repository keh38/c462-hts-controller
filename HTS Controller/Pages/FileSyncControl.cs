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
using KLib;

namespace HTSController.Pages
{
    public partial class FileSyncControl : UserControl
    {
        private HTSNetwork _network;

        private SynchronizationContext _synchronizationContext;
        private CancellationTokenSource _cts;

        private List<string> _remoteFiles;

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
            _network.SendMessage("ChangeScene:Admin Tools");
            _network.RemoteMessageHandler += OnRemoteMessage;

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
            var localFiles = EnumerateResources();

            AppendLogText("Enumerating remote resources");
            await GetRemoteResourceList();

            var toDelete = EnumerateUnusedRemoteFiles(_remoteFiles, localFiles);
            if (toDelete.Count > 0)
            {
                AppendLogText($"Deleting {toDelete.Count} remote files");
                progressBar.Visible = true;
                progressBarLabel.Visible = true;
                progressBar.Maximum = toDelete.Count;
                progressBar.Value = 0;
                foreach (var remoteFile in toDelete)
                {
                    progressBar.Value++;
                    progressBarLabel.Text = remoteFile;
                    _network.SendMessage($"DeleteFile:{remoteFile}");
                }
            }

            AppendLogText($"Syncing files");
            progressBar.Visible = true;
            progressBarLabel.Visible = true;
            progressBar.Maximum = localFiles.Count;
            progressBar.Value = 0;
            int numUploaded = 0;
            foreach (var file in localFiles)
            {
                string fullLocalPath = Path.Combine(FileLocations.ResourcesFolder, file);

                progressBar.Value++;
                progressBarLabel.Text = file;
                var result = _network.SendMessageAndReceiveString($"FileExists:{file}");
                bool upload = false;
                if (result.Equals("404"))
                {
                    upload = true;
                }
                else
                {
                    DateTime remoteTime = KFile.JSONDeserializeFromString<DateTime>(result);
                    DateTime localTime = File.GetLastWriteTime(fullLocalPath);
                    upload = (localTime > remoteTime);
                    //Debug.WriteLine($"{upload} {localTime} {remoteTime} {file}");
                }

                if (upload)
                {
                    var success = await _network.SendBufferedFile(fullLocalPath, file);
                    if (success)
                    {
                        numUploaded++;
                    }
                    else
                    {
                        AppendLogText($"error uploading {file}");
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
                string remotePath = Path.Combine("Downloads", Path.GetFileName(fileBrowser.Value));
                var success = await _network.SendBufferedFile(fileBrowser.Value, remotePath);
                if (success)
                {
                    _network.SendMessage($"RunInstaller:{Path.GetFileName(fileBrowser.Value)}");
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

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 3);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals("FileSync")) return;

            string command = parts[1];
            string data = (parts.Length > 2) ? parts[2] : "";

            switch (command)
            {
                case "ReceiveFileList":
                    _remoteFiles = KFile.JSONDeserializeFromString<List<string>>(data);
                    break;
            }
        }

        private List<string> EnumerateResources()
        {
            var resourceFolders = new List<string>()
            {
                "Config Files",
                "Images",
                "MATLAB",
                "Plugins",
                "Protocols",
                "Schedules",
                "Videos",
                "Wav Files"
            };

            List<string> resources = new List<string>();

            foreach (var resourceFolder in resourceFolders) 
            {
                string folder = Path.Combine(FileLocations.ResourcesFolder, resourceFolder);
                var files = Directory.GetFiles(folder);
                foreach (var file in files) 
                {
                    resources.Add(file.Remove(0, FileLocations.ResourcesFolder.Length+1));
                }
            }

            return resources;
        }

        private async Task GetRemoteResourceList()
        {
            _remoteFiles = null;
            _network.SendMessage("SendResourceList");

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                if (_remoteFiles != null)
                {
                    return;
                }
                await Task.Delay(100);
            }

            throw new Exception("timed out waiting for remote resource list");
        }

        private List<string> EnumerateUnusedRemoteFiles(List<string> remoteFiles, List<string> localFiles)
        {
            List<string> toDelete = new List<string>();
            foreach (var remoteFile in remoteFiles)
            {
                if (!localFiles.Contains(remoteFile))
                {
                    toDelete.Add(remoteFile);
                }
            }
            return toDelete;
        }
    }
}
