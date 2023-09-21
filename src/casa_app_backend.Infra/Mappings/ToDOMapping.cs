using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class ToDOMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.CreatedBy)
               .WithMany(c => c.ToDosCreated)
               .HasForeignKey(t => t.CreatedById);

            builder.HasOne(t => t.AssignedTo)
                .WithMany(c => c.ToDosAssigned)
                .HasForeignKey(t => t.AssignedToId);

            builder.HasOne(t => t.Category)
            .WithMany(c => c.ToDos)
            .HasForeignKey(t => t.CategoryId);

            builder.HasOne(t => t.Pet)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.PetId);

            builder.HasOne(t => t.Place)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.PlaceId);

            builder.HasOne(t => t.Vehicle)
            .WithMany(p => p.ToDos)
            .HasForeignKey(t => t.VehicleId);
        }
    }
}