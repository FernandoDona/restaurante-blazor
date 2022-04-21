
namespace Restaurante.Data.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<IEnumerable<Order>> GetOrderByUserId(int userId);
    Task<int> InsertOrder(Order order);
    Task InsertOrderItem(List<OrderItem> orderItems);
}