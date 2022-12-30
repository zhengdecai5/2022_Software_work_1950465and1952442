using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using UI.Forms2;

namespace UI.UserControls
{
    public partial class SU : Form
    {
        Form2 f2;
        public SU(Form2 parent)
        {
            InitializeComponent();
            f2 = parent;
        }
        List<string> supath = new List<string>();
        static readonly string cmd = "export CWPROOT=/usr/local/cwp/;" +
            "export PATH=/usr/local/sbin:/usr/local/bin:/" +
            "usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/snap/bin:" +
            "$CWPROOT/bin:$PATH;cd test;";
        string path = "";
        string str = "";
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SU_Load(object sender, EventArgs e)
        {
            f2.labelName.Text = "当前浏览：数据处理";
            /*   
           string str = SSH.ExecCommand(cmd+"sustrip<upload.su>upload.dat");
           MessageBox.Show("over");
           */
           //文件夹的导入，并识别SU文件
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                DirectoryInfo folder = new DirectoryInfo(path);
                foreach (FileInfo f in folder.GetFiles("*.su"))
                {
                    string file = f.ToString();
                    string filePath = path + "\\" + file;
                    string fileName = file;
                    supath.Add(filePath);
                    listBox1.Items.Add(fileName);
                }
            }
            else
                return;
        }
        //SU文件的导入
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "|*.su";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string str = openFileDialog1.FileName;
            supath.Add(str);
            string[] sl = str.Split('\\');
            str = sl[sl.Length - 1];
            listBox1.Items.Add(str);
        }

        //
        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            string sh = openFileDialog2.FileName;
            SSH.Upload(sh, "run.sh");
            SSH.ExecCommand(cmd + "sh run.sh");
            MessageBox.Show("执行结束：");
            SSH.Download("zerooffset.su", path + "\\zerooffset.su");
            supath.Add(path + "\\zerooffset.su");
            listBox1.Items.Add("zerooffset.su");
            /*
            string model;
            Form_play fl = new Form_play();
            fl.ShowDialog();
            if (fl.Visible == false) {
                model = Form_play.model;
                fl.Close();
                SSH.ExecCommand(cmd + model);
                SSH.Download("cdp.su", path + "\\zerooffset.su");
                supath.Add(path + "\\zerooffset.su");
                listBox1.Items.Add("zerooffset.su");
            }
            */
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            else
            {
                SSH.Upload(supath[listBox1.SelectedIndex]);
                swind fs = new swind();
                fs.ShowDialog();

                if (fs.Visible == false)
                {
                    string scmd = cmd + "suwind<upload.su" + " key=" + swind.keyval + " max=" + swind.maxsize + " min=" + swind.minsize + ">suwind.su";
                    fs.Close();
                    string str = SSH.ExecCommand(scmd);
                    str = listBox1.SelectedItem.ToString();
                    str = str.Split('.')[0];
                    SSH.Download("suwind.su", path + "\\" + str + "_suwind.su");
                    supath.Add(path + "\\" + str + "_suwind.su");
                    listBox1.Items.Add(str + "_suwind.su");
                }
            }
        }
        //执行服务器上相关脚本，实现操作
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            else
            {
                SSH.Upload(supath[listBox1.SelectedIndex]);
                string str = SSH.ExecCommand(cmd + "surange<upload.su>range.txt");
                MessageBox.Show("执行结束");
                SSH.Download("range.txt", path + "\\range.txt");
                StreamReader sr = new StreamReader(path + "\\range.txt", Encoding.UTF8);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            else
            {
                SSH.Upload(supath[listBox1.SelectedIndex]);
                SSH.ExecCommand(cmd + "susort<upload.su cdp>cdp.su");
                MessageBox.Show("执行结束：");
                str = listBox1.SelectedItem.ToString();
                str = str.Split('.')[0];
                SSH.Download("cdp.su", path + "\\" + str + "_cdp.su");
                supath.Add(path + "\\" + str + "_cdp.su");
                listBox1.Items.Add(str + "_cdp.su");
                /*
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Load(path + "\\cdp.jpg");
                */
            }
        }
        //执行服务器上相关脚本，实行相关操作
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            else
            {
                SSH.Upload(supath[listBox1.SelectedIndex]);
                SSH.ExecCommand(cmd + "susort<upload.su offset>offset.su");
                MessageBox.Show("执行结束");
                str = listBox1.SelectedItem.ToString();
                str = str.Split('.')[0];
                SSH.Download("offset.su", path + "\\" + str + "_offset.su");
                supath.Add(path + "\\" + str + "_offset.su");
                listBox1.Items.Add(str + "_offset.su");
                /*
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Load(path + "\\cdp.jpg");
                */
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
