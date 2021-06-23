using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows;

namespace Josh_Petersen__20103863__POE__PROG6211
{
    class BudgetGeneric<T> : Info
    {
        private static string path = System.IO.Path.GetFullPath(@"..\..\..\") + "expensesResults.txt";
        private static object[] expense;
        private static int stackPointer = 0; //sets stackPointer size
        Info i = new Info();

        private string display;
        #region Generic collection

        public BudgetGeneric(int size)
        {
            expense = new object[size];
        }

        public void Push(object expenses)
        {
            expense[stackPointer] = expenses;
            stackPointer++;
        }

        public string Display()
        {
            for (int x = 0; x < stackPointer; x++)
            {
                display += expense[x] + "\n";
            }
            return display;
        }
        #endregion

        public void Save()
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(getGroceries());
                        sw.WriteLine(getCellphone());
                        sw.WriteLine(getMonthlyTax());
                        sw.WriteLine(getTravelCosts());
                        sw.WriteLine(getOtherExpenses());
                        sw.WriteLine(getPurchasePrice());
                        sw.WriteLine(getMonthlyRent());
                        sw.WriteLine(getRepayMonths());
                        sw.WriteLine(getVehicleDeposit());
                        sw.WriteLine(getVehicleInsurancePrem());
                        sw.WriteLine(getVehicleInterest());
                        sw.WriteLine(getVehicleMake());
                        sw.WriteLine(getVehicleModel());
                        sw.WriteLine(getVehiclePurchPrice());
                        sw.WriteLine(getWater_and_Lights());
                        sw.WriteLine(getInterest());
                        sw.WriteLine(getGrossIncome());
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(expense[stackPointer]);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured " + ex.ToString());
            }
        }

        public string Read()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(getGroceries());
                    sw.WriteLine(getCellphone());
                    sw.WriteLine(getMonthlyTax());
                    sw.WriteLine(getTravelCosts());
                    sw.WriteLine(getOtherExpenses());
                    sw.WriteLine(getPurchasePrice());
                    sw.WriteLine(getMonthlyRent());
                    sw.WriteLine(getRepayMonths());
                    sw.WriteLine(getVehicleDeposit());
                    sw.WriteLine(getVehicleInsurancePrem());
                    sw.WriteLine(getVehicleInterest());
                    sw.WriteLine(getVehicleMake());
                    sw.WriteLine(getVehicleModel());
                    sw.WriteLine(getVehiclePurchPrice());
                    sw.WriteLine(getWater_and_Lights());
                    sw.WriteLine(getInterest());
                    sw.WriteLine(getGrossIncome());
                    sw.Close();
                }
            }

            display = "";

            try
            {
                StreamReader sr = new StreamReader(path, true);
                for (int x = 0; x != File.ReadLines(path).Count() / 1; x++)
                {
                    expense[x] = sr.ReadLine();

                    display += "Your expenses are : " + expense[x] + "\n";
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured" + ex.ToString());
            }
            return display;
        }
    }
}