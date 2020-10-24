using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.AutoMapper.Resources
{
    class CategoryResource
    {
    }

    public class CategoryCreateDto
    {
        public string Category_Tag { get; set; }
    }
    public class CategoryGetDto
    {
        public string Category_Tag { get; set; }
    }
}
