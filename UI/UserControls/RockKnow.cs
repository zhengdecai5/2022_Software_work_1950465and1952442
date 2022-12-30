using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UI.Forms2;
using System.IO;
using System.Diagnostics;
using AxWMPLib;
using System.Threading;

namespace UI.UserControls
{
    public partial class RockKnow : Form
    {
        Form2 f2;
        public RockKnow(Form2 parent)
        {

            InitializeComponent();
            f2 = parent;
        }

        private void RockKnow_Load(object sender, EventArgs e)
        {
            f2.labelName.Text = "当前浏览：矿物鉴定";
        }
        string path = Application.StartupPath;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        public static void RunPythonScript()
        {
            Process p = new Process();
            string path = Application.StartupPath;
            string sArguments = path + "\\code\\load_model.py";
            p.StartInfo.FileName = @"python.exe";
            string Arguments = sArguments;
            p.StartInfo.Arguments = sArguments;//python命令的参数
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.CreateNoWindow = true;
            p.Start();//启动进程
            Thread.Sleep(5000);
            MessageBox.Show("执行完毕");
            p.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "|*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string str = openFileDialog1.FileName;
            pictureBox2.Image = Image.FromFile(str);
            File.Copy(str, path + "\\code\\P\\user\\1.bmp", true);
            //运行程序
            RunPythonScript();
            if (button2.Text == "矿物识别")
            {
                pictureBox1.Image = Image.FromFile(path + "\\code\\P\\resault\\1resault.bmp");
                button2.Text = "继续识别";            
            }
            else
                pictureBox1.Image = Image.FromFile(path + "\\code\\P\\resault\\2resault.bmp");

        }
    }
    }
