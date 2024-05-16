namespace HouseRentingSystem.Web.Areas.Admin.ViewModels.House;

using Web.ViewModels.House;

public class MyHousesViewModel
{
    public MyHousesViewModel()
    {
        this.AddedHouses = new HashSet<HouseAllViewModel>();
        this.RentedHouses = new HashSet<HouseAllViewModel>();
    }
    public IEnumerable<HouseAllViewModel> AddedHouses { get; set; }

    public IEnumerable<HouseAllViewModel> RentedHouses { get; set; }
}
