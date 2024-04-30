using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Home
    {
        DAO_Home DAO_Home = new DAO_Home();
        public int processLblCountAdmin()
        {
            return DAO_Home.countAdminAccount();
        }
        public int processLblCountMember()
        {
            return DAO_Home.countMemberAccount();
        }
    }
}
