using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserManager
{
    public partial class CreatNew : Form
    {
        public CreatNew()
        {
            InitializeComponent();
        }

        private void CreatNew_Load(object sender, EventArgs e)
        {
            txtNewUser.Focus();
        }

        private void txtNewUser_Leave(object sender, EventArgs e)
        {
            //光标离开用户名控件，判断是否为重复用户
            string account = txtNewUser.Text;
            if(account=="")
            {
                labelUser.Text = "用户名不能为空！";
                txtNewUser.Focus();
            }
            else if (UserManagerAction.newUser(account))//静态方法
            {
                labelUser.Text = "重复用户！";
                txtNewUser.Focus();
            }
            else
            {
                labelUser.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建新用户并显示
            string passward = txtPassward.Text;
            string account=txtNewUser.Text;
            UserManagerAction.creatNewUser(account, passward);
            string str = "创建成功\r\n" + "用户名:" + account + "\r\n" + "密码:" + passward;
            MessageBox.Show(str);
            txtNewUser.Clear();
            txtPassward.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();//关闭窗体
        }

        private void CreatNew_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNewUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                  (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == 8) || (e.KeyChar == '_'))
            {
                e.Handled = false;
            }

            else
            {
                MessageBox.Show("用户名只能为字母、数字和下划线！");
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                 (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == 8) || (e.KeyChar == '_'))
            {
                e.Handled = false;
            }

            else
            {
                MessageBox.Show("密码只能为字母、数字和下划线！");
                e.Handled = true;
            }
        }

        private void txtNewUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassward_Leave(object sender, EventArgs e)
        {
            string passward = txtPassward.Text;
            if(passward=="")
            {
                labelUser.Text = "密码不能为空！";
                txtPassward.Focus();
            }
        }
    }
}
