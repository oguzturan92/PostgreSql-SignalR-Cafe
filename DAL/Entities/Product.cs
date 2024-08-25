using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.DAL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSubTitle { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductRow { get; set; }
        public bool ProductApproval { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}