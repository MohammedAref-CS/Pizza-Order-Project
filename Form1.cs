using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void UpdateNumberOfPieces()
        {
            if(NumberOfPieces.Value == 0)
            {
                NumberOfPieces.Value = 1;
            }
        }



        bool IsSelected()
        {

            if (rbSamll.Checked)
                return true;

            if (rbMedium.Checked)
                return true;

            if (rbLarge.Checked)
                return true;

            if (rbThickCrust.Checked)
                return true;

            if (rbThinCrust.Checked)
                return true;

            if (chkExtraChees.Checked)
            {
                return true;
            }


            if (chkOnion.Checked)
            {
                return true;
            }

            if (chkMushrooms.Checked)
            {
                return true;
            }

            if (chkOlives.Checked)
            {
                return true;
            }

            if (chkTomatos.Checked)
            {
                return true;
            }

            if (chkGreenPeppers.Checked)
            {
                return true;
            }

            if (rbEatIn.Checked)
            {
                return true;
            }

            if (rbTakeOut.Checked)
            {
                return true;
            }

            return false;

        }

        void UpdateSize()
        {
            
            UpdateTotalPrice();

            if (rbSamll.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }

        void UpdateToppings()
        {

            UpdateTotalPrice();

            string sToppings = "";

            if (chkExtraChees.Checked) 
            {
                sToppings = "Extra Chees";
            }


            if (chkOnion.Checked)
            {
                sToppings += ", Onion";
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkTomatos.Checked)
            {
                sToppings += ", Tomatos";
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", Green Peppars";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings=sToppings.Substring(1,sToppings.Length-1).Trim();
            }

            if (sToppings == "")
                sToppings = "No Toppings";

            lblToppings.Text = sToppings;
            
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked) 
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }


        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In.";
                return;
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out.";
                return;
            }

        }

        float GetSelectedSizePrice()
        {
            if (rbSamll.Checked)

                return Convert.ToSingle(rbSamll.Tag);

            else if (rbMedium.Checked)

                return Convert.ToSingle(rbMedium.Tag);

            else if (rbLarge.Checked)
                return Convert.ToSingle(rbLarge.Tag);
            else
                return 0;

        }

        float  CalculateToppingsPrice()
        {

           
            float ToppingsTotalPrice = 0;

            if (chkExtraChees.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle( chkExtraChees.Tag) ;
            }


            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }

            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkTomatos.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatos.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatos.Tag);
            }



            return ToppingsTotalPrice;



        }

        float GetSelectedCrutPrice()
        {
            if (rbThinCrust.Checked)

                return Convert.ToSingle(rbThinCrust.Tag);

            else if (rbThickCrust.Checked)
                return Convert.ToSingle(rbThickCrust.Tag);
            else
                return 0;

        }

        float CalculateTotalPrice()
        {
            UpdateNumberOfPieces();

            return (GetSelectedSizePrice() + GetSelectedCrutPrice() + CalculateToppingsPrice()) * (float)NumberOfPieces.Value;

            
        }

        void UpdateTotalPrice()
        {

            lblTotalPrice.Text = CalculateTotalPrice().ToString() + "$";

        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();

        }

        void ResetForm()
        {
           
            //reset Groups
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
           
            //reset Size
            rbMedium.Checked = false;
            rbSamll.Checked = false;
             rbLarge.Checked = false;

            //reset Toppings.
            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatos.Checked = false; 
            chkGreenPeppers.Checked = false;
            
            //reset CrustType
            rbThinCrust.Checked = false;
            rbThickCrust.Checked = false;

            //reset Where to Eat
            rbEatIn.Checked = false;
            rbTakeOut.Checked = false;

            //Reset Order Button
            btnOrderPizza.Enabled = true;

            //Reset NumberOfPieces
            NumberOfPieces.Enabled = true;
            NumberOfPieces.Value = 0;

            lblSize.Text = "No Size";
            lblCrustType.Text = "No Crust Type";
            lblWhereToEat.Text = "No Plase";
            


        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            frmFinalBill MyFinalBill = new frmFinalBill();
            

            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            { 
                MessageBox.Show("Ordered Successfully", "Success", 
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;
                NumberOfPieces.Enabled = false;

                MyFinalBill.LoadDataFromOrderForm(lblTotalPrice.Text, lblCrustType.Text, lblSize.Text,
                lblWhereToEat.Text,lblToppings.Text,NumberOfPieces.Text);
                MyFinalBill.ShowDialog();
                

            }
            
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbSamll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatos_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chckGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  UpdateOrderSummary();

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(!IsSelected())
            {
               // MessageBox.Show("You don't Choice any Opetions","Empty Order",MessageBoxButtons.OK, MessageBoxIcon.Information);
                NumberOfPieces.Value = 0;
                return;
            }
            UpdateTotalPrice();
        }

        private void lblPizzaMenu_Click(object sender, EventArgs e)
        {
            Form frm = new frmPizzaMenu();
            frm.ShowDialog();
        }
  
         
    }
}