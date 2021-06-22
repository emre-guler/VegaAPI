using System.Threading.Tasks;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}