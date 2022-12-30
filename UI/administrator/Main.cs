using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.administrator;

namespace UI.administrator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 岩石识别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rockcontrol rock = new Rockcontrol();
            rock.TopLevel = false;
            rock.FormBorderStyle = FormBorderStyle.None;
            rock.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(rock);
            rock.Show();
        }

        private void 单词插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordinsert wi = new wordinsert();
            wi.TopLevel = false;
            wi.FormBorderStyle = FormBorderStyle.None;
            wi.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(wi);
            wi.Show();
        }

        private void 单词更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordchange wc = new wordchange();
            wc.TopLevel = false;
            wc.FormBorderStyle = FormBorderStyle.None;
            wc.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(wc);
            wc.Show();
        }
    }
}
