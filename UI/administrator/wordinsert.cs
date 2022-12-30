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

namespace UI.administrator
{
    public partial class wordinsert : Form
    {
        public wordinsert()
        {
            InitializeComponent();
        }
        DataSet dsword = new DataSet();
        DataSet dsY = new DataSet();
        DataSet dsX = new DataSet();
        string index = "0";
        private void wordinsert_Load(object sender, EventArgs e)
        {
            string sql = "select * from fanyibiao";
            dsword = DbConnection.DataSerch(sql);
            sql = "select xingjinbiao.pinxie ,xingnum,num from xingjinbiao,fanyibiao where xingjinbiao.pinxie = fanyibiao.pinxie ";
            dsX = DbConnection.DataSerch(sql);
            sql = "select pinxie ,y.fanyi,yinum from fanyibiao as f,yijinbiao as y where f.fanyi = y.fanyi; ";
            dsY = DbConnection.DataSerch(sql);
            dataGridView3.DataSource = dsword.Tables[0];
            dataGridView2.DataSource = dsX.Tables[0];
            dataGridView1.DataSource = dsY.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtexample.Text!=""&&txtindex.Text!=""&&txtdiffcult.Text!=""&&txtmean.Text!=""&&txtword.Text!=""&&txtXnum.Text!=""&&txtYnum.Text!="")
            {
                string sql = "insert into fanyibiao values('" + txtindex.Text + "','" + txtword.Text + "','"+txtmean.Text+"','"+txtdiffcult.Text+"','"+txtexample.Text + "')";
                string sqly = "insert into yijinbiao values('" + txtmean.Text + "','" + txtYnum.Text  + "')";
                string sqlx= "insert into xingjinbiao values('" + txtword.Text + "','" + txtXnum.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
                SqlCommand cmdx = new SqlCommand(sqlx, DbConnection.conn);
                SqlCommand cmdy = new SqlCommand(sqly, DbConnection.conn);
                try
                {
                    DbConnection.conn.Open();
                    cmd.ExecuteNonQuery();
                    cmdx.ExecuteNonQuery();
                    cmdy.ExecuteNonQuery();
                    MessageBox.Show("成功插入");
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
            else
            {
                MessageBox.Show("请检查相关的内容是否为空");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
