
namespace Restaurante.UI.Services;

public interface IAddressService
{
    Task<IEnumerable<Address>> GetAddressesByUserId(int userId);
    Task<bool> InsertAddress(Address address);
    Task<bool> UpdateAddress(Address address);
    void SetMainAddress(Address targetAddress, IEnumerable<Address> addresses);
}