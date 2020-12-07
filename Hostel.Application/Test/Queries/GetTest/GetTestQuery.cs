using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.Application.Common.Dtos;
using Hostel.Application.Common.Repository;
using Hostel.Domain.Entities;
using MediatR;

namespace Hostel.Application.Test.Queries.GetTest
{
    public class GetTestQuery : IRequest<IEnumerable<TestDto>>
    {
    }

    public class GetTestQueryHandler : IRequestHandler<GetTestQuery, IEnumerable<TestDto>>
    {
        private readonly IRepository<TestEntity> _testRepository;
        private readonly IMapper _mapper;

        public GetTestQueryHandler(IRepository<TestEntity> testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestDto>> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var testData = await  _testRepository.GetAsync();

            return _mapper.Map<IEnumerable<TestDto>>(testData);
        }
    }
}
