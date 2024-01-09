using Microsoft.EntityFrameworkCore;
using NLab4.Models;

namespace NLab4.Database;

public class MyContext:DbContext
{
    public DbSet<Operation>? Operations { get; set; }
    
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
