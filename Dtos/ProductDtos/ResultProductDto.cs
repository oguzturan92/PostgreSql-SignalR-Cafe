using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.DAL.Entities;

namespace KlassyCafePostgreSql.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSubTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductRow { get; set; }
        public bool ProductApproval { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}