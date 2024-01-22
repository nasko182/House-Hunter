namespace HouseRentingSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class House
{
    [Key]
    public Guid Id { get; set; }
}
