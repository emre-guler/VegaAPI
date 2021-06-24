using System.Threading.Tasks;
using Vega.Enums;

namespace Vega.Interfaces
{
    public interface IMethodService
    {
        Task<string> GenerateURL();
        int GenerateRandomNumber();
    }
}