using ConnectDatabaseAndSimpleApi.Dto;
using hai123.Dto;
using hai123.Extensions;
using hai123.Services.PurchaseOrder;
using Microsoft.AspNetCore.Mvc;

namespace hai123.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController(IPurchaseOrderServices purchaseOrderService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ParamQuery paramQuery)
    {
        var result = await purchaseOrderService.GetAllAsync(paramQuery);
        return Ok(result);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await purchaseOrderService.GetByIdAsync(id);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> CreateDogAsync([FromBody] CreatePurchaseOrder dto)
    {
        await purchaseOrderService.CreateAsync(dto);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDogAsync([FromRoute] int id, [FromBody] UpdatePurchaseOrder dto)
    {
        await purchaseOrderService.UpdateAsync(id, dto);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDogAsync([FromRoute] int id)
    {
        await purchaseOrderService.DeleteAsync(id);
        return Ok();
    }
}