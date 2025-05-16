using Kolokwium.Models;

namespace Kolokwium.Repository;

using Microsoft.Data.SqlClient;

public class DeliveryRepository : IDeliveryRepository
{
    public SqlConnection _connection;
    
    private readonly string _getProductsIdCommand = "Select product_id From Product_Delivery Where delivery_id = @id;";

    private readonly string _getDriverCommand =
        "Select first_name, last_name, licence_number from Driver Where driver_id = @id;";

    private readonly string _getCustomerCommand =
        "Select first_name, last_name, date_of_birth From Customer Where customer_id = 1;";

    private readonly string _getProduct =
        "Select name, price, amount From Product inner join Product_Delivery on Product.product_id = Product_Delivery.product_id Where delivery_id = @id;";

    public DeliveryRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<List<int>> GetProductsForDeliveriesId(int i)
    {

        var target = new List<int>();

        using (SqlCommand command = new SqlCommand(_getProductsIdCommand, _connection))
        {
            command.Parameters.AddWithValue("@id", i);
            var result = await command.ExecuteReaderAsync();

            while (result.NextResult())
            {
                target.Add(result.GetInt32(0));
            }
        }
        return target;
    }

    public async Task<DriverDTO> GetDriver(int i)
    {
        
        using (SqlCommand command = new SqlCommand(_getDriverCommand, _connection))
        {
            command.Parameters.AddWithValue("@id", i);
            var result = await command.ExecuteReaderAsync();


            return new DriverDTO()
            {
                FirstName = result.GetString(0),
                LastName = result.GetString(1),
                LicenceNumber = result.GetString(2)
            };

        }
    }
    
    public async Task<CustomerDTO> GetCustomer(int i)
    {
        
        using (SqlCommand command = new SqlCommand(_getCustomerCommand, _connection))
        {
            command.Parameters.AddWithValue("@id", i);
            var result = await command.ExecuteReaderAsync();

            return new CustomerDTO()
            {
                FirstName = result.GetString(0),
                LastName = result.GetString(1),
                DateOfBirth= result.GetDateTime(2)
            };

        }
    }

    public async Task<List<ProductDTO>> GetProductsFromDelivery(int i)
    {

        var target = new List<ProductDTO>();
        
            using (SqlCommand command = new SqlCommand(_getProduct, _connection))
            {

                command.Parameters.AddWithValue("id", i);

                var result = await command.ExecuteReaderAsync();


                while (result.NextResult())
                {

                    target.Add(new ProductDTO()
                    {
                        Name = result.GetString(0),
                        Price = result.GetDouble(1),
                        Amount = result.GetInt32(2)
                    });
                }
            }

            return target;

    }
}