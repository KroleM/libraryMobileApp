using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class ReaderAuthor
	{
		public int ReaderId { get; set; }
		[ForeignKey(nameof(ReaderId))]
		public virtual Reader? Reader { get; set; }
		public int AuthorId { get; set; }
		[ForeignKey(nameof(AuthorId))]
		public virtual Author? Author { get; set; }
        public double Rating { get; set; }	// ocena autora według czytelnika
    }
}
