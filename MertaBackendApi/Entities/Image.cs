using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Image
    {
        [Key]
        public short Image_Id { get; set; }
        public string Image_Name { get; set; }
        [NotMapped]
        public string Image_Source { get; set; }
        [NotMapped]
        public IFormFile Image_File { get; set; }

        public short ImageWorksite_Id { get; set; }
        public Worksite ImageWorksite { get; set; }
    }
}
