using System.Threading.Tasks;
using Vega.Entities;

namespace Vega.Interfaces
{
    public interface IMailService 
    {
        Task SendRegisterMail(string mailAddress);
        Task SendVerificationMail(int Id, Verification verificationData);
    }
}