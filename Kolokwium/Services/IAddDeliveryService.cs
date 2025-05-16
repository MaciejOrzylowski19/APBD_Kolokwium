using Kolokwium.Models;

namespace Kolokwium.Services;

public interface IAddDeliveryService
{

      Task<int> AddDelivery(PostDeliveryDTO deliveryDto);
}