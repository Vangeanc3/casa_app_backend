using casa_app_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace casa_app_backend.Infra.Mappings
{
    public class InviteMapping : IEntityTypeConfiguration<Invite>
    {
        public void Configure(EntityTypeBuilder<Invite> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Contract)
                .WithMany(c => c.Invites)
                .HasForeignKey(i => i.ContractId);
        }
    }
}