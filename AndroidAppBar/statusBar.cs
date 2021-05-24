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
    public partial class statusBar : UserControl
    {
        public string statusBarTime
        {
            get { return lbl_time.Text; }
            set { lbl_time.Text = value; }
        }

        public string devName
        {
            get { return lbl_name.Text; }
            set { lbl_name.Text = value; }
        }

        public statusBar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute < 10)
                lbl_time.Text = DateTime.Now.Hour.ToString() + ":" + "0" + DateTime.Now.Minute.ToString();
            else
                lbl_time.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
