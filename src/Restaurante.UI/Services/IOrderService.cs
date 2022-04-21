
namespace Restaurante.UI.Services;

public interface IOrderService
{
    Task<bool> InsertOrder(Order order);
    decimal SumItemsPrice(Order order);
}