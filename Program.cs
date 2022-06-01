using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Program : Cashflow
    {
        static void Main(string[] args)
        {
            // object instantiation
            Cashflow cf = new Cashflow();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // welcome message
            Console.WriteLine("+---------------------------------------------------------------+" +
                "\n|\t\t WELCOME TO THE BUDGET MANAGER\t\t\t|" +
                "\n+---------------------------------------------------------------+");
            // partial load time
            Thread.Sleep(1000);
            Thread.Sleep(1000);
  
            // continue variable
            string cont;
            do
            {
                // calling of methods
                cf.UserInput();
                
                // exit/continue protocol 
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n-----------------------------------------------------------------");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nWould you like to continue?");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Select [y] to continue or any other key to exit: "); 
                cont = Console.ReadLine();
                Console.WriteLine("\n-----------------------------------------------------------------");
            } while (cont == "y");
        }
    }
}
