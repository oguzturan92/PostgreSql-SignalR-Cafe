using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.BannerDtos
{
    public class CreateBannerDto
    {
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerImage { get; set; }
        public int BannerRow { get; set; }
        public bool BannerApproval { get; set; }
    }
}