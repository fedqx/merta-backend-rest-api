using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class FlatInfo
    {
        [Key]
        public short FlatInfo_Id { get; set; }
        public string FlatInfo_Apartment { get; set; }
        public string FlatInfo_Room { get; set; }
        public string FlatInfo_Size { get; set; }
        public string FlatInfo_Front { get; set; }

        public short FlatInfoWorksite_Id { get; set; }
        public Worksite FlatInfoWorksite { get; set; }

    }
}
