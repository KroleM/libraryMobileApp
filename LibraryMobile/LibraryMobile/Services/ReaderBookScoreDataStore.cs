using LibraryMobile.Service.Reference;
using LibraryMobile.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMobile.Services
{
	public class ReaderBookScoreDataStore : AListDataStore<ReaderBookScore>
	{
		public ReaderBookScoreDataStore()
			: base()
		{
		}
		public override async Task<ReaderBookScore> AddItemToService(ReaderBookScore item)
		{
			return await _service.ReaderBookScorePOSTAsync(item);
		}

		public override async Task<bool> DeleteItemFromService(ReaderBookScore item)
		{
			return await _service.ReaderBookScoreDELETEAsync(item.Id).HandleRequest();
		}

		public override async Task<ReaderBookScore> Find(ReaderBookScore item)
		{
			return await _service.ReaderBookScoreGETAsync(item.Id);
		}

		public override async Task<ReaderBookScore> Find(int id)
		{
			return await _service.ReaderBookScoreGETAsync(id);
		}

		public override async Task RefreshListFromService()
		{
			items = _service.ReaderBookScoreAllAsync().Result.ToList();
		}

		public override async Task<bool> UpdateItemInService(ReaderBookScore item)
		{
			return await _service.ReaderBookScorePUTAsync(item.Id, item).HandleRequest();
		}
	}
}
