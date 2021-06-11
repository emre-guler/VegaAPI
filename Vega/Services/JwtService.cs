using Vega.Data;
using Vega.Entities;
using Vega.Interfaces;

namespace Vega.Services
{
    public class JwtService : IJwtService
    {
        private readonly VegaContext _db;
        public JwtService(VegaContext db)
        {
            _db = db;
        }

        public string Create (User user)
        {
            return "";
        }
    }
}