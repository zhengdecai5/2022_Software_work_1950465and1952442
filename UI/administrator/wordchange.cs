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
    public partial class wordchange : Form
    {
        public wordchange()
        {
            InitializeComponent();
        }
        DataSet dsword = new DataSet();
        DataSet dsY = new DataSet();
        DataSet dsX = new DataSet();
        string  index = "0";
        string translate = "";
        string word = "";
        private void wordchange_Load(object sender, EventArgs e)
        {
            string sql = "select * from fanyibiao";
            dsword = DbConnection.DataSerch(sql);
            sql = "select xingjinbiao.pinxie ,xingnum,num from xingjinbiao,fanyibiao where xingjinbiao.pinxie = fanyibiao.pinxie ";
            dsX = DbConnection.DataSerch(sql);
            sql = "select pinxie ,y.fanyi,yinum from fanyibiao as f,yijinbiao as y where f.fanyi = y.fanyi; ";
            dsY= DbConnection.DataSerch(sql);
            dataGridView3.DataSource = dsword.Tables[0];
            dataGridView2.DataSource = dsX.Tables[0];
            dataGridView1.DataSource = dsY.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update fanyibiao set pinxie='"+txtword.Text+"',fanyi='"+txtmean.Text+"',liju='"+txtexample.Text+"' where num='"+index+"'";
            string sqly="update yijinbiao set fanyi='"+txtmean.Text+"',yinum='"+txtYnum.Text+"' where fanyi='"+translate+"'";
            string sqlx = "update xingjinbiao set pinxie='" + txtword.Text + "',xingnum='" + txtXnum.Text + "' where pinxie='" + word + "'";
            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            SqlCommand cmdx = new SqlCommand(sqlx, DbConnection.conn);
            SqlCommand cmdy = new SqlCommand(sqly, DbConnection.conn);
            try
            {
                DbConnection.conn.Open();
                cmd.ExecuteNonQuery();
                cmdx.ExecuteNonQuery();
                cmdy.ExecuteNonQuery();
                MessageBox.Show("更改成功");
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView3.CurrentRow;
            int length = dsword.Tables[0].Rows.Count;
            if (row.Index > length - 1)
            {
                MessageBox.Show("选择行超出限度");
            }
            else
            {
                index = dsword.Tables[0].Rows[row.Index]["num"].ToString();
                txtword.Text = dsword.Tables[0].Rows[row.Index]["pinxie"].ToString();
                word = txtword.Text;
                txtmean.Text = dsword.Tables[0].Rows[row.Index]["fanyi"].ToString();
                translate = txtmean.Text;
                txtexample.Text = dsword.Tables[0].Rows[row.Index]["liju"].ToString();
                for(int i=0;i< dsY.Tables[0].Rows.Count;i++)
                {
                    if(txtmean.Text== dsY.Tables[0].Rows[i]["fanyi"].ToString())
                    {
                        txtYnum.Text = dsY.Tables[0].Rows[i]["yinum"].ToString();
                    }
                }
                for (int i = 0; i < dsX.Tables[0].Rows.Count; i++)
                {
                    if (index == dsX.Tables[0].Rows[i]["num"].ToString())
                    {
                        txtXnum.Text = dsX.Tables[0].Rows[i]["xingnum"].ToString();
                    }
                }


            }
        }
    }
}
