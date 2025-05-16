using Kolokwium.Models;

namespace Kolokwium.Services;

public interface IDeliveryService
{

    Task<DeliveryDTO> GetDelivery(int i);
    
}