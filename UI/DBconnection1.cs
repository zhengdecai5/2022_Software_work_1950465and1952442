using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace UI
{
    class DBconnection1
    {
        public static SqlConnection conn = new SqlConnection();
        static DBconnection1()
        {
            string path = Application.StartupPath;
            try
            {
                StreamReader sr = new StreamReader(path + "\\config.txt");
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
