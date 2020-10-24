using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.AutoMapper.Resources
{
    class ImageResource
    {
    }
    public class ImageCreateDto
    {
        public string Image_Url { get; set; }
        public string ImageRaw_Url { get; set; }
        public short ImageWorksite_Id { get; set; }

    }
    
    public class ImageGetDto
    {
        public string Image_Url { get; set; }
        public string ImageRaw_Url { get; set; }
        public short ImageWorksite_Id { get; set; }
    }
}
