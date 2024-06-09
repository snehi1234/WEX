using System.ComponentModel.DataAnnotations;

namespace WexAssessmentApi.Models
{
    public class Product : IIdentifiable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "StockQuantity must be a non-negative integer")]
        public int StockQuantity { get; set; }
    }
}
