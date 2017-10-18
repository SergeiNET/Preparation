using System;
using System.Collections;
using System.Text;

namespace Preparation.Utils
{
    public static class EnumerableExtensions
    {
        public static void Print(this IEnumerable enumerable) 
        {
            StringBuilder sb = new StringBuilder();
            foreach(var v in enumerable) 
            {
                sb.Append(v.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
