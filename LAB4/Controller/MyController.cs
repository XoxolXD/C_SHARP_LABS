using Microsoft.AspNetCore.Mvc;
using NLab4.Models;
using NLab4.Repositories;

namespace NLab4.Controller;

[ApiController]
public class MyController:ControllerBase
{
    private readonly IMyRepository _myRepository;

    public MyController(  IMyRepository myRepository)
    {
        _myRepository = myRepository;
    }

    [HttpGet]
    [Route("/check")]
    public Task<bool> Check(int year)
    {
        _myRepository.Add(new Operation { Name = "check", Result = (year % 4 == 0).ToString() });
        return Task.FromResult(year % 4 == 0);
    }

    [HttpGet]
    [Route("/calc")]
    public Task<int> Calc(DateTime first, DateTime second)
    {
        var interval = second - first;
        _myRepository.Add(new Operation { Name = "check", Result = Math.Abs(interval.Days).ToString() });
        return _myRepository.Calc(first, second);
    }
    
    [HttpGet]
    [Route("/day")]
    public Task<string> Day(DateTime dateTime)
    {
        _myRepository.Add(new Operation { Name = "day", Result = dateTime.DayOfWeek.ToString() });
        return _myRepository.Day(dateTime);
    }
    
    [HttpGet]
    [Route("/operations")]
    public Task<List<Operation>> ShowOperations()
    {
        return _myRepository.ShowOperations();
    }
}
