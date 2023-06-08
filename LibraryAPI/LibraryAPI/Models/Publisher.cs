namespace LibraryAPI.Models
{
	public class Publisher : DictionaryTable
	{
        public string? PhoneNumber { get; set; }
		public virtual ICollection<Book>? Books { get; set; }
	}
}
