using LibraryMobile.Helpers;
using LibraryMobile.Service.Reference;
using LibraryMobile.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMobile.Services
{
	public class PublisherDataStore : AListDataStore<Publisher>
	{
		public PublisherDataStore()
			: base()
		{
		}
		public override async Task<Publisher> AddItemToService(Publisher item)
		{
			return await _service.PublisherPOSTAsync(item);
		}

		public override async Task<bool> DeleteItemFromService(Publisher item)
		{
			return await _service.PublisherDELETEAsync(item.Id).HandleRequest();
		}

		public override async Task<Publisher> Find(Publisher item)
		{
			return await _service.PublisherGETAsync(item.Id);
		}

		public override async Task<Publisher> Find(int id)
		{
			return await _service.PublisherGETAsync(id);
		}

		public override async Task RefreshListFromService()
		{
			items = _service.PublisherAllAsync().Result.ToList();
		}

		public override async Task<bool> UpdateItemInService(Publisher item)
		{
			return await _service.PublisherPUTAsync(item.Id, item).HandleRequest();
		}
	}
}
