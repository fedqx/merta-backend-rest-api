using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApi.AutoMapper.Resources
{
    public class CategoryResource
    {
    }

    public class CategoryCreateDto
    {
        [Required]
        public string Category_Tag { get; set; }
    }
    public class CategoryGetDto
    {
        public short Category_Id { get; set; }
        public string Category_Tag { get; set; }
    }
}
