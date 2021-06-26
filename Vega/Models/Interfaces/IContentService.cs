using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.DTO;
using Vega.Entities;
using Vega.Models;

namespace Vega.Interfaces
{
    public interface IContentService
    {
        Task<List<MostWinnersDTO>> GetMostWinners(int pageSize, int pageNumber);
    }
}