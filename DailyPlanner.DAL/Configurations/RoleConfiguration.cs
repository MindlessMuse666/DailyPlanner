using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Setups.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyPlanner.DAL.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        var roleProperties = new RolePropertiesSetup();
        var roleTitles = new RoleTitlesSetup();

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(roleProperties.MaxTitleLength);

        Console.WriteLine($"Максимальное длина названия роли: {roleProperties.MaxTitleLength}, тип {roleProperties.MaxTitleLength.GetType()}");
        
        builder.HasData(new List<Role>
            {
                new()
                {
                    Id = 1,
                    Name = roleTitles.User
                },
                new()
                {
                    Id = 2,
                    Name = roleTitles.Moderator
                },
                new()
                {
                    Id = 3,
                    Name = roleTitles.Admin
                }
            }
        );
    }
}