using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hostel.Application.Common.Repository;
using Hostel.Domain.Entities;
using MediatR;

namespace Hostel.Application.Test.Queries.GetTest
{
    public class GetTestQuery : IRequest<IEnumerable<TestEntity>>
    {
    }

    public class GetTestQueryHandler : IRequestHandler<GetTestQuery, IEnumerable<TestEntity>>
    {
        private readonly IRepository<TestEntity> _testRepository;

        public GetTestQueryHandler(IRepository<TestEntity> testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<IEnumerable<TestEntity>> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            return await  _testRepository.GetAsync();
        }
    }
}
