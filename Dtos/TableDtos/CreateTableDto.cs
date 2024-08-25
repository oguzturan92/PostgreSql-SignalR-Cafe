using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.TableDtos
{
    public class CreateTableDto
    {
        public string TableName { get; set; }
        public bool TableIsFull { get; set; }
        public bool TableApproval { get; set; }
        public int TableRow { get; set; }
    }
}