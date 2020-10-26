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
        public string Category_Tag { get; set; }
    }
}
