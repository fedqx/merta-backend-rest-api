using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Image
    {
        [Key]
        public short Image_Id { get; set; }
        public string Image_Url { get; set; }
        public string ImageRaw_Url { get; set; }
        public short ImageWorksite_Id { get; set; }
        public Worksite ImageWorksite { get; set; }
    }
}
