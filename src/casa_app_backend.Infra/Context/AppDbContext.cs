using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<HouseConfig> Houses { get; set; } = null!;
        public DbSet<Invite> Invites { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Place> Places { get; set; } = null!;
        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet<ToDoDefault> ToDosDefault { get; set; } = null!;
        public DbSet<ToDoCategory> ToDoCategories { get; set; } = null!;
    
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }
    }
}