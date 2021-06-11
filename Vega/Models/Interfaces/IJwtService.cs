using System.Threading.Tasks;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IJwtService
    {
        string Create(User user);
    }
}