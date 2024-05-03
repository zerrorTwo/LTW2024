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
    public partial class Provider : Form
    {
        public Provider()
        {
            InitializeComponent();
        }

        private void Provider_Load(object sender, EventArgs e)
        {

        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            ProviderDetails providerDetails = new ProviderDetails();
            providerDetails.Show();
        }
    }
}
