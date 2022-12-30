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
using System.IO;
namespace UI.UserControls
{
    public partial class Word : Form
    {
        Form2 f2;
        public Word(Form2 parent)
        {
            InitializeComponent();
            f2 = parent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        DataSet ds = new DataSet();
        DataSet dsAccount = new DataSet();
        string path = Application.StartupPath;//读图片路径
        string picture = "002";//收藏功能图片编号
        int index = 0;//记录单词的位置
        string account = LoginForm.account;//用户名
        private void Word_Load(object sender, EventArgs e)
        {
            f2.labelName.Text = "当前浏览：专业单词";
            string sql = "select * from fanyibiao";
            ds = DbConnection.DataSerch(sql);
            labelword.Text = ds.Tables[0].Rows[index]["pinxie"].ToString();
            txtexample.Text= ds.Tables[0].Rows[index]["liju"].ToString();
            picture = Iscollection(ds.Tables[0].Rows[index]["num"].ToString());
            btnStar.Image = Image.FromFile(path + "\\picture\\" + picture + ".png");

        }    
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(picture=="001")//加入收藏
            {
                string num= ds.Tables[0].Rows[index]["num"].ToString();
                string sql = "insert into shoucangbiao values ('" + num + "','" + account + "')";
                SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
                DbConnection.conn.Open();
                cmd.ExecuteNonQuery();
                DbConnection.conn.Close();
                picture = "002";
            }
            else//取消收藏
            {
                string num = ds.Tables[0].Rows[index]["num"].ToString();
                string sql = "delete from shoucangbiao where zhanghao='"+account+"' and num='"+num+"'";
                SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
                DbConnection.conn.Open();
                cmd.ExecuteNonQuery();
                DbConnection.conn.Close();
                picture = "001";
            }
            btnStar.Image = Image.FromFile(path + "\\picture\\" + picture + ".png");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSynonym_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtWord.Text=="")
            {
                txtWord.Text = ds.Tables[0].Rows[index]["fanyi"].ToString();//显示单词意思.
                //显示易混淆单词
                textBox1.Text = mean(labelword.Text);
                //显示意近词
                txtSynonym.Text = body(txtWord.Text);
                btnword.Text = "下一个";

            }
            else if(txtWord.Text!=""&&index+1<ds.Tables[0].Rows.Count)//给出后续单词
            {
                txtSynonym.Text = "";
                txtWord.Text = "";
                textBox1.Text = "";
                index = index + 1;
                labelword.Text = ds.Tables[0].Rows[index]["pinxie"].ToString();
                txtexample.Text = ds.Tables[0].Rows[index]["liju"].ToString();
                btnword.Text = "展示意思";
                picture = Iscollection(ds.Tables[0].Rows[index]["num"].ToString());
                btnStar.Image = Image.FromFile(path + "\\picture\\" + picture + ".png");
            }
            else//后续无单词，重新返回第一个
            {

                txtSynonym.Text = "";
                txtWord.Text = "";
                textBox1.Text = "";
                index = 0;
                labelword.Text = ds.Tables[0].Rows[index]["pinxie"].ToString();
                txtexample.Text = ds.Tables[0].Rows[index]["liju"].ToString();
                btnword.Text = "展示意思";
                picture = Iscollection(ds.Tables[0].Rows[index]["num"].ToString());
                btnStar.Image = Image.FromFile(path + "\\picture\\" + picture + ".png");
            }
        }
        DataSet dsCollection = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            if (btnhide.Text == "展示收藏")
            {
                dataGridView1.Visible = true;               
                string sql = "select pinxie as 拼写,fanyi as 翻译 from fanyibiao as f,shoucangbiao as s";
                sql += " where f.num = s.num and zhanghao = '" + account + "'";
                btnhide.Text = "隐藏收藏";
                dsCollection = DbConnection.DataSerch(sql);
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = dsCollection.Tables[0];
                dataGridView1.Rows[0].Selected = false;
            }
            else
            {
                dataGridView1.Visible = false;
                btnhide.Text = "展示收藏";
            }
        
        }
        public string Iscollection(string num )//判断用户是否收藏
        {
            string sql = "select * from fanyibiao as f,shoucangbiao as s";
            sql += " where f.num = s.num and zhanghao = '" + account + "'";
            sql += " and f.num='" + num + "'";
            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            
            try
            {
                DbConnection.conn.Open();
                SqlDataReader dbReader = cmd.ExecuteReader();
                if (!dbReader.HasRows)  // 如果查询结果集合为空，则不存在收藏
                {
                    return "001";   
                }
            }
            catch (SqlException ex)
            {
                string s = ex.Message;
                MessageBox.Show(s);
            }
            finally
            { DbConnection.conn.Close(); }
            return "002";
        }
        public string mean(string word) //返回单词的形近词
        {
            string txt="";
            string Sql = "select f.pinxie,fanyi from xingjinbiao as x,fanyibiao as f where x.pinxie = f.pinxie and ";
            Sql += " xingnum = (select xingnum from xingjinbiao where pinxie = '" + word + "')";
            Sql += "and xingnum != '9999' and f.pinxie != '" + word + "'";
            SqlCommand cmd = new SqlCommand(Sql, DbConnection.conn);
            cmd.CommandType = CommandType.Text;
            DbConnection.conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txt+= sdr["pinxie"].ToString();
                txt += ": ";
                txt += sdr["fanyi"].ToString();
                txt += Environment.NewLine;
            }
            sdr.Close();
            DbConnection.conn.Close();
            return txt;
        }
        public string body(string word) //返回单词的近义词
        {
            string txt = "";
            string sql = "select pinxie,y.fanyi from yijinbiao as y,fanyibiao as f ";
            sql += " where y.fanyi = f.fanyi and yinum = (select yinum from yijinbiao where fanyi = '" + txtWord.Text + "')";
            sql += " and yinum!=9999 and y.fanyi != '" + txtWord.Text + "'";
            SqlCommand sqcmd = new SqlCommand(sql, DbConnection.conn);
            sqcmd.CommandType = CommandType.Text;
            DbConnection.conn.Open();
            SqlDataReader rdr = sqcmd.ExecuteReader();
            while (rdr.Read())
            {
                txt += rdr["pinxie"].ToString();
                txt += ": ";
                txt += rdr["fanyi"].ToString();
                txt += Environment.NewLine;
            }
            rdr.Close();
            DbConnection.conn.Close();
            return txt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            int length = dsCollection.Tables[0].Rows.Count;
            if (row.Index > length - 1)
            {
                MessageBox.Show("选择行超出限度");
            }
            else
            {
                string sql = "select * from fanyibiao";
                string word = dsCollection.Tables[0].Rows[row.Index]["翻译"].ToString();
                int i = 0;
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["fanyi"].ToString() == word)
                    {
                        labelword.Text = ds.Tables[0].Rows[i]["pinxie"].ToString();
                        txtexample.Text = ds.Tables[0].Rows[i]["liju"].ToString();
                        txtSynonym.Text = body(word);
                        txtWord.Text = word;
                        textBox1.Text = mean(labelword.Text);
                        picture = Iscollection(ds.Tables[0].Rows[i]["num"].ToString());
                        btnStar.Image = Image.FromFile(path + "\\picture\\" + picture + ".png");
                    }
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "展示专业词")
            {
                dataGridView1.Visible = true;
                string sql = "select pinxie as 拼写,fanyi as 翻译 from fanyibiao where nanyidu=1";
                button1.Text = "隐藏专业词";
                dsCollection = DbConnection.DataSerch(sql);
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = dsCollection.Tables[0];
                dataGridView1.Rows[0].Selected = false;
            }
            else
            {
                dataGridView1.Visible = false;
                button1.Text = "展示专业词";
            }
        }
    }
}
