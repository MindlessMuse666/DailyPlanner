using DailyPlanner.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyPlanner.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany<Report>(x => x.Reports)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<UserRole>(
                l => l.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey(x => x.RoleId)
                    .HasPrincipalKey(x => x.Id),
                l => l.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .HasPrincipalKey(x => x.Id)
            );

        builder.HasOne<UserToken>(x => x.UserToken)
            .WithOne(x => x.User)
            .HasForeignKey<UserToken>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id);

        builder.HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Login = "TestUser",
                Password = "TestUserPassword",
                CreatedAt = DateTime.UtcNow
            }
        });
    }
}