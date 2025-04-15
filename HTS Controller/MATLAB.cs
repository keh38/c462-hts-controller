using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using MathWorks.MATLAB.Engine;
//using MathWorks.MATLAB.Types;

using Serilog;

namespace HTSController
{
    public static class MATLAB
    {
        private static dynamic _engine;

        //public delegate void UpdateMetricsDelegate(MATLABStruct data);
        //public static UpdateMetricsDelegate UpdateMetrics;
        //private static void OnUpdateMetrics(MATLABStruct data) { UpdateMetrics?.Invoke(data); }

        public static bool IsInitialized { get; private set; }

        public async static Task<bool> Initialize()
        {
            IsInitialized = false;
            try
            {
                //_engine = await MATLABEngine.StartMATLABAsync();
                IsInitialized = false;
            }
            catch (Exception ex)
            {
                Log.Warning($"Could not start MATLAB engine: {ex.Message}");
            }

            return IsInitialized;
        }

        public static void CleanUp()
        {
            if (IsInitialized)
            {
                try
                {
                    //MATLABEngine.TerminateEngineClient();
                }
                catch { }
            }
        }

        public static string RunFunction(string functionName, string dataFilePath)
        {
            string result = "";

            if (IsInitialized)
            {
                try
                {
                    //MATLABStruct data = _engine.eval($"{functionName}('{dataFilePath}')");
                    //foreach (var n in data.GetFieldNames())
                    //{
                    //    string value = "";
                    //    dynamic x = data.GetField(n);
                    //    try { value = x; } catch { double dval = x; value = dval.ToString(); }
                    //    result += $"{n} = {value}" + Environment.NewLine;

                    //    OnUpdateMetrics(data);
                    //}
                }
                catch (Exception ex)
                {
                    result = "Error evaluating MATLAB function";
                    Log.Error($"Error evaluating MATLAB function '{functionName}'");
                }

            }

            return result;
        }

    }
}
