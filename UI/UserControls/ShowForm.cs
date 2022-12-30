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
using System.Security.Permissions;
using System.Data.SqlClient;
using UI.Forms2;
using Microsoft.Office.Interop.Excel;



namespace UI.UserControls
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

    [System.Runtime.InteropServices.ComVisibleAttribute(true)] //C#与Java能够交互
    public partial class ShowForm : Form
    {
        public ShowForm(Form2 parent)
        {
            InitializeComponent();
            f2 = parent;
        }
        //更改DeBug文件中的1.html文件，在指定位置加入相关的标记点的代码，并生成2.html文件
        public void ChangeHTML()
        {
            string path = System.Windows.Forms.Application.StartupPath;
                StreamReader sr = new StreamReader(path + "\\1.html");
                string strhtml = sr.ReadToEnd();
                int length = listView1.Items.Count;
                string newhtml = "";
                for (int i = 0; i < length; i++)
                {
                    newhtml += "var point = new BMap.Point(" + listView1.Items[i].SubItems[1].Text + "," + listView1.Items[i].SubItems[2].Text + "); " + Environment.NewLine;
                    newhtml += "var marker = new BMap.Marker(point);" + Environment.NewLine;
                    newhtml += "var txt =\" 震源：" + listView1.Items[i].SubItems[0].Text + ";震级" + listView1.Items[i].SubItems[4].Text + ";经纬度：(" + listView1.Items[i].SubItems[1].Text + "," + listView1.Items[i].SubItems[2].Text + ")\";" + Environment.NewLine;
                    newhtml += "addMarker(point, marker, txt);" + Environment.NewLine;
                }
                strhtml = strhtml.Replace("Tongji", newhtml);
                sr.Close();
                StreamWriter sw = new StreamWriter(path + "\\2.html" );
                sw.Write(strhtml);
                sw.Flush();
                sw.Close();
                wbShow.ScriptErrorsSuppressed = true;
                string path2 = Path.Combine(System.Windows.Forms.Application.StartupPath, "2.html");
                wbShow.Navigate(path2);
            
        }
        Form2 f2;
        private void ShowForm_Load(object sender, EventArgs e)
        {
            f2.labelName.Text = "当前浏览：地震数据";
            wbShow.ScriptErrorsSuppressed = true;
            string path2 = Path.Combine(System.Windows.Forms.Application.StartupPath, "1.html");
            wbShow.Navigate(path2);

        }

        private void wbShow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //与数据库交互，实现数据查询功能，并将内容保存在ListView中。
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                MessageBox.Show("请选择发震时间");
            }
            else
            {
                string sql = "select 参考位置,经度,纬度,深度,震级,发震时刻 from Table1 where month(发震时刻)=" + cmbMonth.Text;
                SqlCommand cmd = new SqlCommand(sql, DBconnection1.conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    DBconnection1.conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    listView1.Items.Clear();
                    while (rdr.Read())
                    {
                        ListViewItem li = new ListViewItem();
                        li.SubItems.Clear();
                        li.SubItems[0].Text = rdr["参考位置"].ToString();
                        li.SubItems.Add(rdr["经度"].ToString());
                        li.SubItems.Add(rdr["纬度"].ToString());
                        li.SubItems.Add(rdr["深度"].ToString());
                        li.SubItems.Add(rdr["震级"].ToString());
                        li.SubItems.Add(rdr["发震时刻"].ToString());
                        listView1.Items.Add(li);
                    }
                    rdr.Close();
                    DBconnection1.conn.Close();
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DbConnection.conn.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = cmbMonth.Text;
            ChangeHTML();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportData();
        }
        public void ExportData()
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportExcel ee = new ExportExcel();
                ee.ExcelExport(this.listView1, saveFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowForm_child sf_c = new ShowForm_child(this);
            sf_c.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wbShow_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
