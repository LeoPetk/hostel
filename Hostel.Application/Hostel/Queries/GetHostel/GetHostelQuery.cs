using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.Application.Common.Dtos;
using Hostel.Application.Common.Repository;
using MediatR;

namespace Hostel.Application.Hostel.Queries.GetHostel
{
    public class GetHostelQuery : IRequest<HostelDto>
    {
        public Guid HostelId { get; set; }
        
        public GetHostelQuery(Guid hostelId)
        {
            HostelId = hostelId;
        }
    }

    public class GetHostelQueryHandler : IRequestHandler<GetHostelQuery, HostelDto>
    {
        private readonly IRepository<Domain.Entities.Hostel> _hostelRepository;
        private readonly IMapper _mapper;
        
        public GetHostelQueryHandler(IRepository<Domain.Entities.Hostel> hostelRepository, IMapper mapper)
        {
            _hostelRepository = hostelRepository;
            _mapper = mapper;
        }

        public async Task<HostelDto> Handle(GetHostelQuery request, CancellationToken cancellationToken)
        {
            var hostel = await _hostelRepository.GetByAsync(x => x.Id == request.HostelId);

            return _mapper.Map<HostelDto>(hostel);
        }
    }
}