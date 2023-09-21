using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class ToDoCategoryMapping : IEntityTypeConfiguration<ToDoCategory>
    {
        public void Configure(EntityTypeBuilder<ToDoCategory> builder)
        {
            builder.HasKey(t => t.Id);

              builder.HasOne(c => c.BaseCategory)
            .WithMany(c => c.Categories)
            .HasForeignKey(c => c.BaseCategoryId);
        }
    }
}