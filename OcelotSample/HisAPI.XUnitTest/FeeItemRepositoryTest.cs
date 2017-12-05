using Moq;
using System;
using Xunit;
using DapperPlus;
using HisAPI.Model.Repository;
using System.Collections.Generic;

namespace HisAPI.XUnitTest
{
    /// <summary>
    /// FeeItemRepository仓储测试
    /// </summary>
    [Trait("FeeItem仓储层", "FeeItemRepository")]
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

        /// <summary>
        /// 按名称模糊查询收费项目测试
        /// </summary>
        [Fact]
        public void GetFeeItem_NullName_Return()
        {
            var list = new List<dynamic>() { new {name="name1" },new { name="name2"} };
            _dbMock.Setup(db => db.Query<dynamic>(It.IsAny<string>(), null, null, false, null, null)).Returns(list);
            var feeItems = _feeItemRepository.GetFeeItem("");
            Assert.Equal(2, feeItems.Count);
        }

        /// <summary>
        /// 按名称模糊查询收费项目测试
        /// </summary>
        [Fact]
        public void GetFeeItem_Default_Return()
        {
            var list = new List<dynamic>() { new { name = "name1" }, new { name = "name2" } };
            _dbMock.Setup(db => db.Query<dynamic>(It.IsAny<string>(),  It.IsAny<object>(), null,false, null, null)).Returns(list);
            var feeItems = _feeItemRepository.GetFeeItem("amxl");
            Assert.Equal(2, feeItems.Count);
        }
    }
}
