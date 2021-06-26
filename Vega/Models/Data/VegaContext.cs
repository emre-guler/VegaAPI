using Microsoft.EntityFrameworkCore;
using Vega.Entities;

namespace Vega.Data
{
    public class VegaContext : DbContext
    {
        public VegaContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketQuestion> TicketQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}