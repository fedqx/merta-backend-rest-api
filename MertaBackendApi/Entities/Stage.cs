using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Stage
    {
        [Key]
        public short Stage_Id { get; set; }
        public string Stage_Tag { get; set; }
        public IEnumerable<Worksite> StageWorksites { get; set; }
    }
}
