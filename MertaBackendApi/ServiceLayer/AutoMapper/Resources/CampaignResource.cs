using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.AutoMapper.Resources
{
    class CampaignResource
    {

    }
    
    public class CampaignCreateDto
    {
        public short Campaign_Id { get; set; }
        public string Campaign_Tag { get; set; }
        public DateTime Campaign_FDate { get; set; }
        public string Campaign_ImageUrl { get; set; }
        public short CampaignWorksite_Id { get; set; }
    }

    public class CampaignGetDto
    {
        public short Campaign_Id { get; set; }
        public string Campaign_Tag { get; set; }
        public DateTime Campaign_FDate { get; set; }
        public bool Campaign_Stage { get; set; }
        public string Campaign_ImageUrl { get; set; }
        public short CampaignWorksite_Id { get; set; }
    }
}
