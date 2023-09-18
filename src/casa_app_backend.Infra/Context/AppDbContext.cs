using casa_app_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
            .HasOne(u => u.Contract)
            .WithMany(c => c.UsersOfContract)
            .HasForeignKey(u => u.ContractId);

            builder.Entity<Invite>()
                .HasOne(i => i.Contract)
                .WithMany(c => c.Invites)
                .HasForeignKey(i => i.ContractId);

            builder.Entity<Pet>()
                .HasOne(p => p.House)
                .WithMany(h => h.Pets)
                .HasForeignKey(p => p.HouseId);

            builder.Entity<Worker>()
                .HasOne(w => w.House)
                .WithMany(h => h.Workers)
                .HasForeignKey(w => w.HouseId);

            builder.Entity<Vehicle>()
                .HasOne(v => v.House)
                .WithMany(h => h.Vehicles)
                .HasForeignKey(v => v.HouseId);

            builder.Entity<Place>()
                .HasOne(p => p.House)
                .WithMany(h => h.Places)
                .HasForeignKey(p => p.HouseId);

            builder.Entity<ToDo>()
                .HasOne(t => t.CreatedBy)
                .WithMany(c => c.ToDosCreated)
                .HasForeignKey(t => t.CreatedById);

            builder.Entity<ToDo>()
                .HasOne(t => t.AssignedTo)
                .WithMany(c => c.ToDosAssigned)
                .HasForeignKey(t => t.AssignedToId);

            builder.Entity<ToDo>()
            .HasOne(t => t.Category)
            .WithMany(c => c.ToDos)
            .HasForeignKey(t => t.CategoryId);

            builder.Entity<ToDo>()
            .HasOne(t => t.Pet)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.PetId);
            
            builder.Entity<ToDo>()
            .HasOne(t => t.Place)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.PlaceId);
            
            builder.Entity<ToDo>()
            .HasOne(t => t.Vehicle)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.VehicleId);

            builder.Entity<ToDoCategory>()
            .HasOne(c => c.BaseCategory)
            .WithMany(c => c.Categories)
            .HasForeignKey(c => c.BaseCategoryId);

            builder.Entity<ToDoDefault>()
            .HasOne(t => t.Category)
            .WithMany(c => c.ToDoDefaults)
            .HasForeignKey(t => t.CategoryId);
        }

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
    }
}