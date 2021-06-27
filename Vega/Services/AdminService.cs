using Vega.Data;
using Vega.Interfaces;

namespace Vega.Services
{
    public class AdminService : IAdminService
    {
        private VegaContext _db;
        public AdminService(VegaContext db)
        {
            _db = db;
        }
    }
}