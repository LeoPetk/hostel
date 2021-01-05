using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.Application.Common.Dtos;
using Hostel.Application.Common.Repository;
using Hostel.Application.Room.Queries.GetRooms;
using Moq;
using NUnit.Framework;

namespace Hostel.Application.Tests.Room
{
    [TestFixture]
    public class GetRoomsTests
    {
        private Mock<IRepository<Domain.Entities.Room>> _roomRepository;
        private GetRoomsQueryHandler _roomsQueryHandler;
        
        [SetUp]
        public void Setup()
        {
            _roomRepository = new Mock<IRepository<Domain.Entities.Room>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Common.AutoMapper.AutoMapper());
            });
            var mapper = mockMapper.CreateMapper();
            _roomsQueryHandler = new GetRoomsQueryHandler(_roomRepository.Object, mapper);
        }
        
        [Test]
        public async Task GetRoomsQuery_Should_Return_Data()
        {
            // Arrange
            var hostelId = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650");
            List<Domain.Entities.Room> filteredResult = null;

            _roomRepository.Setup(x => x.GetListByAsync(It.IsAny<Expression<Func<Domain.Entities.Room, bool>>>()))
                .Callback((Expression<Func<Domain.Entities.Room, bool>> expression) =>
                {
                    var clause = expression.Compile();
                    filteredResult = GetRoomList().Where(clause).ToList();
                }).ReturnsAsync(() => filteredResult);

            // Act
            var result = await _roomsQueryHandler.Handle(new GetRoomsQuery(hostelId), CancellationToken.None);

            // Assert
            _roomRepository.Verify(x => x.GetListByAsync(It.IsAny<Expression<Func<Domain.Entities.Room, bool>>>()), Times.Once);
            Assert.AreEqual(4, result.Count());
        }

        private IEnumerable<Domain.Entities.Room> GetRoomList()
        {
           return new  List<Domain.Entities.Room>()
            {
                new Domain.Entities.Room()
                {
                    Id = Guid.NewGuid(),
                    Name = "tete",
                    HostelId = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650")
                },
                new Domain.Entities.Room()
                {
                    Id = Guid.NewGuid(),
                    Name = "bla",
                    HostelId = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650")
                },
                new Domain.Entities.Room()
                {
                    Id = Guid.NewGuid(),
                    Name = "grdadawe",
                    HostelId = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650")
                },
                new Domain.Entities.Room()
                {
                    Id = Guid.NewGuid(),
                    Name = "gokogokoekgo",
                    HostelId = Guid.Parse("6E42095D-74B1-4FE8-B06F-FC7D072A3650")
                },
                new Domain.Entities.Room()
                {
                    Id = Guid.NewGuid(),
                    Name = "gokogokoekgo",
                    HostelId = Guid.Empty
                }
            };
        }
    }
}