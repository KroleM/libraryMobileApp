namespace LibraryAPI.Models
{
	public class Category : DictionaryTable
	{
		public virtual ICollection<Book>? Books { get; set; }
	}
}
