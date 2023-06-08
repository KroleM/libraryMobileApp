using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Author : DictionaryTable
	{
        public string? FirstName1 { get; set; }
        public string? FirstName2 { get; set; }
        public string? LastName { get; set; }
		[Column(TypeName = "DATE")]
		public DateTime BirthDate { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
        public virtual ICollection<Reader>? Readers { get; set; } // Czytelnicy, którzy mają autora "w ulubionych" - można policzyć ilu ich jest.
    }
}
