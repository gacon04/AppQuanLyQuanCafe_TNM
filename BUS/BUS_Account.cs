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
using System.Security.Cryptography;
namespace BUS
{
    public class BUS_Account
    {
        public string HashPassword(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        DAO_Account DAOAccount = new DAO_Account();
        public DataTable getAccountTable(string status)
        {
            return DAOAccount.getAccountTable(status);
        }
        public bool existAccount(int id, string account)
        {
            return DAOAccount.existAccount(id,account);
        }
        public bool addAccount(DTO_Account account)
        {
            DTO_Account ano = account;
            ano.Password = HashPassword(ano.Password);
            return DAOAccount.addAccount(ano);
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
            DTO_Account ano = account;
            ano.Password= HashPassword(ano.Password);
            return DAOAccount.updateAccount(ano);
        }
        public bool isAdmin(string account, string password)
        {
            string hashPass = HashPassword(password);
            return DAOAccount.roleOfInput(account, hashPass) == "Admin";
        }
        public bool isMember(string account, string password)
        {
            string hashPass = HashPassword(password);
            return DAOAccount.roleOfInput(account,hashPass ) == "Member";
        }
        public bool haveRole(string account, string password)
        {
            string hashPass = HashPassword(password);
            return DAOAccount.roleOfInput(account, hashPass) != "";
        }
        public int getAccountIDByUserName(string userName)
        {
            return DAOAccount.getAccountID(userName);
        }
    }
}
