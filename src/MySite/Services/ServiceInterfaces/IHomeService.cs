using MySite.Models.HomeViewModels;

namespace MySite.Services.ServiceInterfaces
{
    public interface IHomeService
    {
        HomeViewModel GetAantallen();
    }
}