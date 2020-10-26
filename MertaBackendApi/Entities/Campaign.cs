using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Entities
{
    public class Campaign
    {
        [Key]
        public short Campaign_Id { get; set; }
        public string Campaign_Tag { get; set; }
        public DateTime Campaign_FDate { get; set; }
        public bool Campaign_Stage { get; set; }
        public string Campaign_ImageUrl { get; set; }
        public short CampaignWorksite_Id { get; set; }
        public Worksite CampaignWorksite { get; set; }
    }
}
