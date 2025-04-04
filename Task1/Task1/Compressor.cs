using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public static class Compressor
    {
        public static string CompressText(string txt)
        {
            char[] arr = txt.ToCharArray();

            string res = String.Join("",arr.GroupBy(g => g).Select(i => i.First() + (i.Count() != 1 ? i.Count().ToString() : "")));

            return res;
        }
    }
}
