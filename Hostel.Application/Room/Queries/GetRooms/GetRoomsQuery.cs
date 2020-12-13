using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.Application.Common.Dtos;
using Hostel.Application.Common.Repository;
using MediatR;

namespace Hostel.Application.Room.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<IEnumerable<RoomDto>>
    {
        public Guid HostelId { get; set; }
        public GetRoomsQuery(Guid hostelId)
        {
            HostelId = hostelId;
        }
    }

    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, IEnumerable<RoomDto>>
    {
        private readonly IRepository<Domain.Entities.Room> _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(IRepository<Domain.Entities.Room> roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetListByAsync(x => x.HostelId == request.HostelId);
            var sortedRooms = rooms.OrderBy(x => x.Name);
            
            return _mapper.Map<IEnumerable<RoomDto>>(sortedRooms);
        }
    }
}