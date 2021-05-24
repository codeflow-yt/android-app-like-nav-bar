using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AndroidAppBar
{
    public partial class Form1 : Form
    {
        //make rounded corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        AndroidAppBar.Navbar nb = new AndroidAppBar.Navbar();
        AndroidAppBar.statusBar st = new AndroidAppBar.statusBar();
        AndroidAppBar.Toolbar tb = new AndroidAppBar.Toolbar();

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));//to change the round radius, change the 5, 5
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addNav();
            string day = DateTime.Now.DayOfWeek.ToString();
            addToolbar("My App");
            addnewstBar(day);//1
        }

        public AndroidAppBar.statusBar addnewstBar(string text)
        {
            st.devName = text;
            this.Controls.Add(st);
            st.Location = new Point(0,0);
            return st;
        }

        public AndroidAppBar.Toolbar addToolbar(string text)
        {
            tb.menuButtonClicked += new EventHandler(menu_Clicked);
            tb.AppBarTitle = text;
            this.Controls.Add(tb);
            tb.Location = new Point(0,20);
            return tb;
        }
        
        public AndroidAppBar.Navbar addNav()
        {
            nb.backButtonClicked += new EventHandler(back_Clicked);
            this.Controls.Add(nb);
            nb.Location = new Point(-240,20);
            return nb;
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            animNav.Start();
        }
        

        private void menu_Clicked(object sender, EventArgs e)
        {
            animNav.Start();
        }


        int step = 10; bool showed = false;
        private void animNav_Tick(object sender, EventArgs e)
        {
            if (showed == false)
            {
                nb.Location = new Point(nb.Location.X+step,nb.Location.Y);
                if (nb.Location.X > 0)
                {
                    nb.Location = new Point(0, nb.Location.Y);
                    animNav.Stop();
                    showed = true;
                }
            }
            else
            {
                nb.Location = new Point(nb.Location.X - step, nb.Location.Y);
                if (nb.Location.X < -240)
                {
                    nb.Location = new Point(-240, nb.Location.Y);
                    animNav.Stop();
                    showed = false;
                }
            }
        } 
    }
}
