using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class ToDoDefaultMapping : IEntityTypeConfiguration<ToDoDefault>
    {
        public void Configure(EntityTypeBuilder<ToDoDefault> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Category)
            .WithMany(c => c.ToDoDefaults)
            .HasForeignKey(t => t.CategoryId);
        }
    }
}