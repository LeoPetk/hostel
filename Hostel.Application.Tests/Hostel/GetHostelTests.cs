using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.Application.Common.Repository;
using Hostel.Application.Hostel.Queries.GetHostel;
using Moq;
using NUnit.Framework;

namespace Hostel.Application.Tests.Hostel
{
    [TestFixture]
    public class GetHostelTests
    {
        private Mock<IRepository<Domain.Entities.Hostel>> _hostelRepository;
        private GetHostelQueryHandler _hostelQueryHandler;
        
        [SetUp]
        public void SetUp()
        {
            _hostelRepository = new Mock<IRepository<Domain.Entities.Hostel>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Common.AutoMapper.AutoMapper());
            });
            
            var mapper = mockMapper.CreateMapper();

            _hostelQueryHandler = new GetHostelQueryHandler(_hostelRepository.Object, mapper);
        }

        [Test]
        public async Task GetHostelQuery_Should_Return_Data()
        {
            // Arrange
            var hostelId = Guid.Parse("6E42095D-71B1-4FE8-B06F-FC7D072A3650");
            var filteredHostel = new Domain.Entities.Hostel();

            _hostelRepository.Setup(_ => _.GetByAsync(It.IsAny<Expression<Func<Domain.Entities.Hostel, bool>>>()))
                .Callback((Expression<Func<Domain.Entities.Hostel, bool>> expression) =>
                {
                    var clause = expression.Compile();
                    filteredHostel = GetHostelList().FirstOrDefault(clause);
                }).ReturnsAsync(() => filteredHostel);

            // Act
            var result = await _hostelQueryHandler.Handle(new GetHostelQuery(hostelId), CancellationToken.None);

            // Assert
            _hostelRepository.Verify(x => x.GetByAsync(It.IsAny<Expression<Func<Domain.Entities.Hostel, bool>>>()), Times.Once);
            Assert.AreEqual("Yellow", result.Name);
            Assert.AreEqual(hostelId, result.Id);
        }

        private IEnumerable<Domain.Entities.Hostel> GetHostelList()
        {
            return new List<Domain.Entities.Hostel>()
            {
                new Domain.Entities.Hostel()
                {
                    Id = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650"),
                    Name = "Blue"
                },
                new Domain.Entities.Hostel()
                {
                    Id = Guid.Parse("6E42095D-72B1-4FE8-B06F-FC7D072A3650"),
                    Name = "Red"
                },
                new Domain.Entities.Hostel()
                {
                    Id = Guid.Parse("6E42095D-71B1-4FE8-B06F-FC7D072A3650"),
                    Name = "Yellow"
                }
            };
        }
    }
}