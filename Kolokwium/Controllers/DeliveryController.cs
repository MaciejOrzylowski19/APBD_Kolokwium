using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;



[ApiController]
[Route("api/deliveries")]
public class DeliveryController : ControllerBase
{

    private IDeliveryService _deliveryService;
    private IAddDeliveryService _addDeliveryService;

    public DeliveryController(IDeliveryService service, IAddDeliveryService addDeliveryService)
    {
        _addDeliveryService = addDeliveryService;
        _deliveryService = service;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDelivery(int id)
    {

        try
        {
            return Ok(await _deliveryService.GetDelivery(id));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostDelivery([FromBody] PostDeliveryDTO deliveryDto)
    {

        await _addDeliveryService.AddDelivery(deliveryDto);
        
        return Ok();

    }
    
    
    
}