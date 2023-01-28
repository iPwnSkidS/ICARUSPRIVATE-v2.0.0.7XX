using System;
using System.Threading;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class StartDelay
    {
        private const int SleepMin = 0;

        private const int SleepMax = 10;

        public static void Run()
        {
            int millisecondsTimeout = new Random().Next(0, 10000);
            Logging.Log();
            Thread.Sleep(millisecondsTimeout);
        }
    }
}
