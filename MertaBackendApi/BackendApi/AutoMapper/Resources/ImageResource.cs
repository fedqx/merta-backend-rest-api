using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApi.AutoMapper.Resources
{
    public class ImageResource
    {
    }
    public class ImageCreateDto
    {
        [Required]
        public string Image_Name { get; set; }
        [Required]
        public short ImageWorksite_Id { get; set; }
        [Required]
        public IFormFile Image_File { get; set; }

    }
    
    public class ImageGetDto
    {
        public string Image_Name { get; set; }
        public short ImageWorksite_Id { get; set; }
        public string Image_Source { get; set; }
    }
}
