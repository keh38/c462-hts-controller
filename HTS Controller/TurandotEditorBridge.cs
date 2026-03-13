using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using Serilog;

using KLib.Net;
using HTS.Tcp;

namespace HTSController
{
    public static class TurandotEditorBridge
    {
        public const int Port = 40002;

        private const string RegistryKeyName = @"SOFTWARE\EPL\C462\Turandot Editor";
        private const string RegistryValue = "InstallPath";

        private static readonly IPEndPoint EndPoint =
            new IPEndPoint(IPAddress.Loopback, Port);

        public static bool IsInstalled => GetExecutableFolder() != null;

        public static bool IsRunning =>
            Process.GetProcessesByName("Turandot Editor").Any();

        public static bool Launch()
        {
            var exeFolder = GetExecutableFolder();
            if (exeFolder == null)
            {
                Log.Warning("TurandotEditor not found in registry");
                return false;
            }

            string exePath = Path.Combine(exeFolder, "Turandot Editor.exe");   
            if (exePath == null)
            {
                Log.Warning("Turandot Editor .exe not found");
                return false;
            }
            var processStartInfo = new ProcessStartInfo(exePath);
            processStartInfo.WorkingDirectory = exeFolder;
            Process.Start(processStartInfo);
            return true;
        }

        public static bool WaitUntilReady(int timeoutMs = 3000, int pollIntervalMs = 200)
        {
            var deadline = Stopwatch.StartNew();
            while (deadline.ElapsedMilliseconds < timeoutMs)
            {
                if (KTcpClient.SendRequest(EndPoint, TcpMessage.Request("Ping")).IsOk)
                    return true;
                Thread.Sleep(pollIntervalMs);
            }
            Log.Warning($"TurandotEditor did not respond within {timeoutMs} ms");
            return false;
        }

        public static void OpenFile(string filePath) =>
            KTcpClient.SendRequest(EndPoint, TcpMessage.Request("OpenFile", (object) filePath));

        public static void SetHtsEndpoint(IPEndPoint htsEndPoint) =>
           KTcpClient.SendRequest(EndPoint, TcpMessage.Request("SetHtsEndpoint",
               htsEndPoint != null
                   ? new HtsEndpointPayload { Address = htsEndPoint.Address.ToString(), Port = htsEndPoint.Port }
                   : new HtsEndpointPayload()));

        private static string GetExecutableFolder()
        {
#if DEBUGxxx
            string editorFolder = @"D:\Development\C462\c462-turandot-editor\Turandot Editor\bin\x64\Debug";
            if (Directory.Exists(editorFolder))
            {
                return editorFolder;
            }
            return "C" + editorFolder.Substring(1);

#else
                using (var view64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (var subKey = view64.OpenSubKey(RegistryKeyName, false))
                    {
                        return subKey?.GetValue(RegistryValue) as string;
                    }
                }
                //using (var key = Registry.LocalMachine.OpenSubKey(RegistryKey))
                //{
                //    return key?.GetValue(RegistryValue) as string;
                //}
#endif
            }
    }
}
