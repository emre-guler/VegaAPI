using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Enums;
using Vega.Interfaces;

namespace Vega.Services
{
    public class MethodService : IMethodService
    {
        private int stringLength = 30;
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random random = new();
        private readonly VegaContext _db;
        public MethodService(VegaContext db)
        {
            _db = db;
        }

        public async Task<string> GenerateURL()
        {
            string response = "";

            while(true) 
            {
                string randomString = new String(Enumerable.Repeat(chars, stringLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                
                if(await _db.Requests.AnyAsync(x => x.URL == randomString))
                {
                    continue;
                }
                else
                {
                    response = randomString;
                    break;
                }
            }

            return response;
        }

        public int GenerateRandomNumber()
        {
            return random.Next(100000, 999999);
        }
    }
}