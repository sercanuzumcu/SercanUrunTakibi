using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class SubCategory : BaseClass
    {
        //Kılçık -> Standart Kılçık <-- SubCategory
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public String SubCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}