using LibraryMobile.Helpers;
using LibraryMobile.Service.Reference;
using LibraryMobile.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMobile.Services
{
	public class BookDataStore : AListDataStore<Book>
	{
		public BookDataStore()
			: base()
		{
		}
		public override async Task<Book> AddItemToService(Book item)
		{
			return await _service.BookPOSTAsync(item);
		}

		public override async Task<bool> DeleteItemFromService(Book item)
		{
			return await _service.BookDELETEAsync(item.Id).HandleRequest();
		}

		public override async Task<Book> Find(Book item)
		{
			return await _service.BookGETAsync(item.Id);
		}

		public override async Task<Book> Find(int id)
		{
			return await _service.BookGETAsync(id);
		}

		public override async Task RefreshListFromService()
		{
			items = _service.BookAllAsync().Result.ToList();
		}

		public override async Task<bool> UpdateItemInService(Book item)
		{
			return await _service.BookPUTAsync(item.Id, item).HandleRequest();
		}
	}
}
