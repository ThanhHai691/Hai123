using ConnectDatabaseAndSimpleApi.Entites;
using hai123.Data;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace ConnectDatabaseAndSimpleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FishController : ControllerBase
{
    private readonly AppDbContext _context;

    public FishController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Fish.ToListAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _context.Fish.FindAsync(id);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> CreateDogAsync([FromBody] Fish dto)
    {
        _context.Fish.Add(dto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDogAsync([FromRoute] int id, [FromBody] Fish fish)
    {
        var findInDatabase = await _context.Fish.FirstOrDefaultAsync(x => x.Id == id);

        if (findInDatabase == null) return NotFound("Không tìm thấy con cas");

        findInDatabase.Age  = fish.Age;
        findInDatabase.Name = fish.Name;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDogAsync([FromRoute] int id)
    {
        var result = await _context.Fish.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null) return NotFound("Không tìm thấy con cas");
        _context.Fish.Remove(result);
        await _context.SaveChangesAsync();

        return Ok();
    }
}