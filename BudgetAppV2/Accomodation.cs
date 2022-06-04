using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    // accommodation now inherits from the new class vehicle
    public class Accomodation : Vehicle
    {
        // class variables
        public double rent { get; set; }
        public int choice { get; set; }

        public void RentOrBuy()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+---------------+" +
                "\n| ACCOMMODATION |" +
                "\n+---------------+");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // user will have to choose between buying or renting an accommodation
            Console.WriteLine("\nSelect [1] if you wish to rent an accommodation" +
                "\nSelect [2] if you wish to buy an accommodation");
            Console.Write("Selection: ");
            choice = Convert.ToInt32(Console.ReadLine());

            // a loop implemented to get correct paramaters from user
            while (choice != 1 && choice != 2)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR!");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please select either [1] or [2]");
                Console.Write("Selection: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            // user chose either 1 or 2
            if (choice == 1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYOU HAVE SELECTED THE RENT OPTION");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the monthly rent amount: \t\tR");
                rent = double.Parse(Console.ReadLine());
                GlobalExpense.expenses.Add(rent);
            }
            else
            {
                // obj instantiation
                Expense e;
                // from HomeLoan class
                e = new Homeloan();
                e.Calculation();
            }
        }
    }
}
