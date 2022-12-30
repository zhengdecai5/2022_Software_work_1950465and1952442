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
using UI.UserManager;
using UI.administrator;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace UI
{
    public partial class LoginForm : Form
    {
        private User user = null;
        public LoginForm()
        {
            InitializeComponent();
        }
        public User getUser() //获取用户信息
        {
            return this.user;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static string account = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string userAccount = tbAccount.Text;  //窗体中输入的用户帐号
            string password = tbPassword.Text; //窗体中输入的用户密码
            user = UserManagerAction.validUser(userAccount, password); //查询用户是否存在，密码是否正确。
            if (user != null&&user.root=="False"&&(rbt.Checked==true||rbtPerson.Checked==true)) //用户存在，转入主界面
            {
                account = user.account;
                using (Form2 fd = new Form2())
                {
                    fd.ShowDialog();
                    tbAccount.Clear();
                    tbPassword.Clear();
                    this.Dispose();
                }
                
            }      
            else if(user != null && user.root == "True" && (rbt.Checked == true || rbtPerson.Checked == true))
            {
                using (Main main = new Main())
                {
                    main.ShowDialog();
                    tbAccount.Clear();
                    tbPassword.Clear();
                    this.Dispose();
                }

            }
            else
            { MessageBox.Show("登录失败，请检查用户名和密码和用户类型", "Error"); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fc = new CreatNew();
            fc.ShowDialog();//转入创建用户界面
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ff = new Forget();
            ff.ShowDialog();
        }
        //拖动窗体    
        [DllImport("user32.Dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.Dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);//调用该函数的控件能够被拖动
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtPerson_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
