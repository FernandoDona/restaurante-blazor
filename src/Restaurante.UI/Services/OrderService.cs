using Restaurante.Data.Interfaces;

namespace Restaurante.UI.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> InsertOrder(Order order)
    {
        try
        {
            ValidateOrder(order);
            
            if (IsNewOrder(order))
            {
                var orderId = await _orderRepository.InsertOrder(order);
                order.Id = orderId;
            }

            if (order.Items?.Count > 0)
            {
                SetOrderIdToOrderItems(order);
                await _orderRepository.InsertOrderItem(order.Items);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool IsNewOrder(Order order) => order.Id == 0;

    public decimal SumItemsPrice(Order order) => order.Items.Sum(i => i.Subtotal);

    private void ValidateOrder(Order order)
    {
        if (order.UserId <= 0)
            throw new ArgumentException("Não é possível inserir o pedido no banco de dados. Argumento inválido.", nameof(order.UserId));
        if (order.Address is null)
            throw new ArgumentException("Não é possível inserir o pedido no banco de dados. Argumento inválido.", nameof(order.Address));
    }

    private void SetOrderIdToOrderItems(Order order)
    {
        foreach (var item in order.Items)
        {
            if (item.OrderId != order.Id)
            {
                item.OrderId = order.Id;
            }
        }
    }
}
