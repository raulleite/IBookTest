using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainBook.Entity
{
    
    [Table("Book")]
    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(13)]
        public string isbn { get; set; }
        [MaxLength(80)]
        public string title { get; set; }
        [MaxLength(80)]
        public string author { get; set; }
        [MaxLength(60)]
        public string publisher { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        [MaxLength(450)]
        public string synopsis { get; set; }
    }
}
