using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Category
    {
        private int _ID;
        private String _Name;
        private String _Description;
        private DateTime _CreatedDate;
        public int ID { get { return _ID; } }
        public string Name { 
            get { return _Name; } 
            set { _Name = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        DTO_Category() { }
        DTO_Category(int ID, string name, string description, DateTime date)
        {
            _ID = ID;
            _Name = name;
            _Description = description;
            _CreatedDate = date;
        }


    }
    
}
