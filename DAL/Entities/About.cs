using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.DAL.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string AboutLink { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
        public string AboutImage3 { get; set; }
        public string AboutImage4 { get; set; }
    }
}