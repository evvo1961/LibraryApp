using System.ComponentModel.DataAnnotations;

namespace LibraryAppUI.Models
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }
       
        [Display(Name = "Edition Number")]
        public int? EditionNumber { get; set; }
        [Required]
        [RegularExpression("^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\d-]+$", ErrorMessage = "ISBN number must be properly formatted.")]
        public string? ISBN { get; set; }        
    }
}
