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
        public static List<int> xCord = new List<int>();
        public static List<int> yCord = new List<int>();

        static int size = 12;

        public string y = "";
        static void Main(string[] args)
        {
            SpelPlan map1 = new SpelPlan();
            //Console.WriteLine(map1.spelplan);

            List<string> test = new List<string>();

            Dictionary<int, Dictionary<int, string>> testDic = new Dictionary<int, Dictionary<int, string>>();

            Dictionary<int, string> dic = new Dictionary<int, string>();

            Dictionary<int, string> dicO = new Dictionary<int, string>();

            Dictionary<List<int>, List<int>> cords = new Dictionary<List<int>, List<int>>();

            int skeppLängd = int.Parse(Console.ReadLine());
            AddCords(skeppLängd);

            ShipPutter(testDic, dicO = DefaultMap(dicO), dic);

            test2(testDic);
            //TestTest(dic, testDic);

            Console.ReadKey();

        }

        static void AddCords(int skeppLängd)
        {
            Console.WriteLine("Skriv in kordinater för ditt skepp, börja med z, sen y.");

            Dictionary<int, int> cords1 = new Dictionary<int, int>();

            Console.WriteLine("X = ");

            xCord.Add(int.Parse(Console.ReadLine()));
            int xC = xCord[0];
            Console.WriteLine("Y = ");
            yCord.Add(int.Parse(Console.ReadLine()));
            int yC = yCord[0];

            Console.WriteLine("Vilket håll är skäppet riktat?");
            var dir = Console.ReadKey();
            Console.WriteLine();
            if (dir.Key == ConsoleKey.UpArrow)
            {
                for (int i = 0; i < skeppLängd; i++)
                {
                    xCord.Add(xC);
                    yCord.Add(yC - i);
                }

            }

            else if (dir.Key == ConsoleKey.RightArrow)
            {
                for (int i = 0; i < skeppLängd; i++)
                {
                    xCord.Add(xC + i);
                    yCord.Add(yC);
                }
            }
        }

        bool LengthCheck(ConsoleKeyInfo dir, int skeppLängd)
        {
            if (dir.Key == ConsoleKey.UpArrow)
            {
                if (yCord[0] - skeppLängd < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (dir.Key == ConsoleKey.DownArrow)
            {
                if (yCord[0] + skeppLängd > size)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (dir.Key == ConsoleKey.LeftArrow)
            {
                if (xCord[0] - skeppLängd < 0)
                {

                }
            }


        }

        static Dictionary<int, string> DefaultMap(Dictionary<int, string> defDic)
        {
            for (int j = 0; j < size; j++)
            {
                defDic.Add(j + 1, " o");
            }

            return defDic;
        }

        static Dictionary<int, Dictionary<int, string>> ShipPutter(Dictionary<int, Dictionary<int, string>> fullDic, Dictionary<int, string> dicO, Dictionary<int, string> dic)
        {
            for (int i = 0; i < dicO.Count; i++)
            {

                for (int j = 0; j < dicO.Count; j++)
                {
                    if (xCord.Contains(j + 1))
                    {
                        dic[j + 1] = Skepp.Skepp1;
                    }
                    else
                    {
                        dic[j + 1] = " o";
                    }

                }
                if (yCord.Contains(i + 1))
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
