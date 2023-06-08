using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class ReaderBookScore
	{
		public int ReaderId { get; set; }
		[ForeignKey(nameof(ReaderId))]
		public virtual Reader? Reader { get; set; }
		public int BookId { get; set; }
		[ForeignKey(nameof(BookId))]
		public virtual Book? Book { get; set; }
		public int Score { get; set; }  // ocena książki według czytelnika (np. 0-10)
	}
}
