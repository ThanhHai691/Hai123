using ConnectDatabaseAndSimpleApi.Dto;
using ConnectDatabaseAndSimpleApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ConnectDatabaseAndSimpleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
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

public interface IPurchaseOrderService
{
}