using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Persistence.Configurations.Entities
{
    public class UserDetailConfiguration :IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasOne(a => a.User)
                   .WithMany(a => a.UserDetails)
                   .HasForeignKey(a => a.UserId);

        }
    }

}
