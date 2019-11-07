using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberprojektVincentLönnbroTE17C
{
    class Program
    {
        static void Main(string[] args)
        {
            SpelPlan map1 = new SpelPlan();
            //Console.WriteLine(map1.spelplan);


            List<string> test = new List<string>();

            Dictionary<int, Dictionary<int, string>> testDic = new Dictionary<int, Dictionary<int, string>>();

            //testDic.Add(0, "   A B C D E F G H I J");

            Dictionary<int, string> dic = new Dictionary<int, string>();

            for (int i = 0; i < 10; i++)
            {
                dic.Add(i + 1, " o");
            }
           
            Console.Read();

            for (int i = 0; i < 10; i++)
            {
                testDic.Add(i, dic);

            }
            for (int i = 0; i < testDic.Count; i++)
            {
                string s = (i + 1).ToString();
                
                for (int j = 0; j < testDic[i].Count; j++)
                {
                    s += dic[i + 1];
                }
            }


            Console.ReadKey();
        }
    }
}
