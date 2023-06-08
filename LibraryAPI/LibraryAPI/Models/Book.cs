using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Book : DictionaryTable
	{
		// Tytuł należy wprowadzać w pole Name z DictionaryTable
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; } //unique? -> unique index
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public virtual Author? Author { get; set; }
		public int PublisherId { get; set; }
		[ForeignKey(nameof(PublisherId))]
		public virtual Publisher? Publisher { get; set; }
		public int CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
		public virtual Category? Category { get; set; }
		public virtual ICollection<ReaderBook>? ReaderBooks { get; set; }
	}
}
