using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberprojektVincentLönnbroTE17C
{
    /*          ANTECKNINGAR / TODO LIST
     * 
     *      5 skepp, 2, 2, 3, 3, 4 långa respektive 
     *      Skepp har # som ikon
     *      Man ska kunna placera dessa skepp, dessa skepp ska inte kunna placeras på varandra eller utanför spelplanen. 
     *      Placera ett skepp i taget, storleksordning minsta först. Uppdatera spelplanen efter ett skepp har placerats ut. 
     *      
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */


    class Program
    {

        Skepp skepp = new Skepp();


        static int size = 12;

        public string y = "";
        static void Main(string[] args)
        {
            SpelPlan map1 = new SpelPlan();
            //Console.WriteLine(map1.spelplan);

            List<string> test = new List<string>();



            Dictionary<int, Dictionary<int, string>> testDic = new Dictionary<int, Dictionary<int, string>>();

            //testDic.Add(0, "   A B C D E F G H I J");

            Dictionary<int, string> dic = new Dictionary<int, string>();

            Dictionary<int, string> dicO = new Dictionary<int, string>();


            Dictionary<int, Dictionary<int, int>> cords = new Dictionary<int, Dictionary<int, int>>();

            ShipPutter(testDic, dicO = DefaultMap(dicO), cords = AddCords(cords), dic);

            test2(testDic);
            //TestTest(dic, testDic);

            Console.ReadKey();

        }

        static Dictionary<int, int> AddCords(Dictionary<int, Dictionary<int, int>> cords, int skäppLängd)
        {
            Console.WriteLine("Skriv in kordinater för ditt skepp, börja med z, sen y.");

            Dictionary<int, int> cords1 = new Dictionary<int, int>();

            Console.WriteLine("X = ");

            int xC = int.Parse(Console.ReadLine());
            Console.WriteLine("Y = ");
            int yC = int.Parse(Console.ReadLine());


            Console.WriteLine("Vilket håll är båten riktad?");
            var dir = Console.ReadKey();

            if (dir.Key == ConsoleKey.UpArrow)
            {
                for (int i = 0; i < length; i++)
                {

                }
                cords.Add(xC, yC - 1);
            }

            return cords;
        }

        static Dictionary<int, string> DefaultMap(Dictionary<int, string> defDic)
        {
            for (int j = 0; j < size; j++)
            {
                defDic.Add(j + 1, " o");
            }

            return defDic;
        }

        static Dictionary<int, Dictionary<int, string>> ShipPutter(Dictionary<int, Dictionary<int, string>> fullDic, Dictionary<int, string> dicO, Dictionary<int, Dictionary<int, int>> cords, Dictionary<int, string> dic)
        {
            for (int i = 0; i < dicO.Count; i++)
            {

                for (int j = 0; j < dicO.Count; j++)
                {
                    if (cords.ContainsKey(j + 1))
                    {
                        dic[j + 1] = Skepp.Skepp1;
                    }
                    else
                    {
                        dic[j + 1] = " o";
                    }

                }
                if (cords.ContainsValue(i + 1))
                {
                    fullDic[i] = dic;
                }
                else
                {
                    fullDic[i] = dicO;
                }

            }

            return fullDic;
        }

        static void test2(Dictionary<int, Dictionary<int, string>> testDic)
        {
            string s = "";
            for (int i = 0; i < testDic.Count; i++)
            {
                s = "";
                for (int a = 0; a < testDic.Count; a++)
                {
                    s += testDic[i][a + 1];
                }
                Console.WriteLine(s);
            }

        }

    }
}
