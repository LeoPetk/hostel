using System.Threading;
using System.Threading.Tasks;
using Hostel.Application.Common.Repository;
using Hostel.Domain.Entities;
using MediatR;

namespace Hostel.Application.Test.Queries.GetTestByCondition
{
    public class GetTestByConditionQuery : IRequest<TestEntity>
    {
        public int Id { get; }
        
        public GetTestByConditionQuery(int id)
        {
            Id = id;
        }
    }
    
    public class GetTestByConditionQueryHandler : IRequestHandler<GetTestByConditionQuery, TestEntity>
    {
        private readonly IRepository<TestEntity> _testRepository;

        public GetTestByConditionQueryHandler(IRepository<TestEntity> testRepository)
        {
            _testRepository = testRepository;
        }
        
        public async Task<TestEntity> Handle(GetTestByConditionQuery request, CancellationToken cancellationToken)
        {
            // primer za Expression<Func>
            return await _testRepository.GetByAsync(x => x.Id == request.Id && x.Name != "Nikola");
        }
    }
}