using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josh_Petersen__20103863__POE__PROG6211
{
    class Info : Expenses
    {
        #region Variables
        //Declare variables
        private static string vehicleModel, vehicleMake;
        private static double grossIncome, monthlyTax;
        private static double rent, purchasePrice, totalDeposit, interest, repayMonths;
        private static double vehiclePurchPrice, vehicleDeposit, vehichleInterest, vehicleInsurancePrem;
        #endregion

        #region get and sets for renting and buying property
        public void setGrossIncome(double grossIn)
        {
            grossIncome = grossIn;
        }
        public void setVehicleModel(string vehModel)
        {
            vehicleModel = vehModel;
        }
        public void setVehicleMake(string vehMake)
        {
            vehicleMake = vehMake;
        }
        public void setVehiclePurchPrice(double vehPurPrice)
        {
            vehiclePurchPrice = vehPurPrice;
        }
        public void setVehicleDeposit(double vehDeposit)
        {
            vehicleDeposit = vehDeposit;
        }
        public void setVehicleInterest(double vehInterest)
        {
            vehichleInterest = vehInterest;
        }
        public void setVehichleInsurancePrem(double vehPremium)
        {
            vehicleInsurancePrem = vehPremium;
        }
        public void setMonthlyTax(double monthsTax)
        {
            monthlyTax = monthsTax;
        }
        public void setMonthlyRent(double monthsRent)
        {
            rent = monthsRent;
        }
        public void setPurchasePrice(double purPrice)
        {
            purchasePrice = purPrice;
        }
        public void setTotalDeposit(double totDeposit)
        {
            totalDeposit = totDeposit;
        }
        public void setInterest(double intRate)
        {
            interest = intRate;
        }
        public void setRepayMonths(double repayMonth)
        {
            repayMonths = repayMonth;
        }
        public double getGrossIncome()
        {
            return grossIncome;
        }
        public string getVehicleModel()
        {
            return vehicleModel;
        }
        public string getVehicleMake()
        {
            return vehicleMake;
        }
        public double getVehiclePurchPrice()
        {
            return vehiclePurchPrice;
        }
        public double getVehicleDeposit()
        {
            return vehicleDeposit;
        }
        public double getVehicleInterest()
        {
            return vehichleInterest;
        }
        public double getVehicleInsurancePrem()
        {
            return vehicleInsurancePrem;
        }
        public double getMonthlyTax()
        {
            return monthlyTax;
        }
        public double getMonthlyRent()
        {
            return rent;
        }
        public double getPurchasePrice()
        {
            return purchasePrice;
        }
        public double getTotalDeposit()
        {
            return totalDeposit;
        }
        public double getInterest()
        {
            return interest;
        }
        public double getRepayMonths()
        {
            return repayMonths;
        }
        #endregion

        #region calculations 
        public double getMonthlyAvailableRent()
        {
            return (getGrossIncome() - (getMonthlyTax() + getTotalExpenses() + getMonthlyRent() + calculateVehicleCost()));
        }

        public double calculateMonthlyRepay()
        {
            //(intl.siyavula.com, n.d.)
            //Calculates the monthly repayments based on user inputs
            return ((getPurchasePrice() - getTotalDeposit()) * (1 + (getInterest() / 100) * (getRepayMonths() / 12))) / getRepayMonths();
        }

        //calculating monthly savings
        public double calculateMonthlySaving()
        {
            return ((getSaveAmt() - getSaveDeposit()) * (1 + (getInterest() / 100) * (getSaveMonths() / 12))) / getSaveMonths();
        }

        //calculating the cost for the purchase of a vehicle
        public double calculateVehicleCost()
        {
            return ((getVehiclePurchPrice() - getVehicleDeposit() - getVehicleInsurancePrem()) * (1 + (getVehicleInterest() / 100)) / 60 * 12);
        }
        //getting the monthly income left after expenses when buying home loan and car loan
        public double getMonthlyAvailableBuying()
        {
            return (getGrossIncome() - (getMonthlyTax() + getTotalExpenses() + calculateMonthlyRepay() + calculateVehicleCost() + getVehicleDeposit()));
        }
        //gets monthly income left after expenses and applying for car loan
        public double getMonthlyAvailableVehicle()
        {
            return (getGrossIncome() - (getMonthlyTax() + getTotalExpenses() + getMonthlyRent() + calculateVehicleCost() + getVehicleDeposit()));
        }
        #endregion
    }
}