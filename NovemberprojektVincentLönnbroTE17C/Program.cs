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
     *      Göra så att det finns en int som håller koll på vilket skepp man håller på att välja cords för så att man därefter kan lägga in en lista med de cordsen i en dictionary
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

        public static Dictionary<int, List<int>> xCordAll = new Dictionary<int, List<int>>();
        public static Dictionary<int, List<int>> yCordAll = new Dictionary<int, List<int>>();

        static int size = 8;

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

            List<int> nullCords = new List<int>(); 

            dicO = DefaultMap(dicO);
            xCordAll.Add(0, nullCords);
            yCordAll.Add(0, nullCords);


            testDic = DefaultMap1(testDic, dicO);

            for (int i = 0; i < 5; i++)
            {
                AddCords(skeppLängd, i + 1);

                ShipPutter(testDic, dicO, dic, i + 1);

                test2(testDic);
            }
            //TestTest(dic, testDic);

            Console.ReadKey();

        }

        static void AddCords(int skeppLängd, int skeppNr)
        {
            List<int> yCord = new List<int>();
            List<int> xCord = new List<int>();
            Console.WriteLine("Skriv in kordinater för ditt skepp, börja med z, sen y.");

            Dictionary<int, int> cords1 = new Dictionary<int, int>();

            Console.WriteLine("X = ");

            xCord.Add(int.Parse(Console.ReadLine()) - 1);
            int xC = xCord[0];
            Console.WriteLine("Y = ");
            yCord.Add(int.Parse(Console.ReadLine()));
            int yC = yCord[0];

            bool succes = false;

            Console.WriteLine("Vilket håll är skäppet riktat?\nAnvänd piltangenterna för att välja riktning!");

            var dir = Console.ReadKey();
            while (succes == false)
            {
                if (dir.Key == ConsoleKey.UpArrow || dir.Key == ConsoleKey.DownArrow || dir.Key == ConsoleKey.LeftArrow || dir.Key == ConsoleKey.RightArrow)
                {
                    if (LengthCheck(dir, skeppLängd, xC, yC) == true)           // denna if satsen ligger här och inte i den ovan då jag vill kunna vara mer specifik om vad som var fel
                    {
                        if (dir.Key == ConsoleKey.UpArrow)
                        {
                            for (int i = 1; i < skeppLängd; i++)
                            {
                                yCord.Add(yC - i);
                            }

                        }

                        else if (dir.Key == ConsoleKey.RightArrow)
                        {
                            for (int i = 1; i < skeppLängd; i++)
                            {
                                xCord.Add(xC + i);
                            }
                        }
                        else if (dir.Key == ConsoleKey.DownArrow)
                        {
                            for (int i = 0; i < skeppLängd; i++)
                            {
                                yCord.Add(yC + i);
                            }
                        }
                        else if (dir.Key == ConsoleKey.LeftArrow)
                        {
                            for (int i = 1; i < skeppLängd; i++)
                            {
                                xCord.Add(xC - i);
                            }
                        }
                        succes = true;
                    }
                    else
                    {
                        Console.WriteLine("Skeppet åkte utanför spelplanen, välj en annan riktning!");
                        Console.WriteLine("Vilket håll är skäppet riktat?\nAnvänd piltangenterna för att välja riktning!");
                        dir = Console.ReadKey();
                    }
                }
                else
                {

                    Console.WriteLine("Skriv rätt >:(");
                    Console.ReadLine();
                    Console.WriteLine("Vilket håll är skäppet riktat?\nAnvänd piltangenterna för att välja riktning!");
                    dir = Console.ReadKey();

                }
            }

            xCordAll.Add(skeppNr, xCord);
            yCordAll.Add(skeppNr, yCord);
            Console.WriteLine();


        }

        static bool LengthCheck(ConsoleKeyInfo dir, int skeppLängd, int xC, int yC)
        {
            if (dir.Key == ConsoleKey.UpArrow)
            {
                if (yC - skeppLängd < 0)
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
                if (yC + skeppLängd > size)
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
                if (xC - skeppLängd < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (xC + skeppLängd < 0)
                {
                    return false;
                }
                else
                {
                    return true;
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

        static bool CordsChecker(int skeppNr, int nr)
        {
            if (xCordAll[skeppNr].Contains(nr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Dictionary<int, Dictionary<int, string>> DefaultMap1(Dictionary<int, Dictionary<int, string>> fullDic, Dictionary<int, string> dicO)
        {
            for (int i = 0; i < dicO.Count; i++)
            {
                fullDic[i] = dicO;
            }
            return fullDic;
        }

        static void ShipPutter(Dictionary<int, Dictionary<int, string>> fullDic, Dictionary<int, string> dicO, Dictionary<int, string> dic, int skeppNr)
        {
            for (int i = 0; i < dicO.Count; i++)
            {

                for (int j = 0; j < dicO.Count; j++)
                {
                    if (CordsChecker(skeppNr - 1, j))
                    {
                        dic[j + 1] = Skepp.Skepp1;
                    }
                    else if (CordsChecker(skeppNr, j))
                    {
                        dic[j + 1] = Skepp.Skepp1;
                    }
                    else
                    {
                        dic[j + 1] = " o";
                    }

                }
                if (yCordAll[skeppNr].Contains(i + 1))
                {
                    fullDic[i] = dic;
                }
                else if (yCordAll[skeppNr - 1].Contains(i + 1))
                {
                    fullDic[i] = dic;
                }
                else
                {
                    fullDic[i] = dicO;
                }

            }
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
