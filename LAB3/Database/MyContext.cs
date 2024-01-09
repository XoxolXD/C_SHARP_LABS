using Microsoft.EntityFrameworkCore;
using NLab3.Models;

namespace NLab3.Database;

public class MyContext:DbContext
{
    public DbSet<Operation>? Operations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Calendar.db");
    }
}
