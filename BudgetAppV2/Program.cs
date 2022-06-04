using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    // Code Author: Brayton Chetty [ST10084590]

    internal class Program
    {
        static void Main(string[] args)
        {
            // object instantiation
            Cashflow cf = new Cashflow();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // welcome message
            Console.WriteLine("+-----------------------------------------------------------------------+" +
                "\n|\t\t    WELCOME TO THE BUDGET MANAGER 2.0\t\t\t|" +
                "\n+-----------------------------------------------------------------------+");

            // partial load time
            Thread.Sleep(1000);
            Thread.Sleep(1000);

            // improved form of exception handling -- program no longer carries on after encountering an exception
            try
            {
                // continue variable
                string cont;
                do
                {
                    // calling of the user input method
                    cf.UserInput();
                    
                    // clears the expenses list so data can reset if the user wants to log another budget report
                    GlobalExpense.expenses.Clear();
                    // exit/continue protocol 
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nWould you like to continue?");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Select [y] to continue or any other key to exit: ");
                    cont = Console.ReadLine();
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                } while (cont == "y");
            }
            catch (FormatException e)
            {
                // user will need to re-run program and enter the correct format
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR!!" +
                    "\n" + e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please press ENTER and then re-run the program");
                Console.ReadLine();
            }
        }
    }
}
