using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain;

namespace Test.Persistence.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Code)
                   .IsRequired();

        }

    }
}
