using System.Threading.Tasks;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model); 
        Task<bool> IsVerified(int Id);
        Task MailVerification(int Id);
        Task<bool> ControlVerfiyPage(int Id, string URL);
        Task<bool> ControlVerifyCode(int Id, string URL, int code);
        Task<bool> ResetPasswordRequest(string mailAddress);
    }
}