using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.DateTime)]
        //[Display(Name = "Choose Date and Time")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        //public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100,MinimumLength = 5)]
        [Required(ErrorMessage="Please enter the title of  your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 10)]
        public string Description {  get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter total pages")]
        [Display(Name = "Total book Pages")]
        public int? TotalPages {  get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set ; }
    }
}
