using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class EarningSubCategory 
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        [ForeignKey("EarningCategory")]
        public int EarningCategoryId { get; set; }

        public virtual EarningCategory EarningCategory { get; set; }
    }
}