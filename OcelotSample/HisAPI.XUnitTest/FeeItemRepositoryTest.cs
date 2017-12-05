using Moq;
using System;
using Xunit;
using DapperPlus;
using HisAPI.Model.Repository;

namespace HisAPI.XUnitTest
{
    public class FeeItemRepositoryTest
    {
        /// <summary>
        /// 数据库Mock对象
        /// </summary>
        Mock<IDapperPlusDB> _dbMock;
        /// <summary>
        /// FeeItem仓储对象
        /// </summary>
        IFeeItemRepository _feeItemRepository;
        public FeeItemRepositoryTest()
        {
            _dbMock = new Mock<IDapperPlusDB>();
            _feeItemRepository = new FeeItemRepository(_dbMock.Object);
        }
    }
}
