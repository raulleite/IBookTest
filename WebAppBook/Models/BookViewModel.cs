using DomainBook.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebAppBook.Models
{
    public class BookViewModel : BaseViewModel<Book>
    {
        [Required]
        [Display(Name = "Id")]
        public int id { get; set; }
        [Required]
        [Display(Name = "ISBN")]
        [StringLength(13, ErrorMessage = "ISBN não pode ter mais que 13 caracteres.")]
        public string isbn { get; set; }
        [Required]
        [Display(Name = "Título")]
        [StringLength(80, ErrorMessage = "Título não pode ter mais que 80 caracteres.")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Autor")]
        [StringLength(80, ErrorMessage = "Autor não pode ter mais que 80 caracteres.")]
        public string author { get; set; }
        [Required]
        [Display(Name = "Editora")]
        [StringLength(60, ErrorMessage = "Editora não pode ter mais que 60 caracteres.")]
        public string publisher { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [StringLength(150, ErrorMessage = "Sinopse não pode ter mais que 150 caracteres.")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Sinopse")]
        [DataType(DataType.MultilineText)]
        [StringLength(450, ErrorMessage = "Sinopse não pode ter mais que 450 caracteres.")]
        public string synopsis { get; set; }

        public BookViewModel()
        {

        }

        public BookViewModel(Book book)
        {
            if (book != null)
                this.Load(book);
        }
    }
}