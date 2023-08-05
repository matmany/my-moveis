using Microsoft.EntityFrameworkCore;
using MyMovieApi.Core.Entities;

namespace MyMovieApi.Infra.Data.Configurations
{
    public class UserMovieEntityConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserMovie> builder)
        {
            builder.ToTable("user_movies");

            builder.HasKey(um => new { um.UserId, um.MovieId });

            builder.HasOne(um => um.User)
                .WithMany(u => u.UserMovies)
                .HasForeignKey(um => um.UserId);

            builder.HasOne(um => um.Movie)
                .WithMany(m => m.UserMovies)
                .HasForeignKey(um => um.MovieId);
        }
    }
}