namespace Kolokwium.Models;

public class DeliveryDTO
{
    public DateTime Date { get; set; }
    public CustomerDTO Customer { get; set; }
    public DriverDTO Driver { get; set; }
    
    public List<ProductDTO> products {get;set;}
}