using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectIRIMIA.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please write the title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please write the author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please select a date and time")]
        public DateTime CurrentDate { get; set; }


        public virtual Category? category { get; set; }
        public int CategoryId { get; set; }
        

    }
}
