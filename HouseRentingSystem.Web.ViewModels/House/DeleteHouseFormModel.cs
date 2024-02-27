namespace HouseRentingSystem.Web.ViewModels.House;

using System.ComponentModel.DataAnnotations;

public class DeleteHouseFormModel
{
    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    [Display(Name = "Image Link")]
    public string ImageUrl { get; set; } = null!;
}
