using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.MenuDtos
{
    public class UpdateMenuDto
    {
        public int MenuId { get; set; }
        public string MenuImage { get; set; }
        public decimal MenuPrice { get; set; }
        public string MenuTitle { get; set; }
        public string MenuSubTitle { get; set; }
        public int MenuRow { get; set; }
        public bool MenuApproval { get; set; }
    }
}