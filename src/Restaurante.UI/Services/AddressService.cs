using Restaurante.Data.Interfaces;

namespace Restaurante.UI.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Task<IEnumerable<Address>> GetAddressesByUserId(int userId)
    {
        return _addressRepository.GetAddressesByUserId(userId);
    }

    public async Task<bool> InsertAddress(Address address)
    {
        try
        {
            if (address.MainAddress == false)
            {
                await _addressRepository.InsertAddress(address);
                return true;
            }

            var userAddresses = await _addressRepository.GetAddressesByUserId(address.UserId);

            SetMainAddress(address, userAddresses);

            await _addressRepository.InsertAddress(address);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAddress(Address address)
    {
        try
        {
            await _addressRepository.UpdateAddress(address);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Garante que só o endereço desejado seja o endereço principal.
    /// </summary>
    /// <param name="targetAddress">Endereço a ser considerado como principal para um usuário</param>
    /// <param name="addresses">Lista de endereços cadasrados para um usuário</param>
    public void SetMainAddress(Address targetAddress, IEnumerable<Address> addresses)
    {
        foreach (var address in addresses)
        {
            if (address.MainAddress == true && address.Id != targetAddress.Id)
            {
                address.MainAddress = false;
                _addressRepository.UpdateAddress(address);
            }

            if (address.Id == targetAddress.Id) 
            {
                address.MainAddress = true;
                _addressRepository.UpdateAddress(address);
            }
        }
    }
}
