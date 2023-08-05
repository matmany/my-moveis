using Microsoft.EntityFrameworkCore;
using MyMovieApi.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyMovieApi.Infra.Data.Configurations
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies");

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.ApprovalRating)
                .HasColumnName("approvalRating");

            builder.Property(u => u.DataOrigin)
                .HasColumnName("dataOrigin");

            builder.Property(u => u.Name)
                .HasColumnName("name");

            builder.Property(u => u.ImageUrl)
                .HasColumnName("imageUrl");

            builder.Property(u => u.Synopsis)
                .HasColumnName("synopsis");
            
        }
    }
}