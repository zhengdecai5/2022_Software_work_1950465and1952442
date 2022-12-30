using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UserControls;
using UI;
using System.IO;
using System.Runtime.InteropServices;

namespace UI.Forms2
{

    public partial class Form2 : Form
    {
        int PanelWidth; //边栏的指定最大宽度
        bool isCollapsed; //边栏宽度是否为0
        public Form2()
        {
            InitializeComponent();


        }
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();//边栏移动开始
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 30; //边栏宽度随计时器1计时扩大
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 30;//边栏宽度缩小
                if (panelLeft.Width <= 47)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();//关闭窗体
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PanelWidth = panelLeft.Width; 
            isCollapsed = false; 
            //在panel中打开新的HOME窗体
            Home home = new Home(this); 
            home.TopLevel = false;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;
            this.panelControls.Controls.Clear();
            this.panelControls.Controls.Add(home);
            home.Show();
            //计时器2开始计时
            timer2_Tick(null, null);
            timer2.Enabled = true;
        }
        private void moveSidePanel(Control btn) //移动按钮附近的指示条，实现被点击按钮附近出现相应指示条功能
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void append(Control btn, int i, int j, int k) //更改按钮颜色，实现被点击按钮颜色更改功能
        {
            btn.ForeColor = Color.FromArgb(i, j, k);
            panelSide.BackColor = Color.FromArgb(i, j, k);
        }
        private void disappear(Control btn) //按钮颜色复原
        {
            btn.ForeColor = Color.White;
        }
        private void AddControlsToPanel(Control c)  
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            disappear(btn2);
            disappear(btn4);
            append(btn1, 172, 126, 241);
            moveSidePanel(btn1);
            //在panel中显示新的岩石知识窗体
            RockKnow rk = new RockKnow(this);
            rk.TopLevel = false;
            rk.FormBorderStyle = FormBorderStyle.None;
            rk.Dock = DockStyle.Fill;
            this.panelControls.Controls.Clear();
            this.panelControls.Controls.Add(rk);
            rk.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            disappear(btn1);
            disappear(btn4);
            append(btn2, 249, 118, 176);
            moveSidePanel(btn2);
            //在panel中显示新的ShowForm窗体
            ShowForm sform = new ShowForm(this);
            sform.TopLevel = false;
            sform.FormBorderStyle = FormBorderStyle.None;
            sform.Dock = DockStyle.Fill;
            this.panelControls.Controls.Clear();
            this.panelControls.Controls.Add(sform);
            sform.Show();


        }

        private void btn3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            disappear(btn2);
            disappear(btn1);
            append(btn4, 95, 77, 221);
            moveSidePanel(btn4);
            //在panel中显示新的SU窗体
            SU su = new SU(this);
            su.TopLevel = false;
            su.FormBorderStyle = FormBorderStyle.None;
            su.Dock = DockStyle.Fill;
            this.panelControls.Controls.Clear();
            this.panelControls.Controls.Add(su);
            su.Show();
        }

        private void btn1_Leave(object sender, EventArgs e)
        {


        }

        private void btn2_Leave(object sender, EventArgs e)
        {


        }

        private void btn3_Leave(object sender, EventArgs e)
        {


        }

        private void btn4_Leave(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            disappear(btn1);
            disappear(btn2);
            disappear(btn4);
            //在panel中显示新的HOME窗体
            Home home = new Home(this);
            home.TopLevel = false;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;
            this.panelControls.Controls.Clear();
            this.panelControls.Controls.Add(home);
            home.Show();
        }
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panelControls_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            labelHour.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.WindowState ==System.Windows.Forms.FormWindowState.Normal)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
