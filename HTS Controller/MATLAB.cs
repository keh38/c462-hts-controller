using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathWorks.MATLAB.Engine;
using MathWorks.MATLAB.Types;

using Serilog;

namespace HTSController
{
    public static class MATLAB
    {
        private static dynamic _engine;

        public static bool IsInitialized { get; private set; }

        public async static Task<bool> Initialize()
        {
            IsInitialized = false;
            try
            {
                _engine = await MATLABEngine.StartMATLABAsync();
                IsInitialized = true;
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
                    MATLABEngine.TerminateEngineClient();
                }
                catch { }
            }
        }

        public static double RunFunction(string functionName, string dataFilePath)
        {
            double result = double.NaN;

            if (IsInitialized)
            {
                result = _engine.eval($"{functionName}('{dataFilePath}')");
            }

            return result;
        }

    }
}
