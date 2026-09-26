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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
         

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Empty Password");
                MessageBox.Show("Password is Empty", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             
            if (textBox1.Text == Convert.ToString(textBox1.Tag))
            {
                errorProvider1.SetError(textBox1, "");

                textBox1.Text = "";
                Form frm = new Form1();
                frm.ShowDialog();


            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                MessageBox.Show("Wrong Password", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }
         
    }
}
