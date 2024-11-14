using System.ComponentModel.DataAnnotations;

namespace LibraryAppApi.Models
{
    public class Book
    {
        public int Id { get; set; }        
        public string? Title { get; set; }
        public string? Author { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }
        public int? EditionNumber { get; set; }        
        public string? ISBN { get; set; }        
    }
}
