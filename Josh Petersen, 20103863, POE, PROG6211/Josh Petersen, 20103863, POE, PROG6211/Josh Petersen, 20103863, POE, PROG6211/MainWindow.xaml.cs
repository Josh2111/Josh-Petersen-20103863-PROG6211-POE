using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Josh_Petersen__20103863__POE__PROG6211
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Info info = new Info();
        public MainWindow()
        {
            InitializeComponent();
            canvasBuying.Visibility = Visibility.Hidden;
            canvasRent.Visibility = Visibility.Hidden;
            btnRentClear.Visibility = Visibility.Visible;
            btnRentSubmit.Visibility = Visibility.Visible;
        }

        private void cmbOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOption.SelectedIndex.Equals(0))
            {
                canvasRent.Visibility = Visibility.Visible;
                canvasBuying.Visibility = Visibility.Hidden;
            }
            else
            {
                canvasRent.Visibility = Visibility.Hidden;
                canvasBuying.Visibility = Visibility.Visible;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCell.Clear();
            txtTravel.Clear();
            txtGroceries.Clear();
            txtIncome.Clear();
            txtTax.Clear();
            txtTotal.Clear();
            txtWater.Clear();
            txtOther.Clear();
        }

        private void btnVehClear_Click(object sender, RoutedEventArgs e)
        {
            txtMake.Clear();
            txtModel.Clear();
            txtVehiclePurPrice.Clear();
            txtVehicleDeposit.Clear();
            txtInsurance.Clear();
            txtVehicleInterest.Clear();
        }

        private void btnRentClear_Click(object sender, RoutedEventArgs e)
        {
            txtRentAmt.Clear();
            txtRepay.Clear();
            txtPurAmount.Clear();
            txtDeposit.Clear();
            txtRate.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            BudgetGeneric<double> expense = new BudgetGeneric<double>(100);

            info.setGrossIncome(Convert.ToDouble(txtIncome.Text));
            info.setMonthlyTax(Convert.ToDouble(txtTax.Text));
            info.setGroceries(Convert.ToDouble(txtGroceries.Text));
            info.setTravelCosts(Convert.ToDouble(txtTravel.Text));
            info.setOtherExpenses(Convert.ToDouble(txtOther.Text));
            info.setWater_Lights(Convert.ToDouble(txtWater.Text));
            info.setCellphone(Convert.ToDouble(txtCell.Text));

            expense.Push(info.getGroceries());
            expense.Push(info.getWater_and_Lights());
            expense.Push(info.getTravelCosts());
            expense.Push(info.getCellphone());
            expense.Push(info.getOtherExpenses());
            expense.Save();

            txtTotal.Text = info.getTotalExpenses().ToString();

            MessageBox.Show("Your Gross Income is: R " + info.getGrossIncome() + "\nYour Monthly Tax is: R " + info.getMonthlyTax() 
                + "\nYour total expenses is: R " + string.Format("{0:0.##}", info.getTotalExpenses() 
                + "\nYour money left for the month after expenses is: R " + (string.Format("{0:0.##}", info.getGrossIncome() - info.getMonthlyTax() - info.getTotalExpenses())) 
                + "\n\n THANK YOU FOR USING OUR APPLICATION!!!" + "\nAlternatively Procced to Vehicle Repay to enter further information!!!"));
        }

        private void btnVehSubmit_Click(object sender, RoutedEventArgs e)
        {
            BudgetGeneric<double> expense = new BudgetGeneric<double>(100);

            info.setVehicleMake(txtMake.Text);
            info.setVehicleModel(txtModel.Text);
            info.setVehicleDeposit(Convert.ToDouble(txtVehicleDeposit.Text));
            info.setVehicleInterest(Convert.ToDouble(txtVehicleInterest.Text));
            info.setVehiclePurchPrice(Convert.ToDouble(txtVehiclePurPrice.Text));
            info.setVehichleInsurancePrem(Convert.ToDouble(txtInsurance.Text));

            expense.Push(info.getVehicleDeposit());
            expense.Push(info.getVehicleInterest());
            expense.Push(info.getVehicleInsurancePrem());
            expense.Push(info.getVehiclePurchPrice());
            expense.Save();

            if (info.calculateVehicleCost() > 0.75 * info.getGrossIncome())
            {
                //Calculates 75% of the gross income to see if they qualify or not
                MessageBox.Show(ExpensesAlert.Over75());
            }
            else
            {
                MessageBox.Show("Your Gross Income is: R " + info.getGrossIncome() + "\nYour Monthly Tax is: R " + info.getMonthlyTax() 
                    + "\nYour total expenses is: R " + info.getTotalExpenses() + "\nYour vehicle make is: " + info.getVehicleMake() 
                    + "\nYour vehicle model is: " + info.getVehicleModel() + "\nYour vehicle cost per month is: R " + string.Format("{0:0.##}", info.calculateVehicleCost() 
                    + "\nYour money left for the money after all deductions is: R " + string.Format("{0:0.##}", info.getMonthlyAvailableVehicle()) + "\n\n THANK YOU FOR USING OUR APPLICATION!!!"
                    + "\nAlternatively Procced to Renting/Buying Property to enter further information!!!"));
            }
        }

        private void btnRentSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOption.SelectedIndex.Equals(0))
            {
                //sets the variables to be used when clicking submit
                info.setMonthlyRent(Convert.ToDouble(txtRentAmt.Text));
                info.setGrossIncome(Convert.ToDouble(txtIncome.Text));
                info.setMonthlyTax(Convert.ToDouble(txtTax.Text));



                MessageBox.Show("Your Gross Income is: R " + info.getGrossIncome() + "\nYour Monthly Tax is: R " + info.getMonthlyTax() 
                    + "\nYour total expenses is: R " + info.getTotalExpenses() + "\nYour rent for the month is: R " + info.getMonthlyRent() + "\nYour vehicle make is: " + info.getVehicleMake() 
                    + "\nYour vehicle model is: " + info.getVehicleModel() + "\nYour vehicle cost per month is: R " + string.Format("{0:0.##}", info.calculateVehicleCost() 
                    + "\nYour money left for the money after all deductions is: R " + string.Format("{0:0.##}", info.getMonthlyAvailableRent()) + "\n\n THANK YOU FOR USING OUR APPLICATION!!!!"));
            }

            else
            {
                if (txtRepay.Text.Length != 0 && Convert.ToInt32(txtRepay.Text) >= 240 && (Convert.ToInt32(txtRepay.Text) <= 360))
                {
                    //sets the variables to be used when clicking submit
                    info.setPurchasePrice(Convert.ToDouble(txtPurAmount.Text));
                    info.setTotalDeposit(Convert.ToDouble(txtDeposit.Text));
                    info.setInterest(Convert.ToDouble(txtRate.Text));
                    info.setRepayMonths(Convert.ToDouble(txtRepay.Text));


                    if (info.calculateMonthlyRepay() > 0.75 * info.getGrossIncome())
                    {
                        //Calculates 75% of the gross income to see if they qualify or not
                        MessageBox.Show(ExpensesAlert.Over75());
                    }
                    else
                    {
                        info.setGrossIncome(Convert.ToDouble(txtIncome.Text));
                        info.setMonthlyTax(Convert.ToDouble(txtTax.Text));

                        //(www.daveoncsharp.com, n.d.) 
                        //Returns the money left are all deductions
                        //Number is formatted to two decimal places
                        MessageBox.Show("Your Gross Income is: R " + info.getGrossIncome() + "\nYour Monthly Tax is: R " + info.getMonthlyTax() 
                            + "\nYour total expenses is: R " + info.getTotalExpenses()
                            + "\nYour monthly repayment is: R " + string.Format("{0:0.##}", info.calculateMonthlyRepay()) 
                            + "\nYour total expenses is: R " + info.getTotalExpenses() + "\nYour vehicle make is: " + info.getVehicleMake()
                            + "\nYour vehicle model is: " + info.getVehicleModel() + "\nYour vehicle cost per month is: R " + string.Format("{0:0.##}", info.calculateVehicleCost()
                            + "\nYour repay months for your Home Loan is: " + info.getRepayMonths() + "\nYour money left for the month after all deductions is: R " + string.Format("{0:0.##}", info.getMonthlyAvailableBuying()) 
                            + "\n\n THANK YOU FOR USING OUR APPLICATION!!!!"));
                    }
                }
                else
                {
                    MessageBox.Show("The months you have selected is not valid! Please enter between 240 and 360 only!");
                }
            }
        }

        private void btnSaveClear_Click(object sender, RoutedEventArgs e)
        {
            txtSaveAmt.Clear();
            txtSaveDeposit.Clear();
            txtMonths.Clear();
            txtReason.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            info.setSaveAmt(Convert.ToDouble(txtSaveAmt.Text));
            info.setSaveDeposit(Convert.ToDouble(txtSaveDeposit.Text));
            info.setSaveMonths(Convert.ToDouble(txtMonths.Text));
            info.setSaveReason(txtReason.Text);

            MessageBox.Show("Your save amount is: R" + info.getSaveAmt() + "\nYour deposit amount is: R " +info.getSaveDeposit()
                + "\nYour Months to save is: " + info.getSaveMonths() + "\nYour monthly saving amount to save is: R " + string.Format("{0:0.##}", info.calculateMonthlySaving() 
                + "\nYour reason for saving is: " + info.getSaveReason() + "\n\n THANK YOU FOR USING OUR APPLICATION!!!!"));
        }

        private void btnRentClear_Click_1(object sender, RoutedEventArgs e)
        {
            txtRentAmt.Clear();
            txtRepay.Clear();
            txtPurAmount.Clear();
            txtDeposit.Clear();
            txtRate.Clear();
        }
    }
}