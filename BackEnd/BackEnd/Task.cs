using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Task
    {
        private string id;
        private int authorId;
        private string name;
        private string description;
        private string state;

        public string getSetId
        {
            get { return id; }
            set { id = value; }
        }

        public int getSetAuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }
        public string getSetName
        {
            get { return name; }
            set { name = value; }
        }
        public string getSetDescription
        {
            get { return description; }
            set { description = value; }
        }
        public string getSetState
        {
            get { return state; }
            set { state = value; }
        }

    }
}
