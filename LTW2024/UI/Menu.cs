using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTW2024.UI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gwSellProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMoneyPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string qty = tbQty.Text;
            int qtyInt = int.Parse(qty);
            if (qtyInt > 0)
            {
                qtyInt -= 1;
                tbQty.Text = qtyInt.ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string qty = tbQty.Text;
            int qtyInt = int.Parse(qty);
            qtyInt += 1;
            tbQty.Text = qtyInt.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }
    }
}
