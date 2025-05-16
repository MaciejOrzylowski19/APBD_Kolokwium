namespace Kolokwium.Models;

public class PostDeliveryDTO
{
    
    public int DeliveryId { get; set; }
    public int CustomerId { get; set; }
    public string LicenseNumber { get; set; }
    
    public List<PostDeliveryDTO> Products { get; set;}
    
    
}