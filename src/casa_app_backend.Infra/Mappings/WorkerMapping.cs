using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class WorkerMapping : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
                builder.HasKey(w => w.Id);

                    builder.HasOne(w => w.House)
                .WithMany(h => h.Workers)
                .HasForeignKey(w => w.HouseId);
        }
    }
}