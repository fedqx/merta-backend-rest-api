using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Worksite
    {
        [Key]
        public short Worksite_Id { get; set; }
        public string Worksite_Tag { get; set; }
        public string Worksite_City { get; set; }
        public string Worksite_Adress { get; set; }
        public DateTime Worksite_SDate { get; set; }
        public DateTime Worksite_FDate { get; set; }

        public short WorksiteStage_Id { get; set; }
        public Stage WorksiteStage { get; set; }
        public short WorksiteCategory_Id { get; set; }
        public Category WorksiteCategory { get; set; }

        public IEnumerable<Campaign> WorksiteCampaigns { get; set; }
        public IEnumerable<Image> WorksiteImages { get; set; }
        public IEnumerable<FlatInfo> WorksiteFlatInfos { get; set; }
    }
}
