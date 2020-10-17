using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Category
    {
        [Key]
        public short Category_Id { get; set; }
        public string Category_Tag { get; set; }

        public IEnumerable<Worksite> CategoryWorksites { get; set; }
    }
}
