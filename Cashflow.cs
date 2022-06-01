using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class Cashflow : Accommodation
    {
        public double grossIncome { get; set; }
        public double taxDeduction { get; set; }

        // creation of array to store expense values
        public double[] expenses = new double[5];

        public void UserInput()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            // program will prompt the user to enter the following values needed for calculations later on
            Console.WriteLine("+----------+" +
                "\n| CASHFLOW |" +
                "\n+----------+");

            // error handeling
            try
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPlease enter your Gross Monthly Income: \tR");
                grossIncome = double.Parse(Console.ReadLine());

                Console.Write("Please enter Estimated Monthly Tax Deduction: \tR");
                taxDeduction = double.Parse(Console.ReadLine());

                // array values
                Console.Write("Please enter expenditure on Groceries: \t\tR");
                expenses[0] = double.Parse(Console.ReadLine());

                Console.Write("Please enter expenditure on Water and Lights: \tR");
                expenses[1] = double.Parse(Console.ReadLine());

                Console.Write("Please enter Travel Costs: \t\t\tR");
                expenses[2] = double.Parse(Console.ReadLine());

                Console.Write("Please enter the Cellphone and Telephone Bill: \tR");
                expenses[3] = double.Parse(Console.ReadLine());

                Console.Write("Please enter Other expenses: \t\t\tR");
                expenses[4] = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR!!" +
                    "\n" + e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                
            }
            // calling method from the Accommodation class
            RentOrBuy();
            AvailableBal();
        }
        public void AvailableBal()
        {
            // method calcualtes available balance
            // available balance variable
            double avb;

            if (choice == 1)
            {
                avb = (grossIncome - taxDeduction - rent) -
                    (expenses[0] + expenses[1] + expenses[2] + expenses[3] + expenses[4]);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n-----------------------------------------------------------------");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("+-------------------+" +
               "\n| AVAIALBLE BALANCE |" +
               "\n+-------------------+");

                // will highlight in red if balance is 0 or negative, and will highlight green if the balance is above 0
                if (avb <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n+---------------------------------------------------------------+" +
                        "\n\tYour avaialble balance after deductions is: R" + Math.Round(avb, 2)  +
                        "\n+---------------------------------------------------------------+");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n+---------------------------------------------------------------+" +
                        "\n\tYour avaialble balance after deductions is: R" + Math.Round(avb, 2)  +
                        "\n+---------------------------------------------------------------+");
                }
            }
            else
            {
                // calc available balance
                avb = (grossIncome - taxDeduction - rent) -
                    (expenses[0] + expenses[1] + expenses[2] + expenses[3] + expenses[4]) - GlobalPayment.monthlyPayment;

                // if statement to determine if warning statement appears
                if (GlobalPayment.monthlyPayment > ((grossIncome) / 3))
                {
                    Console.WriteLine("\nYour monthly payment on loan equates to: R" + Math.Round(GlobalPayment.monthlyPayment, 2));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("WARNING!! Approval of home loan is unlikely!");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nYour monthly payment on loan equates to: R" + Math.Round(GlobalPayment.monthlyPayment, 2));
                    Console.WriteLine("Approval of loan is likely");
                }
                // will highlight in red if balance is 0 or negative, and will highlight green if the balance is above 0
                if (avb <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n+---------------------------------------------------------------+" +
                        "\n\tYour avaialble balance after deductions is: R" + Math.Round(avb, 2)  +
                        "\n+---------------------------------------------------------------+");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n+---------------------------------------------------------------+" +
                        "\n\tYour avaialble balance after deductions is: R" + Math.Round(avb, 2)  +
                        "\n+---------------------------------------------------------------+");
                }
            }
        }
    }
}
