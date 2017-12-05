using HisAPI.Model.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace HisAPI.Model.Repository
{
    /// <summary>
    /// FeeItem仓储
    /// </summary>
    public interface IFeeItemRepository
    {
        /// <summary>
        /// 按名称模糊查询收费项目
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        List<dynamic> GetFeeItem(string name);
        /// <summary>
        /// 按名称模糊查询收费项目
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        List<FeeItem> GetFeeItems(string name);
    }
}
