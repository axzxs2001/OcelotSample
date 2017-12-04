using HisAPI.Model.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace HisAPI.Model.Repository
{
    public interface IFeeItemRepository
    {
        List<dynamic> GetFeeItem(string name);

        List<FeeItem> GetFeeItems(string name);
    }
}
