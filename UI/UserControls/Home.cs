using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms2;
using UI;

namespace UI.UserControls
{
    public partial class Home : Form
    {
        Form2 f2; 
        public Home(Form2 parent)
        {
            InitializeComponent();
            f2 = parent;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHour.Text = DateTime.Now.ToString("HH:mm:ss");
            labelDay.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
            timer1.Enabled = true;
            f2.labelName.Text = "当前浏览：主界面";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
