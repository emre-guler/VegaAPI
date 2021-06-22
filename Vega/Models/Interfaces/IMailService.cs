using System.Threading.Tasks;

namespace Vega.Interfaces
{
    public interface IMailService 
    {
        Task SendRegisterMail(string mailAddress);
    }
}