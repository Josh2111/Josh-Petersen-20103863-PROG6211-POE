using System;
using System.Collections.Generic;
using System.Text;

namespace Josh_Petersen__20103863__POE__PROG6211
{
    abstract class Expenses
    {
        private static double total_expenses = 0;
        private static double saving = 0;
        private static string saveReason;
        private static double groceries, water_and_lights, TravelCosts, Cellphone, otherExpenses, saveAmt, saveDeposit, saveMonths, saveRate;

        #region gets and sets for expenses
        public void setGroceries(double groc)
        {
            groceries = groc;
        }
        public void setWater_Lights(double water_Lights)
        {
            water_and_lights = water_Lights;
        }
        public void setTravelCosts(double travelCosts)
        {
            TravelCosts = travelCosts;
        }
        public void setCellphone(double cellphone)
        {
            Cellphone = cellphone;
        }
        public void setOtherExpenses(double oExpenses)
        {
            otherExpenses = oExpenses;
        }
        public void setSaveAmt(double save)
        {
            saveAmt = save;
        }
        public void setSaveDeposit(double deposit)
        {
            saveDeposit = deposit;
        }
        public void setSaveMonths(double months)
        {
            saveMonths = months;
        }
        public void setSaveRates(double saveInt)
        {
            saveRate = 0.10;
        }
        public void setSaveReason(string reason)
        {
            saveReason = reason;
        }
        public double getGroceries()
        {
            return groceries;
        }
        public double getWater_and_Lights()
        {
            return water_and_lights;
        }
        public double getTravelCosts()
        {
            return TravelCosts;
        }
        public double getCellphone()
        {
            return Cellphone;
        }
        public double getOtherExpenses()
        {
            return otherExpenses;
        }
        public double getSaveAmt()
        {
            return saveAmt;
        }
        public double getSaveDeposit()
        {
            return saveDeposit;
        }
        public double getSaveMonths()
        {
            return saveMonths;
        }
        public double getSaveRate()
        {
            return saveRate;
        }
        public string getSaveReason()
        {
            return saveReason;
        }
        #endregion

        public double setSave()
        {
            return saving;
        }

        //sets total expenses
        public void setTotalExpenses()
        {
            total_expenses = groceries + water_and_lights + TravelCosts + Cellphone + otherExpenses;
        }

        public double getTotalExpenses()
        {
            setTotalExpenses();
            return total_expenses;
        }
    }
}