using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ShitarusPrivate.Kavod.Vba.Compression;

namespace ShitarusPrivate.Icarus
{
    internal class Utils
    {
        public class ModuleInformation
        {
            public string moduleName;

            public uint textOffset;
        }

        public static Dictionary<string, string> ParseArgs(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i].Substring(1).ToLower() == "l")
                    {
                        dictionary.Add(args[i].Substring(1).ToLower(), "true");
                    }
                    else
                    {
                        dictionary.Add(args[i].Substring(1).ToLower(), args[i + 1]);
                    }
                }
            }
            return dictionary;
        }

        public static List<ModuleInformation> ParseModulesFromDirStream(byte[] dirStream)
        {
            List<ModuleInformation> list = new List<ModuleInformation>();
            int num = 0;
            ModuleInformation moduleInformation = new ModuleInformation
            {
                moduleName = "",
                textOffset = 0u
            };
            while (num < dirStream.Length)
            {
                ushort word = GetWord(dirStream, num);
                uint num2 = GetDoubleWord(dirStream, num + 2);
                switch (word)
                {
                    case 9:
                        num2 = 6u;
                        break;
                    case 3:
                        num2 = 2u;
                        break;
                }
                switch (word)
                {
                    case 49:
                        moduleInformation.textOffset = GetDoubleWord(dirStream, num + 6);
                        list.Add(moduleInformation);
                        moduleInformation = new ModuleInformation
                        {
                            moduleName = "",
                            textOffset = 0u
                        };
                        break;
                    case 26:
                        moduleInformation.moduleName = Encoding.UTF8.GetString(dirStream, num + 6, (int)num2);
                        break;
                }
                num += 6;
                num += (int)num2;
            }
            return list;
        }

        public static ushort GetWord(byte[] buffer, int offset)
        {
            byte[] array = new byte[2];
            Array.Copy(buffer, offset, array, 0, 2);
            return BitConverter.ToUInt16(array, 0);
        }

        public static uint GetDoubleWord(byte[] buffer, int offset)
        {
            byte[] array = new byte[4];
            Array.Copy(buffer, offset, array, 0, 4);
            return BitConverter.ToUInt32(array, 0);
        }

        public static byte[] Compress(byte[] data)
        {
            DecompressedBuffer buffer = new DecompressedBuffer(data);
            CompressedContainer compressedContainer = new CompressedContainer(buffer);
            return compressedContainer.SerializeData();
        }

        public static byte[] Decompress(byte[] data)
        {
            CompressedContainer container = new CompressedContainer(data);
            DecompressedBuffer decompressedBuffer = new DecompressedBuffer(container);
            return decompressedBuffer.Data;
        }

        public static string GetVBATextFromModuleStream(byte[] moduleStream, uint textOffset)
        {
            return Encoding.UTF8.GetString(Decompress(moduleStream.Skip((int)textOffset).ToArray()));
        }

        public static byte[] RemovePcodeInModuleStream(byte[] moduleStream, uint textOffset, string OG_VBACode)
        {
            return Compress(Encoding.UTF8.GetBytes(OG_VBACode)).ToArray();
        }

        public static string GetOutFilename(string filename)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string extension = Path.GetExtension(filename);
            string directoryName = Path.GetDirectoryName(filename);
            return Path.Combine(directoryName, fileNameWithoutExtension + extension);
        }

        public static byte[] HexToByte(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] array = new byte[hex.Length / 2];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return array;
        }

        public static byte[] ChangeOffset(byte[] dirStream)
        {
            int num = 0;
            string s = "\0\0\0\0";
            while (num < dirStream.Length)
            {
                ushort word = GetWord(dirStream, num);
                uint num2 = GetDoubleWord(dirStream, num + 2);
                switch (word)
                {
                    case 9:
                        num2 = 6u;
                        break;
                    case 3:
                        num2 = 2u;
                        break;
                }
                if (word == 49)
                {
                    GetDoubleWord(dirStream, num + 6);
                    UTF8Encoding uTF8Encoding = new UTF8Encoding();
                    uTF8Encoding.GetBytes(s, 0, (int)num2, dirStream, num + 6);
                }
                num += 6;
                num += (int)num2;
            }
            return dirStream;
        }
    }
}
