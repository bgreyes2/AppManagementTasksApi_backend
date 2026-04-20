using Microsoft.EntityFrameworkCore;
using AppManagementTaskApi.Net.Models.Entities;

namespace AppManagementTaskApi.Net.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options){}

        public DbSet<UserEntities> Users { get; set; } = null!;
        public DbSet<TaskEntities> Tasks { get; set; } = null!;


    }
}
