using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryName { get; set; }
        public int CategoryRow { get; set; }
        public bool CategoryApproval { get; set; }
        public List<Product> Products { get; set; }
    }
}