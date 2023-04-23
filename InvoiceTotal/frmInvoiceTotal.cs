// Author     : @eddie304050
// Description: A simple form that produces discount amounts based on user input and pre-added discount rates.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubtotal_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtSubtotal.Text.Trim()).Length > 0)
            {
                if(!Utility.isDecimal(txtSubtotal.Text) || !Utility.isInRange(0,1000,txtSubtotal.Text))
                {
                    MessageBox.Show("Please enter in a valid subtotal within range!");
                    txtSubtotal.Clear();
                    txtSubtotal.Focus();
                }


            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if ((txtSubtotal.Text.Trim()).Length > 0)
            {
                decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
                decimal discountPercent = 0m;

                if (subtotal > 500)
                    discountPercent = 0.2m;
                else if (subtotal > 250 && subtotal <= 500)
                    discountPercent = 0.15m;
                else if (subtotal > 100 && subtotal <= 250)
                    discountPercent = 0.1m;

                decimal discountAmount = subtotal * discountPercent;
                decimal invoiceTotal = subtotal - discountAmount; 

                txtDiscountAmount.Text = discountAmount.ToString("c");
                txtDiscountPercent.Text = discountPercent.ToString("p1");
                txtTotal.Text = invoiceTotal.ToString("c");
                

            }
        
            else
            {
                MessageBox.Show("Please enter a subtotal!");
                txtSubtotal.Clear();
                txtSubtotal.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSubtotal.Clear();
            txtTotal.Clear();
            txtDiscountAmount.Clear();
            txtDiscountPercent.Clear();
            txtInfo.Clear();
        }
    }
}
