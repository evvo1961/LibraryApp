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
        public string? ISBN { get; set; }        
    }
}
