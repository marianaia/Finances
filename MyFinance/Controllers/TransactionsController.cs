using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MyFinance.Models;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _context.Transaction.Where(t => t.UserId == userId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        var transaction = await _context.Transaction.FindAsync(id);

        if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }

        return transaction;
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    {
        transaction.UserId = User.FindFirstValue(ClaimTypes.Name);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        transaction.UserId = userId;

        try
        {
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }

        return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);


    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
    {
        if (id != transaction.Id)
        {
            return BadRequest();
        }

        var existingTransaction = await _context.Transaction.FindAsync(id);
        if (existingTransaction == null || existingTransaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }

        existingTransaction.Amount = transaction.Amount;
        existingTransaction.Category = transaction.Category;
        existingTransaction.Date = transaction.Date;
        existingTransaction.Type = transaction.Type;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.Transaction.FindAsync(id);
        if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }

        _context.Transaction.Remove(transaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}