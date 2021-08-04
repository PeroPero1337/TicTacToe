using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        private static string Grid(string[] arr)
        {
            string grid = $"  {arr[0]}  |  {arr[1]}  |  {arr[2]}  \n" +
                          $"-----------------\n" +
                          $"  {arr[3]}  |  {arr[4]}  |  {arr[5]}  \n" +
                          $"-----------------\n" +
                          $"  {arr[6]}  |  {arr[7]}  |  {arr[8]}  ";


            return grid;
        }

        private static string Victroy(string[] arr)
        {
            string x = "xxx";
            string o = "ooo";


            string hor1 = arr[0] + arr[1] + arr[2];
            string hor2 = arr[3] + arr[4] + arr[5];
            string hor3 = arr[6] + arr[7] + arr[8];

            string vert1 = arr[0] + arr[3] + arr[6];
            string vert2 = arr[1] + arr[4] + arr[7];
            string vert3 = arr[2] + arr[5] + arr[8];

            string diag1 = arr[0] + arr[4] + arr[8];
            string diag2 = arr[2] + arr[4] + arr[6];

            //quick if
            string toReturn = ((x == hor1) || (x == hor2) || (x == hor3)) ? "x" :
                ((x == vert1) || (x == vert2) || (x == vert3)) ? "x" :
                ((x == diag1) || (x == diag2)) ? "x" :
                ((o == hor1) || (o == hor2) || (o == hor3)) ? "o" :
                ((o == vert1) || (o == vert2) || (o == vert3)) ? "o" :
                ((o == diag1) || (o == diag2)) ? "o" : "";

            return toReturn;
        }

        private static bool IsFinished(string[] arr)
        {
            if (arr.Any(x => x == null) == false) //full
                return true;
            else if(Victroy(arr) != "")
                return true;

            return false;
        }

        private static void Bot(string[] arr)
        {
            Random rnd = new Random();
            int n = 0;
            bool search = true;
            while (search)
            {
                n = rnd.Next(8);
                if (arr[n] == null)
                {
                    arr[n] = "o";
                    search = false;
                }

                if (IsFinished(arr) == true)
                    search = false;
            }

        }

        private static void Player(string input, string[] arr)
        {
            if (arr[int.Parse(input)] == null)
            {
                arr[int.Parse(input)] = "x";
                if(IsFinished(arr) != true)
                    Bot(arr);
            }
            else
                Console.WriteLine("Position already taken!");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Positions on grid");
            string[] legend = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            Console.WriteLine(Grid(legend));
            Console.WriteLine("==========================================");
            bool replay = true;

            while (replay)
            {
                
                string[] arr = new string[9] { null, null, null, null, null, null, null, null, null };
                Console.WriteLine(Grid(arr));
                
                while (IsFinished(arr) == false)
                {
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Insert position!");
                    string inp = Console.ReadLine();
                    Player(inp, arr);

                    Console.WriteLine();
                    Console.WriteLine(Grid(arr));

                }

                string s = Victroy(arr) == "x" ? "Player wins!" : Victroy(arr) == "" ? "Draw" : "Bot wins!";

                Console.WriteLine();
                Console.WriteLine(s);

                Console.WriteLine("Replay?(y/n)");
                string check = Console.ReadLine();

                if (check.ToLower() == "n")
                    replay = false;

            }

            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();

        }
    }
}
