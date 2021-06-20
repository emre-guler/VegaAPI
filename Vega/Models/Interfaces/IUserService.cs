using System.Threading.Tasks;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model); 
    }
}