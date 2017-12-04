using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Category
    {
        private string id;
        private string name;

        public string getSetId
        {
            get { return id; }
            set { id = value; }
        }

        public string getSetName
        {
            get { return name; }
            set { name = value; }
        }
    }
}
