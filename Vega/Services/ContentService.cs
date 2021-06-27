using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.DTO;
using Vega.Interfaces;

namespace Vega.Services
{
    public class ContentService : IContentService
    {
        private VegaContext _db;
        private readonly IMapper _mapper;
        public ContentService(VegaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<MostWinnersDTO>> GetMostWinners(int pageSize, int pageNumber)
        {
            var data = await _db.Users
                .Where(x => !x.DeletedAt.HasValue && x.Role == Enums.Role.Player)
                .OrderByDescending(x => x.Money)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Select(x => new {
                    x.Fullname,
                    x.Money
                })
                .ToListAsync();
            
            return _mapper.Map<List<MostWinnersDTO>>(data);
        }
    }
}