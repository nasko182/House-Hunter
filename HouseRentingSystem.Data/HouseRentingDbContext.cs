namespace HouseRentingSystem.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

public class HouseRentingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid> ,Guid>
{
    public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
        : base(options)
    {
    }
}
