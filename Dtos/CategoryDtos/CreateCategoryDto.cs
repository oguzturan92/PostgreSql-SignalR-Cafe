using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryImage { get; set; }
        public string CategoryName { get; set; }
        public int CategoryRow { get; set; }
        public bool CategoryApproval { get; set; }
    }
}