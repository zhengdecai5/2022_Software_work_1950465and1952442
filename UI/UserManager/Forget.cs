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
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void Forget_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            //光标离开用户名，判断是否存在用户
            string account = txtUser.Text;
            if(!UserManagerAction.newUser(account))
            {
                labelUser.Text = "不存在该用户";
                txtUser.Focus();
            }
            else
            {
                labelUser.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //更改用户密码并显示
            string account = txtUser.Text;
            string newpassward = txtNewPassward.Text;
            UserManagerAction.changeUser(account, newpassward);
            string str = "更改成功\r\n" + "用户名:" + account + "\r\n" + "新密码:" + newpassward;
            MessageBox.Show(str);
            txtUser.Clear();
            txtNewPassward.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();//关闭窗体
        }
    }
}
