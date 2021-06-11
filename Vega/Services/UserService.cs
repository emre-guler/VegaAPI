using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Entities;
using Vega.Interfaces;
using Vega.Models;

namespace Vega.Services 
{
    public class UserService : IUserService
    {
        private readonly VegaContext _db; 
        public UserService(
            VegaContext db
        )
        {
            _db = db;
        }

        public async Task<User> LoginControl(LoginViewModel model)
        {
            User user = await _db.Users
                .Where(x => x.PhoneNumber == model.PhoneNumber)
                .FirstOrDefaultAsync();
            if (user is not null)
            {
                bool passwordControl = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                if (passwordControl)
                {
                    return user;
                }
            }
            return null;
        }
    }
}