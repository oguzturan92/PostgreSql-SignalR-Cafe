using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.DAL.Entities;

namespace KlassyCafePostgreSql.Dtos.CategoryDtos
{
    public class HomeResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryName { get; set; }
        public int CategoryRow { get; set; }
        public bool CategoryApproval { get; set; }
        public List<Product> Products { get; set; }
    }
}