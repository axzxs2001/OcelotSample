using DapperPlus;
using HisAPI.Model.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace HisAPI.Model.Repository
{
    public class FeeItemRepository:IFeeItemRepository
    {
        IDapperPlusDB _hisDB;
        public FeeItemRepository(IDapperPlusDB hisDB)
        {
            _hisDB = hisDB;
        }
        public List<dynamic> GetFeeItem(string name)
        {
            return _hisDB.Query<dynamic>("select top 100 * from t_bx_feeitem where fname like  CONCAT('%',@name,'%') or fpy like CONCAT('%',@name,'%')", new { name = name }).ToList();
        }
        public List<FeeItem> GetFeeItems(string name)
        {
            return _hisDB.Query<FeeItem>("select top 100 * from t_bx_feeitem where fname like  CONCAT('%',@name,'%') or fpy like CONCAT('%',@name,'%') or  fdosaform like CONCAT('%',@name,'%')  or flocal like CONCAT('%',@name,'%')  or fapprono like CONCAT('%',@name,'%')", new { name = name }).ToList();
        }
    }

}