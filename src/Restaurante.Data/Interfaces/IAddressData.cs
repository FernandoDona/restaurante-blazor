
namespace Restaurante.Data.Interfaces;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAddressesByUserId(int userId);
    Task InsertAddress(Address address);
    Task UpdateAddress(Address address);
}