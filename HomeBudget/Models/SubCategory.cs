using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBudget.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }
    }
}