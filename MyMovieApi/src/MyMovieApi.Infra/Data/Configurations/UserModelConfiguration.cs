using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieApi.Core.Entities;

namespace MyMovieApi.Infra.Data.Configurations
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.NickName)
                .HasColumnName("nickName");

            builder.Property(u => u.Email)
                .HasColumnName("email");

            builder.Property(u => u.Password)
                .HasColumnName("password");

        }
    }
}