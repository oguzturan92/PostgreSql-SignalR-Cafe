using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.DAL.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public bool TableIsFull { get; set; }
        public bool TableApproval { get; set; }
        public int TableRow { get; set; }
    }
}