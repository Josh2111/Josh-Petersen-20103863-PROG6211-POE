using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josh_Petersen__20103863__POE__PROG6211
{
    public delegate void ExpenseAlert();
    class ExpensesAlert : Info
    {
        //delegate for showing the warning when over 75% of gross income
        public static string Over75()
        {
            return "YOUR TOTAL EXPENSES ARE OVER 75% OF YOUR INCOME!!!";
        }
    }
}