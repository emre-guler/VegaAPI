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
        Task MailVerificationRequest(int Id);
        Task<bool> VerfiyPage(int Id, string URL);
        Task<bool> VerifyUser(int Id, string URL, int code);
        Task<bool> RestPasswordRequest(string mailAddress);
        Task<bool> ResetPasswordPage(int Id, string URL);
        Task<bool> ResetPassword(int Id, string URL, string newPassword);
        Task<bool> UpdateUser(int Id, RegisterViewModel model);
    }
}