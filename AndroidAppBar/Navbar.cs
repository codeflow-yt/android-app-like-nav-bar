using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidAppBar
{
    public partial class Navbar : UserControl
    {
        public Navbar()
        {
            InitializeComponent();
        }

        public event EventHandler backButtonClicked;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.backButtonClicked != null)
            {
                this.backButtonClicked(this, e);
            }
        }
    }
}
