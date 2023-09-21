using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Contract)
                .WithMany(c => c.UsersOfContract)
                .HasForeignKey(u => u.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}