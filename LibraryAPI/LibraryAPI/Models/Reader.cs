using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Reader : BaseDatatable
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public string? Nick { get; set; }
        public string? Password { get; set; }
		[Column(TypeName = "DATE")]
		public DateTime? BirthDate { get; set; }
		public string? Email { get; set; }
		public virtual ICollection<Author>? FavouriteAuthors { get; set; }
		public virtual ICollection<ReaderBook>? ReaderBooks { get; set; }
	}
}
