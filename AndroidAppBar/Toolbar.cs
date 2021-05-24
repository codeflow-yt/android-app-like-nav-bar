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
    public partial class Toolbar : UserControl
    {
        public string AppBarTitle
        {
            get { return lbl_appBar.Text; }
            set { lbl_appBar.Text = value; }
        }

        public Toolbar()
        {
            InitializeComponent();
        }

        public event EventHandler menuButtonClicked;

        protected void pictureBox1_Click(object sender, EventArgs e)
        {
            //bubble up the event to the parent
            if (this.menuButtonClicked != null)
            {
                this.menuButtonClicked(this, e);
            }
        }
    }
}
