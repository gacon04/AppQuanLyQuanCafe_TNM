using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Table
    {
        private int _id;
        private string _name;
        private string _status;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DTO_Table() { }
        public DTO_Table(int id,string name,string status)
        {
            _id = id;
            _name = name;
            _status = status;
        }
    }
}
