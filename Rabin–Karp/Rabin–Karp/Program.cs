using System;
using System.Collections.Generic;

namespace Rabin_Karp
{
    class Program
    {
        static void Main(string[] args)
        {
			string str = "abababa";
			string sub_str = "abab";
			int[] index = SearchString(str, sub_str);

			foreach(var item in index)
            {
				Console.WriteLine("Вхождение подстроки на " + (item + 1));
            }

		}
		public static int[] SearchString(string base_line, string sub_line)
		{
			List<int> retVal = new List<int>();
			ulong sigBase = 0;
			ulong sigSub = 0;
			ulong Q = 100007;//Довольно большое простое число
			ulong D = 10;
			int counter = 0;
			for (int i = 0; i < sub_line.Length; ++i)
			{
				sigBase = (sigBase * D + (ulong)base_line[i]) % Q;
				sigSub = (sigSub * D + (ulong)sub_line[i]) % Q;
			}

			if (sigBase == sigSub)
            {
				retVal.Add(0);
				counter++;
            }

			ulong pow = 1;

			for (int k = 1; k <= sub_line.Length - 1; ++k)
				pow = (pow * D) % Q;

			for (int j = 1; j <= base_line.Length - sub_line.Length; ++j)
			{
				sigBase = (sigBase + Q - pow * (ulong)base_line[j - 1] % Q) % Q;
				sigBase = (sigBase * D + (ulong)base_line[j + sub_line.Length - 1]) % Q;

				if (sigBase == sigSub)
					if (base_line.Substring(j, sub_line.Length) == sub_line)
						retVal.Add(j);
				counter++;
			}
			Console.WriteLine(counter + " количество проверок");
			return retVal.ToArray();
		}
	}
}
