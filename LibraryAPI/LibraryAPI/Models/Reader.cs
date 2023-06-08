using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Reader : BaseDatatable
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
		[Column(TypeName = "DATE")]
		public DateTime? BirthDate { get; set; }
		public string Email { get; set; }
		public virtual ICollection<Book>? Wishlist { get; set; }
		public virtual ICollection<ReaderBook>? ReaderBooks { get; set; }	// kolekcja do wypożyczeń
		public virtual ICollection<ReaderBookScore>? ReaderBookScores { get; set; }	// odwołanie do tabeli z ocenami książek
        public virtual ICollection<Book>? ScoredBooks { get; set; }			// książki ocenione
        //public virtual ICollection<Author>? FavouriteAuthors { get; set; }
    }
}
