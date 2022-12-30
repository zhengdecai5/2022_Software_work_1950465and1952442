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
using System.Data.SqlClient;

namespace UI.administrator
{
    public partial class Rockcontrol : Form
    {
        public Rockcontrol()
        {
            InitializeComponent();
        }
        string account = LoginForm.account;
        string index="1";
        DataSet ds = new DataSet();
        private void Rockcontrol_Load(object sender, EventArgs e)
        {
            string sql = "select* from rock";
            ds = DBconnection1.DataSerch(sql);
            dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update  rock set 岩石名称='"+txtname.Text+"',岩石介绍='"+txtrock.Text+"' where 编号= '"+index+"'";
            SqlCommand cmd = new SqlCommand(sql, DBconnection1.conn);
            try
            {
                DBconnection1.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("更改成功");
                DBconnection1.conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            int length = ds.Tables[0].Rows.Count;
            if (row.Index > length - 1)
            {
                MessageBox.Show("选择行超出限度");
            }
            else
            {
                index= ds.Tables[0].Rows[row.Index]["编号"].ToString();
                txtname.Text = ds.Tables[0].Rows[row.Index]["岩石名称"].ToString();
                txtrock.Text = ds.Tables[0].Rows[row.Index]["岩石介绍"].ToString();
            }
          
        }
    }
}
