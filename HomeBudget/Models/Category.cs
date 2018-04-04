using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SubCategory> Subcategories { get; set; }
    }
}