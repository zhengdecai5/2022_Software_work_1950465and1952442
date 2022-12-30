using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace UI
{
    class DbConnection            //数据库连接类
    {
        public static SqlConnection conn = new SqlConnection();
        static DbConnection() 
        {
            string path = Application.StartupPath;
            try
            {
                StreamReader sr = new StreamReader(path + "\\config1.txt");
                string str = sr.ReadLine();
                conn.ConnectionString = str;
                sr.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "读数据库连接配置文件"); }
        }
        public static DataSet DataSerch(string sql)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
            return ds;
        }
    }

}

