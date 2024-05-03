using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Food
    {
        private int _id;
        private string _name;
        private string _description;
        private decimal _price;
        private string _status;
        private int _categoryID;
        private DateTime _createdDate;
        public DTO_Food() {  }
        public DTO_Food(int id, string name, string description,string status,decimal price,int categoryID, DateTime createdDate)
        {
            _id = id;
            _name = name;
            _description = description;
            _status = status;
            _price = price;
            _categoryID = categoryID;
            _createdDate = createdDate;
        }
        public int ID
        { get { return _id; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int Category
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public DateTime CreatedDate
        {
            get { return _createdDate; }

            set { _createdDate = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
