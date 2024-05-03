using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TableList
    {
        DAO_TableList DAO_TableList = new DAO_TableList();
        public DataTable getTableList(string status)
        {
            return DAO_TableList.getTableList(status);
        }
        public bool addTable(DTO_Table table)
        {
            return DAO_TableList.addTable(table);
        }
        public bool deleteTable(int table_id)
        {
            return DAO_TableList.deleteTable(table_id);
        }
        public bool updateTable(DTO_Table table)
        {
            return DAO_TableList.updateTable(table);
        }
        public bool existTableName(int id,string tableName)
        {
            return DAO_TableList.existTableName(id,tableName);
        }
    }
}
