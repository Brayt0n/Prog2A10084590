using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    public class Vehicle 
    {
        // class variables
        public double purchasePrice { get; set; }
        public double deposit { get; set; }
        public double intRate { get; set; }
        public double estInsurance { get; set; }    

        // will be called if user wishes to buy a vehicle
        public void VehicleExpense ()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+---------+" +
                "\n| VEHICLE |" +
                "\n+---------+");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // user will enter car model and make
            Console.Write("\nPlease enter the car model and make: \t\t\t");
            string modelMake = Console.ReadLine();

            // user will enter the following vehicle related expenses
            Console.Write("Please enter the Purchase Price: \t\t\tR");
            purchasePrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the Total Deposit: \t\t\tR");
            deposit = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the Interest Rate: \t\t\t");
            intRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the Estimated Insurance Premium: \t\tR");
            estInsurance = Convert.ToDouble(Console.ReadLine());

            // calculation for monthly repayment on car
            double monthlyRepayment = (purchasePrice - deposit) * Math.Pow((1 + intRate), 5);

            // calculation for total monthly cost of car
            double totalMonthlyCost = monthlyRepayment + estInsurance;

            // add total monthly cost to the list
            GlobalExpense.expenses.Add(totalMonthlyCost);
        }
    }
}
