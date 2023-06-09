using LibraryMobile.Helpers;
using LibraryMobile.Service.Reference;
using LibraryMobile.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMobile.Services
{
	public class ReaderDataStore : AListDataStore<Reader>
	{
		public ReaderDataStore()
			: base()
		{
		}
		public override async Task<Reader> AddItemToService(Reader item)
		{
			return await _service.ReaderPOSTAsync(item);
		}

		public override async Task<bool> DeleteItemFromService(Reader item)
		{
			return await _service.ReaderDELETEAsync(item.Id).HandleRequest();
		}

		public override async Task<Reader> Find(Reader item)
		{
			return await _service.ReaderGETAsync(item.Id);
		}

		public override async Task<Reader> Find(int id)
		{
			return await _service.ReaderGETAsync(id);
		}

		public override async Task RefreshListFromService()
		{
			items = _service.ReaderAllAsync().Result.ToList();
		}

		public override async Task<bool> UpdateItemInService(Reader item)
		{
			return await _service.ReaderPUTAsync(item.Id, item).HandleRequest();
		}
	}
}
