using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms2;
using UI.UserManager;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace UI.UserManager

{
    class UserManagerAction : DbConnection
    {
        public static User validUser(string account, string password)
        // 传递用户的登录帐号和密码，在登录窗体中输入得到
        {
            User user = null;
            string sql = "select * from yonghubiao where zhanghao='" + account
                           + "' and  mima='" + password + "'";  // 到用户表中查询
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                SqlDataReader dbReader = cmd.ExecuteReader();
                if (!dbReader.HasRows)  // 如果查询结果集合为空，则不存在该用户
                {
                    return null;   // 无登录的帐户和密码记录，登录失败，返回空用户
                }
                dbReader.Read();
                string root=dbReader["quanxian"].ToString();
                user = new User(account, root);
            }
            catch (SqlException ex)
            {
                string s = ex.Message;
                MessageBox.Show(s);
            }
            finally
            { conn.Close(); }
            //登录成功则传递用户信息
            return user;
        }
        public static bool newUser(string account)
        {
            bool Is = true;
            string sql = "select * from yonghubiao where zhanghao='" + account+"'";//查询用户
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                SqlDataReader dbReader = cmd.ExecuteReader();
                if(!dbReader.HasRows) //查询失败则表明该用户账号为新用户
                {
                    Is= false;
                }
            }
            catch (SqlException ex)
            {
                string s = ex.Message;
                MessageBox.Show(s);
            }
            finally
            { conn.Close(); }
            return Is;
        }
        public static void creatNewUser(string account,string passward)
        {
            string sql = "insert into yonghubiao values('" + account + "','" + passward + "','0"+"')"; //在表中插入新用户
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void changeUser(string account,string passward)
        {
            string sql="update yonghubiao set mima='"+passward+"' where zhanghao='"+account+"'"; //在表中更改密码
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
 }
