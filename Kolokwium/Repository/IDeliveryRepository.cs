using Kolokwium.Models;

namespace Kolokwium.Repository;

public interface IDeliveryRepository
{

    Task<List<int>> GetProductsForDeliveriesId(int i);
    Task<DriverDTO> GetDriver(int i);
    Task<CustomerDTO> GetCustomer(int i);

    Task<List<ProductDTO>> GetProductsFromDelivery(int i);



}