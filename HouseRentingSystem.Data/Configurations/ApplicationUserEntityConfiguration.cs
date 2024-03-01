namespace HouseRentingSystem.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasData(GenerateApplicationUsers());
    }

    private static ApplicationUser[] GenerateApplicationUsers()
    {
        ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();
        ApplicationUser user;

        user = new ApplicationUser
        {
            Id = Guid.Parse("2FE36ACB-8C75-42D4-C03D-08DC1FF94547"),
            UserName = "petarTheAgent@agent.com",
            NormalizedUserName = "PETARTHEAGENT@AGENT.COM",
            Email = "petarTheAgent@agent.com",
            NormalizedEmail = "PETARTHEAGENT@AGENT.COM",
            PasswordHash = "AQAAAAEAACcQAAAAEO7JovbSo1gy2Vp6mqwYLHj4TZkQjfbpWklUVyzASAC3yKHJT0PD8mn8xatcrgFMNw==",
            SecurityStamp = "VSTG5SK3JGPHVTCZ2P7ZPBS7RPUSSWRQ",
            ConcurrencyStamp = "98e12ef7-b59f-4729-af26-db318efad511",
            FirstName = "Petar",
            LastName = "Petrov"
        };
        users.Add(user);
        user = new ApplicationUser
        {
            Id = Guid.Parse("6ACC5766-87F9-4F30-C03E-08DC1FF94547"),
            UserName = "georgiTheRenter@renter.com",
            NormalizedUserName = "GEORGITHERENTER@RENTER.COM",
            Email = "georgiTheRenter@renter.com",
            NormalizedEmail = "GEORGITHERENTER@RENTER.COM",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAEAACcQAAAAEPL07n/1SrJYy2pO6hVqiySKNg3VsgB+cjlr+CvshIEQ70RiD/8WQSu4PSrZ1TSgNw==",
            SecurityStamp = "HS3DCKS3MZ7VNAPRX5DZZWJHID2TSRXW",
            ConcurrencyStamp = "11d23514-fa48-496d-9605-7ba6ef6c1260",
            FirstName = "Georgi",
            LastName = "Georgiev"
        };
        users.Add(user);
        user = new ApplicationUser
        {
            Id = Guid.Parse("50C9CAF6-B29D-40BB-805B-60B2239C658D"),
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAEAACcQAAAAEEZGWOYr44CMMcBewruzlneP9Yk+odUQQLsOdemYZ+mM6ntwsdUi5XVFguLBUJja+w==",
            SecurityStamp = "HS3DCKS3MZ7VNAPRX5DZZWJHID2TSRXW",
            ConcurrencyStamp = "WAU6MNVIDHYI7YF56TCS3MYLIELT4FRQ",
            FirstName = "Admin",
            LastName = "Adminov"
        };
        users.Add(user);

        return users.ToArray();
    }
}
