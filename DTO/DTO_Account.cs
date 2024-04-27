using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Account //Lớp trung gian nhằm tương tác với bảng Account trên database
    {
        private int _ID;
        private String _Name;
        private String _CCCD_Num;
        private String _PhoneNumber;
        private String _Sex;
        private String _Address;
        private String _Role;
        private String _Account;
        private String _Password;
        private String _Status;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public String CCCD_Num
        {
            get { return _CCCD_Num; }
            set { _CCCD_Num = value; }
        }
        public String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public String Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public String Account
        {
            get { return _Account; }
            set { _Account = value; }
        }
        public String Role
        {
            get { return _Role; }
            set { _Role = value; }
        }
        public DTO_Account(){}
        public DTO_Account(int id, string name, string cccd_Num, string phoneNumber, string sex, string address, string role, string account, string password, string status)
        {
            _ID = id;
            _Name = name;
            _CCCD_Num = cccd_Num;
            _PhoneNumber = phoneNumber;
            _Sex = sex;
            _Address = address;
            _Role = role;
            _Account = account;
            _Password = password;
            _Status = status;
        }
    }
}
