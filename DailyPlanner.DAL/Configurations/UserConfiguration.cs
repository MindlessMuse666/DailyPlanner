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

        builder.HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Login = "Test",
                Password = "TestPassword"
            }
        });
        
        builder.HasOne<UserToken>(x => x.UserToken)
            .WithOne(x => x.User)
            .HasForeignKey<UserToken>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id);
    }
}