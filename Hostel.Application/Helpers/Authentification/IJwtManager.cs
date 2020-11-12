using System;
using System.Threading.Tasks;

namespace Hostel.Application.Helpers.Authentification
{
    public interface IJwtManager
    {
        Task<string> CreateJwt(Guid userId, string email);
    }
}