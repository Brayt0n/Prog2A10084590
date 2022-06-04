using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppV2
{
    // abstract class
    public abstract class Expense : Cashflow
    {
        public abstract void Calculation();
    }
}
