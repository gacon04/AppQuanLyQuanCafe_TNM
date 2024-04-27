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
        public DataTable getAccountTable()
        {
            return DAOAccount.getAccountTable();
        }
        public bool addAccount(DTO_Account account)
        {
            return DAOAccount.addAccount(account);
        }
        public bool removeAccount(int account_ID)
        {
            return DAOAccount.deleteAccount(account_ID);
        }
        public bool canGetAccountByID(int account_ID)
        {
            return DAOAccount.getAccountByID(account_ID)!=null;
        }
        public DTO_Account getAccountByID(int account_ID)
        {
            return DAOAccount.getAccountByID(account_ID);
        }
    }
}
