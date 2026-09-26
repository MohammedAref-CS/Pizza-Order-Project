using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class frmFinalBill : Form
    {
        public void LoadDataFromOrderForm(string TotalPrice, string CrustType, string Size,string WhereToEat,string Toppings,string PizzaPieces)
        {

            flblTotalPrice.Text = TotalPrice;
            flblCrustType.Text = CrustType;
            flblSize.Text = Size;
            flblWhereToEat.Text = WhereToEat;
            flblToppings.Text = Toppings;
            flblPizzaPieces.Text = PizzaPieces;
        }

        
        public frmFinalBill()
        {
            InitializeComponent();
        }
         

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
    }
}
