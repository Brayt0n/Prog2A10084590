using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    public class GlobalExpense
    {
        public static double monthlyPayment { get; set; }

        // new variables that were added
        public static double totalExpense { get; set; }

        // a generic collection was now added to store the expenses -- as per feedback
        public static List<Double> expenses = new List<Double>();
    }
}
