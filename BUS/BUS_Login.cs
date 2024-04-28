using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Login
    {
        DAO_Login DAOLogin = new DAO_Login();
        public bool isAdmin(string account,string password)
        {
            return DAOLogin.roleOfInput(account, password)=="Admin";
        }
        public bool isMember(string account, string password)
        {
            return DAOLogin.roleOfInput(account, password) == "Member";
        }
        public bool haveRole(string account, string password)
        {
            return DAOLogin.roleOfInput(account, password) == "Admin" || DAOLogin.roleOfInput(account, password) == "Member";
        }
    }
}
