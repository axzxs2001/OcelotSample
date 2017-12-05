using DapperPlus;
using HisAPI.Model.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace HisAPI.Model.Repository
{
    /// <summary>
    /// FeeItem仓储
    /// </summary>
    public class FeeItemRepository : IFeeItemRepository
    {
        IDapperPlusDB _hisDB;
        public FeeItemRepository(IDapperPlusDB hisDB)
        {
            _hisDB = hisDB;
        }
        /// <summary>
        /// 按名称模糊查询收费项目
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public List<dynamic> GetFeeItem(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _hisDB.Query<dynamic>("select top 100 * from t_bx_feeitem").ToList();
            }
            else
            {
                return _hisDB.Query<dynamic>("select top 100 * from t_bx_feeitem where fname like  CONCAT('%',@name,'%') or fpy like CONCAT('%',@name,'%')", new {  name }).ToList();
            }
        }
        /// <summary>
        /// 按名称模糊查询收费项目
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public List<FeeItem> GetFeeItems(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _hisDB.Query<FeeItem>("select top 100 * from t_bx_feeitem").ToList();
            }
            else
            {
                return _hisDB.Query<FeeItem>("select top 100 * from t_bx_feeitem where fname like  CONCAT('%',@name,'%') or fpy like CONCAT('%',@name,'%') or  fdosaform like CONCAT('%',@name,'%')  or flocal like CONCAT('%',@name,'%')  or fapprono like CONCAT('%',@name,'%')", new {  name }).ToList();
            }
        }
    }

}