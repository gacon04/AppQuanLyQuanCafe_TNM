using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class BUS_Account
    {
        DAO_Account DAOAccount = new DAO_Account();
        public DataTable getAccountTable(string status)
        {
            return DAOAccount.getAccountTable(status);
        }
        public bool addAccount(DTO_Account account)
        {
            return DAOAccount.addAccount(account);
        }
        public bool deleteAccount(int account_ID,string role)
        {
            return DAOAccount.deleteAccount(account_ID,role);
        }
        public bool canGetAccountByID(int account_ID)
        {
            return DAOAccount.getAccountByID(account_ID)!=null;
        }
        public DTO_Account getAccountByID(int account_ID)
        {
            return DAOAccount.getAccountByID(account_ID);
        }
        public bool updateAccount(DTO_Account account)
        {
            return DAOAccount.updateAccount(account);
        }
       
    }
}
