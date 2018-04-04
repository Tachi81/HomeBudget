using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class Category
    {
        public int Category_Id { get; set; }
        public virtual List<SubCategory> Subcategories { get; set; }
    }
}