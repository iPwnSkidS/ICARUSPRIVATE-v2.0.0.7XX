using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class Filemanager
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<FileInfo, long> __9__2_0;

            public static Func<DirectoryInfo, long> __9__2_1;

            internal long _DirectorySize_b__2_0(FileInfo fi)
            {
                return fi.Length;
            }

            internal long _DirectorySize_b__2_1(DirectoryInfo di)
            {
                return DirectorySize(di.FullName);
            }
        }

        public static void RecursiveDelete(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo directoryInfo2 in directories)
                {
                    RecursiveDelete(directoryInfo2.FullName);
                }
                directoryInfo.Delete(recursive: true);
            }
        }

        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            string[] files = Directory.GetFiles(sourceFolder);
            string[] array = files;
            foreach (string text in array)
            {
                string fileName = Path.GetFileName(text);
                string destFileName = Path.Combine(destFolder, fileName);
                File.Copy(text, destFileName);
            }
            string[] directories = Directory.GetDirectories(sourceFolder);
            string[] array2 = directories;
            foreach (string text2 in array2)
            {
                string fileName2 = Path.GetFileName(text2);
                string destFolder2 = Path.Combine(destFolder, fileName2);
                CopyDirectory(text2, destFolder2);
            }
        }

        public static long DirectorySize(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Sum(__c.__9__2_0 ?? (__c.__9__2_0 = __c.__9._DirectorySize_b__2_0)) + directoryInfo.GetDirectories().Sum(__c.__9__2_1 ?? (__c.__9__2_1 = __c.__9._DirectorySize_b__2_1));
        }
    }
}
