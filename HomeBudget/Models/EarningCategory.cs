using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class EarningCategory 
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<EarningSubCategory> Subcategories { get; set; }
    }
}