using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceSchedule.Domain.User;
using ServiceSchedule.Infra.Data.Configuration;

namespace ServiceSchedule.Infra.Data.Context
{
    public class ServiceScheduleContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ServiceScheduleContext()
        {
            Database.EnsureCreated();
        }

        public ServiceScheduleContext(DbContextOptions<ServiceScheduleContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=LocalDatabase.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<User>();
        }
    }
}
