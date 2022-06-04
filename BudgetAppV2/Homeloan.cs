using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    public class Homeloan : Expense
    {
        // class variables
        public double propertyPrice { get; set; }
        public double totDeposit { get; set; }
        public double interest { get; set; }
        public double term { get; set; }
        
        // inherits method to override
        public override void Calculation()
        {
            // this class will calculate the homeloan repayment and the available balance thereafter in the Cashflow class
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYOU HAVE SELECTED THE BUY OPTION");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // propery price
            Console.Write("Please enter the Purchase Price of the property: \tR");
            propertyPrice = double.Parse(Console.ReadLine());
            // total deposit
            Console.Write("Please enter the Total Deposit: \t\t\tR");
            totDeposit = double.Parse(Console.ReadLine());
            // interest rate
            Console.Write("Please enter the Interest Rate: \t\t\t ");
            interest = double.Parse(Console.ReadLine());
            // number of months to repay
            Console.Write("Please enter the Number of Months to repay: \t\t ");
            term = double.Parse(Console.ReadLine());

            /* 
             * new exception handling introduced - user will now have to enter between the range of 240 and 360 months,
             * otherwise the program will loop until they do
             */
            while (term <240 || term > 360)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nPlease enter a value between 240 and 360 months");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the Number of Months to repay: \t\t ");
                term = double.Parse(Console.ReadLine());
            }

            // formula to calcualte home loan
            GlobalExpense.monthlyPayment = ((propertyPrice - totDeposit) * (interest / 12) / (1 - Math.Pow((1 + (interest / 12)), -term)));
            GlobalExpense.expenses.Add(GlobalExpense.monthlyPayment);
        }
    }
}
