using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Admin
    {
        [Key]
        public short Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Password { get; set; }
        public string Admin_Email { get; set; }

        public string RefleshToken { get; set; }
        public DateTime ReflesTokenEndTime  { get; set; }
    }
}
