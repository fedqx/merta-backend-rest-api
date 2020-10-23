using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.AutoMapper.Resources
{
    class FlatInfoResource
    {
    }

    public class FlatInfoCreateDto
    {
        public string FlatInfo_Apartment { get; set; }
        public string FlatInfo_Room { get; set; }
        public string FlatInfo_Size { get; set; }
        public string FlatInfo_Front { get; set; }
        public short FlatInfoWorksite_Id { get; set; }
    }

    public class FlatInfoGetDto
    {
        public string FlatInfo_Apartment { get; set; }
        public string FlatInfo_Room { get; set; }
        public string FlatInfo_Size { get; set; }
        public string FlatInfo_Front { get; set; }
        public short FlatInfoWorksite_Id { get; set; }
    }
}
