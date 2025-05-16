using Microsoft.Data.SqlClient;

namespace Kolokwium.Repository;

public class AddDeliveryRepository
{




    private string _deliveryExists = "Select 1 From Delivery Where delivery_id = @id";
    private string _clientExists = "Select 1 From Customer Where customer_id = @id";
    
    
    
    private SqlConnection _connection;

    public AddDeliveryRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    

}