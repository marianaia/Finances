using Microsoft.EntityFrameworkCore;
using MyFinance.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transaction { get; set; }
}