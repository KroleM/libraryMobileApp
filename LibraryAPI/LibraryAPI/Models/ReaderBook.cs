using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class ReaderBook : BaseDatatable
	{
        public int ReaderId { get; set; }
        [ForeignKey(nameof(ReaderId))]
        public virtual Reader? Reader { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book? Book { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
