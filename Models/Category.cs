using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectIRIMIA.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
       
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please write a category")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please select a date and time")]
        public DateTime DateCreation { get; set; }

        public List<Product>? Products { get; set; }
    }
}
