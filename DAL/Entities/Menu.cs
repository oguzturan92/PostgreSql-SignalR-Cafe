using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.DAL.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuImage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MenuPrice { get; set; }
        public string MenuTitle { get; set; }
        public string MenuSubTitle { get; set; }
        public int MenuRow { get; set; }
        public bool MenuApproval { get; set; }
    }
}