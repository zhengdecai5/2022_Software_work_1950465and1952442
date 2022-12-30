using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using System.IO;

namespace UI
{
    class SSH
    {
        //连接服务器
        private static readonly string hst = "124.222.167.88";
        private static readonly string usr = "root";
        private static readonly string pwd = "Dlx1952442";
        public static ConnectionInfo ConnNfo = new ConnectionInfo(hst, 22, usr,
             new AuthenticationMethod[]{
                new PasswordAuthenticationMethod(usr,pwd),
             }
          );
        public static string ExecCommand(string command)
        {
            string result;
            using (var client = new SshClient(hst, usr, pwd))
            {
                try
                {
                    client.Connect();
                    client.RunCommand(command);
                    result = "OK";

                }
                catch (Exception e1)
                {
                    result = e1.Message;
                }
                client.Disconnect();
                return result;
            }
        }
        //从服务器上上传文件
        public static void Upload(string uploadpath, string filename = "upload.su")
        {
            using (var sftp = new SftpClient(ConnNfo))
            {
                string uploadfn = uploadpath;
                string[] sl = uploadfn.Split('\\');
                uploadfn = sl[sl.Length - 1];
                sftp.Connect();
                sftp.ChangeDirectory("test");
                using (var uplfileStream = File.OpenRead(uploadpath))
                {
                    sftp.UploadFile(uplfileStream, filename, true);
                }
                sftp.Disconnect();
            }
        }
        //从服务器上下载文件
        public static void Download(string downloadfilepath, string savefilepath)
        {
            using (var sftp = new SftpClient(ConnNfo))
            {
                string downloadfn = downloadfilepath;
                sftp.Connect();
                sftp.ChangeDirectory("test");
                Stream downloadStream = new FileStream(savefilepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                sftp.DownloadFile(downloadfn, downloadStream);
                downloadStream.Dispose();
                downloadStream.Close();
                sftp.Disconnect();
                sftp.Dispose();
            }
        }
    }
}



