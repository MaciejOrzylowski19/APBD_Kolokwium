using Kolokwium.Models;
using Kolokwium.Repository;
using Microsoft.Data.SqlClient;

namespace Kolokwium.Services;

public class DeliveryService : IDeliveryService
{
    private IDeliveryRepository _repository;
    private IConfiguration _configuration;

    private readonly string _dateCommand = "Select date From Delivery Where delivery_id = @id;";
    
    public async Task<DeliveryDTO> GetDelivery(int i)
    {

        using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {

            connection.OpenAsync();
            _repository = new DeliveryRepository(connection);
            var target = new DeliveryDTO();

            using (SqlCommand command = new SqlCommand(_dateCommand, connection))
            {
                var result = await command.ExecuteReaderAsync();

                result.NextResult();

                target.Date = result.GetDateTime(0);
                target.Customer = await _repository.GetCustomer(i);
                target.Driver = await _repository.GetDriver(i);
                target.products = await _repository.GetProductsFromDelivery(i);

            }

            return target;

        }

    }
}