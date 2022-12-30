using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.UserManager
{
     public class User 
    {
        public string account;
        public string root;

        public User(string account,string root)
        {
            this.account = account;
            this.root = root;

        }
        public string getAccount()
        {
            return account;
        }

    }
}
