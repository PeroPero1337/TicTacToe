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
        


        static void Main(string[] args)
        {
            string[] arr = new string[9] { null, null, null, null, null, null, null, null, null };
            Console.WriteLine(Grid(arr));
            Random rnd = new Random();
            int n = 0;
            while (true)
            {


                string inp = Console.ReadLine();
                if (arr[int.Parse(inp)] == null)
                {
                    arr[int.Parse(inp)] = "x";
                    do
                    {
                        n = rnd.Next(8);
                        if (arr[n] == null)
                        {
                            arr[n] = "o";
                            break;
                        }
                            
                    }
                    while (arr[n] != null);
                    
                }

                else
                    Console.WriteLine("Taken");
                
                Console.WriteLine();
                Console.WriteLine(Grid(arr));
                
            }
            
                
        }
    }
}
