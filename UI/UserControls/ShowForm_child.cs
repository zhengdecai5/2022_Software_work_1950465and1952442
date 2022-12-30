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
using System.Data.SqlClient;

namespace UI.UserControls
{
    public partial class ShowForm_child : Form
    {
        ShowForm sf;
        public ShowForm_child(ShowForm parent)
        {
            InitializeComponent();
            sf = parent;
        }

        private void ShowForm_child_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLatMax.Text == "" || txtLatMin.Text == "" || txtLonMax.Text == "" || txtLonMin.Text == "" || cmbMonth.Text == "")
            {
                MessageBox.Show("各项数据都不能为空");
            }
            else
            {
                string Month = cmbMonth.Text;
                string LonMin = txtLonMin.Text;
                string LonMax = txtLonMax.Text;
                string LatMin = txtLatMin.Text;
                string LatMax = txtLatMax.Text;
                string sql = "select 参考位置,经度,纬度,深度,震级,发震时刻 from Table1 where month(发震时刻)=" + Month + "and 经度 between " + LonMin + "and " + LonMax + "and 纬度 between " + LatMin + "and " + LatMax;
                SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    DbConnection.conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    sf.listView1.Items.Clear();
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
                        sf.listView1.Items.Add(li);
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DbConnection.conn.Close();
                }
                this.Hide();
            }
        }

        private void txtLonMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool handle = false ;
           //允许输入数字、小数点、删除键和负号
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                handle= true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if ((sender as TextBox).Text != "")
                {
                    handle = true;
                }
            }
            //小数点只能输入一次
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                handle = true;
            }
            //第一位不能为小数点
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                handle = true;
            }
            //第一位是0，第二位必须为小数点
            if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            {
                handle = true;
            }
            //第一位是负号，第二位不能为小数点
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                handle = true;
            }
            e.Handled = handle;
        }
    }
}
