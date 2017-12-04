using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class User
    {
        private string id;
        private string name;
        private string mail;
        private string password;


        public string getSetId
        {
            get { return id; }
            set { id = value; }
        }

        public string getSetName {
            get{return name;}
            set {name = value;}
        }
        public string getSetMail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string getSetPassword
        {
            get { return password; }
            set { password = value; }
        }
    }
}
