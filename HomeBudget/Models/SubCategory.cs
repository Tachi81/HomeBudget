namespace HomeBudget.Models
{
    public class SubCategory
    {
        public string Id { get; set; }
        public string SubCategoryName { get; set; }
        public  virtual Category Category { get; set; }
    }
}