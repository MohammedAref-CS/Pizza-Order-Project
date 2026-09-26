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
    public partial class frmPizzaMenu : Form
    {
        public frmPizzaMenu()
        {
            InitializeComponent();
        }
          
        private void label52_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.ShowDialog();
        }

        private void label53_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
