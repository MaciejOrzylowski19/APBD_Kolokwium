using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;



[ApiController]
[Route("api/deliveries")]
public class DeliveryController : ControllerBase
{

    private IDeliveryService _deliveryService;

    public DeliveryController(IDeliveryService service)
    {
        _deliveryService = service;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDelivery(int id)
    {

        try
        {
            return Ok(_deliveryService.GetDelivery(id));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    
}