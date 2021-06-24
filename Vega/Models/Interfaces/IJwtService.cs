using System.Security.Claims;
using Vega.DTO;
using Vega.Entities;

namespace Vega.Interfaces
{
    public interface IJwtService
    {
        string Create(User user);
        JwtClaimDto ReadToken(ClaimsIdentity claims);
    }
}