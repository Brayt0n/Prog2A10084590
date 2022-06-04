using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    public class Cashflow : Accomodation
    {
        public double grossIncome { get; set; }
        public double taxDeduction { get; set; }

        // delegate added for warning message
        public delegate void WarningExceedDelegate(string msg);

        public void UserInput()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            // program will prompt the user to enter the following values needed for calculations later on
            Console.WriteLine("+----------+" +
                "\n| CASHFLOW |" +
                "\n+----------+");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPlease enter your Gross Monthly Income: \tR");
            grossIncome = double.Parse(Console.ReadLine());

            Console.Write("Please enter Estimated Monthly Tax Deduction: \tR");
            taxDeduction = double.Parse(Console.ReadLine());

            // generic collection values
            Console.Write("Please enter expenditure on Groceries: \t\tR");
            GlobalExpense.expenses.Add(double.Parse(Console.ReadLine()));

            Console.Write("Please enter expenditure on Water and Lights: \tR");
            GlobalExpense.expenses.Add(double.Parse(Console.ReadLine()));

            Console.Write("Please enter Travel Costs: \t\t\tR");
            GlobalExpense.expenses.Add(double.Parse(Console.ReadLine()));

            Console.Write("Please enter the Cellphone and Telephone Bill: \tR");
            GlobalExpense.expenses.Add(double.Parse(Console.ReadLine()));

            Console.Write("Please enter Other expenses: \t\t\tR");
            GlobalExpense.expenses.Add(double.Parse(Console.ReadLine()));

            // calling method from the Accommodation class
            RentOrBuy();

            // new class/method implementation - user will either select Y to buy a new vehicle or any other key to continue
            Console.Write("\nAre you going to purchase a vehicle in the foreseeable future?" +
                "\nPlease select [Y] for yes or any other key to continue: ");
            char vehicleChoice = Convert.ToChar(Console.ReadLine());
            if (vehicleChoice == 'Y' || vehicleChoice == 'y')
            {
                VehicleExpense();
                AvailableBal();
            }
            else
            {
                AvailableBal();
            }
        }
        public void AvailableBal()
        {
            // method calcualtes available balance
            // available balance variable
            double avb;

            // expSum variable introduced to total the expense list
            GlobalExpense.totalExpense = GlobalExpense.expenses.Sum();

            if (choice == 1)
            {
                // calculation of available balance
                // gets the total expense if user selected rent
                avb = (grossIncome - taxDeduction - GlobalExpense.totalExpense);

                // will highlight in red if balance is 0 or negative, and will highlight green if the balance is above 0
                if (avb <= 0)
                {
                    PrintExpense();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n========================================================================" +
                        "\n\t  Your avaialble balance after deductions is: R" + Math.Round(avb, 2) +
                        "\n========================================================================");
                }
                else
                {
                    PrintExpense();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n========================================================================" +
                        "\n\t  Your avaialble balance after deductions is: R" + Math.Round(avb, 2) +
                        "\n========================================================================");
                }
            }
            else
            {
                // calculation of available balance
                // gets the total expense if the user selected buy
                avb = (grossIncome - taxDeduction - GlobalExpense.totalExpense);

                // if statement to determine if warning statement appears
                // created a loan stats section that will inform user on loan status
                if (GlobalExpense.monthlyPayment > ((grossIncome) / 3))
                {
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nLOAN STATISTICS");
                    Console.WriteLine("\nYour monthly payment on loan (house) equates to: R" + Math.Round(GlobalExpense.monthlyPayment, 2));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("WARNING!! Approval of home loan is unlikely!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nPlease press ENTER to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nLOAN STATISTICS");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nYour monthly payment on loan equates to: R" + Math.Round(GlobalExpense.monthlyPayment, 2));
                    Console.WriteLine("Approval of loan is likely");
                    Console.Write("\nPlease press ENTER to continue");
                    Console.ReadLine();
                }
                // will highlight in red if balance is 0 or negative, and will highlight green if the balance is above 0
                if (avb <= 0)
                {
                    PrintExpense();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n========================================================================" +
                        "\n\t  Your avaialble balance after deductions is: R" + Math.Round(avb, 2) +
                        "\n========================================================================");
                }
                else
                {
                    PrintExpense();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n========================================================================" +
                        "\n\t  Your avaialble balance after deductions is: R" + Math.Round(avb, 2) +
                        "\n========================================================================");
                }
            }
        }
        // method that will be called by available balance method to show expenses based on situation
        public void PrintExpense()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+---------+" +
               "\n| SUMMARY |" +
               "\n+---------+\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // count variable for list
            int count = 1;

            // arranges values to descending order
            foreach (Double item in GlobalExpense.expenses.OrderByDescending(d => d))
            {
                Console.WriteLine("Expense " + count + ": \tR" + Math.Round(item,2));
                count++;
            }
            Console.WriteLine("--------------------" +
                "\nTOTAL EXPENSE:  R" + Math.Round(GlobalExpense.totalExpense, 2));

            // delegate for warning message 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WarningExceedDelegate wed = new WarningExceedDelegate(WarningExceed);
            Console.WriteLine();
            wed("WARNING -- YOUR TOTAL EXPENSE IS GREATER THAN 75% OF YOUR GROSS INCOME!!");
        }
        // method will be called if the total expenditure > 75% of gross income
        public void WarningExceed(string msg)
        {
            if (GlobalExpense.totalExpense > (grossIncome * 0.75))
            {
                Console.WriteLine(msg);
            }
        }
    }
}
