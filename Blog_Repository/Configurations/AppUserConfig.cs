using Blog_Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repository.Configurations
{
   public class AppUserConfig:BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.FullName).IsRequired(true);
            builder.Property(x => x.ImagePath).IsRequired(false);
            base.Configure(builder);

        }
    }
}
