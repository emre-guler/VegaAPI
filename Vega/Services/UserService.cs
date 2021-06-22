using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Entities;
using Vega.Enums;
using Vega.Interfaces;
using Vega.Models;

namespace Vega.Services 
{
    public class UserService : IUserService
    {
        private readonly VegaContext _db;
        private readonly IMailService _mailService; 
        public UserService(
            VegaContext db,
            IMailService mailService
        )
        {
            _db = db;
            _mailService = mailService;
        }

        public async Task<User> Login(LoginViewModel model)
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

        public async Task<bool> Register(RegisterViewModel model)
        {
            bool userExist = await _db.Users
                .Where(x => x.MailAddress == model.MailAddress || x.PhoneNumber == model.PhoneNumber)
                .AnyAsync();
            if (!userExist)
            {
                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _db.AddAsync(new User {
                    Fullname = model.Fullname,
                    MailAddress =  model.MailAddress,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    Role = Role.Player,
                    Money = 0,
                    CreatedAt = DateTime.Now,
                    BirthDate = model.BirthDate
                });
                await _db.SaveChangesAsync();
                await _mailService.SendRegisterMail(model.MailAddress);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}