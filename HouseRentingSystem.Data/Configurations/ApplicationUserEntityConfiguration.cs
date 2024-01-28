namespace HouseRentingSystem.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasData(this.generateApplicationUsers());
    }

    private ApplicationUser[] generateApplicationUsers()
    {
        ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();
        ApplicationUser user;

        user = new ApplicationUser
        {
            Id = Guid.Parse("2FE36ACB-8C75-42D4-C03D-08DC1FF94547"),
            UserName = "peshoTheAgent@agent.com",
            NormalizedUserName = "PESHOTHEAGENT@AGENT.COM",
            Email = "peshoTheAgent@agent.com",
            NormalizedEmail = "PESHOTHEAGENT@AGENT.COM",
            PasswordHash = "AQAAAAEAACcQAAAAEO7JovbSo1gy2Vp6mqwYLHj4TZkQjfbpWklUVyzASAC3yKHJT0PD8mn8xatcrgFMNw==",
            SecurityStamp = "VSTG5SK3JGPHVTCZ2P7ZPBS7RPUSSWRQ",
            ConcurrencyStamp = "98e12ef7-b59f-4729-af26-db318efad511",

        };
        users.Add(user);
        user = new ApplicationUser
        {
            Id = Guid.Parse("6ACC5766-87F9-4F30-C03E-08DC1FF94547"),
            UserName = "goshoTheRenter@renter.com",
            NormalizedUserName = "GOSHOTHERENTER@RENTER.COM",
            Email = "goshoTheRenter@renter.com",
            NormalizedEmail = "GOSHOTHERENTER@RENTER.COM",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAEAACcQAAAAEPL07n/1SrJYy2pO6hVqiySKNg3VsgB+cjlr+CvshIEQ70RiD/8WQSu4PSrZ1TSgNw==",
            SecurityStamp = "HS3DCKS3MZ7VNAPRX5DZZWJHID2TSRXW",
            ConcurrencyStamp = "11d23514-fa48-496d-9605-7ba6ef6c1260",

        };
        users.Add(user);

        return users.ToArray();
    }
}
