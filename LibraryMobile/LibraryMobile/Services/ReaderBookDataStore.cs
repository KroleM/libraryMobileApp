using LibraryMobile.Helpers;
using LibraryMobile.Service.Reference;
using LibraryMobile.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMobile.Services
{
	public class ReaderBookDataStore : AListDataStore<ReaderBook>
	{
		public ReaderBookDataStore()
			: base()
		{
		}
		public override async Task<ReaderBook> AddItemToService(ReaderBook item)
		{
			return await _service.ReaderBookPOSTAsync(item);
		}

		public override async Task<bool> DeleteItemFromService(ReaderBook item)
		{
			return await _service.ReaderBookDELETEAsync(item.Id).HandleRequest();
		}

		public override async Task<ReaderBook> Find(ReaderBook item)
		{
			return await _service.ReaderBookGETAsync(item.Id);
		}

		public override async Task<ReaderBook> Find(int id)
		{
			return await _service.ReaderBookGETAsync(id);
		}

		public override async Task RefreshListFromService()
		{
			items = _service.ReaderBookAllAsync().Result.ToList();
		}

		public override async Task<bool> UpdateItemInService(ReaderBook item)
		{
			return await _service.ReaderBookPUTAsync(item.Id, item).HandleRequest();
		}
	}
}
