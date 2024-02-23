namespace HouseRentingSystem.Web.ViewModels.House;

using System.ComponentModel.DataAnnotations;
using Enums;

using static Common.GeneralApplicationConstants;

public class AllHousesQueryModel
{
    public AllHousesQueryModel()
    {
        this.CurrentPage = DefaultPage;
        this.HousesPerPage = EntitiesPerPage;
        this.Categories = new HashSet<string>();
        this.Houses = new HashSet<HouseAllViewModel>();
    }
    public string? Category { get; set; }

    [Display(Name = "Search by Word")]
    public string? SearchString { get; set; }

    [Display(Name = "Sort House By")]
    public HouseSorting HouseSorting { get; set; }

    public int TotalHouses { get; set; }

    public int CurrentPage { get; set; }

    [Display(Name = "Show Houses On Page")]
    public int HousesPerPage { get; set; }

    public IEnumerable<string> Categories { get; set; }

    public IEnumerable<HouseAllViewModel> Houses { get; set; }
}
