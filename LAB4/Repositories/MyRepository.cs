using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLab4.Database;
using NLab4.Models;

namespace NLab4.Repositories;

public class MyRepository : IMyRepository
{
    private readonly MyContext _context;

    public MyRepository(MyContext context)
    {
        _context = context;
    }

    public Task Add(Operation operation)
    {
       _context.Operations.Add(operation);
       return _context.SaveChangesAsync();
    }

    public Task<bool> Check(int year)
    {
        Add(new Operation { Name = "check", Result = (year % 4 == 0).ToString() });
        return Task.FromResult(year % 4 == 0);
    }

    public Task<int> Calc(DateTime first, DateTime second)
    {
        var interval = second - first;
       Add(new Operation { Name = "calc", Result = Math.Abs(interval.Days).ToString() });
        return Task.FromResult(Math.Abs(interval.Days));
    }

    public Task<string> Day(DateTime dateTime)
    {
        Add(new Operation { Name = "day", Result = dateTime.DayOfWeek.ToString() });
        return Task.FromResult(dateTime.DayOfWeek.ToString());
    }

    public Task<List<Operation>> ShowOperations()
    {
        return _context.Operations.ToListAsync();
    }
}
