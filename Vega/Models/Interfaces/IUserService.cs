using System.Threading.Tasks;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginControl(LoginViewModel model);
    }
}