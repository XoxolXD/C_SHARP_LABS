using NLab3.Models;
using NLab3.Repositories;
using NLab3.View;

namespace NLab3.Controller;

public class MyController
{
    private List<Operation> _operations;
    private readonly IMyView _myView;
    private readonly IMyRepository _myRepository;

    public MyController(List<Operation> operations, IMyView myView, IMyRepository myRepository)
    {
        _myRepository = myRepository;
        _operations = operations;
        _myView = myView;
    }

    public bool Check(int year)
    {
        return year % 4 == 0;
    }

    public int Calc(DateTime first, DateTime second)
    {
        var interval = second - first;
        return Math.Abs(interval.Days);
    }

    public DayOfWeek Day(DateTime dateTime)
    {
        return dateTime.DayOfWeek;
    }

    public void Add(string name, string result)
    {
        _operations.Add(new Operation { Name = name, Result = result });
    }

    public void Run()
    {
        var options = _myView.OptionsQuery();
        switch (options)
        {
            case 1:
                _operations = _myRepository.DbLoad();
                break;
            case 2:
                _operations = _myRepository.JsonLoad();
                break;
        }

        _myView.ShowInfo();
        var running = true;
        while (running)
        {
            var command = _myView.CommandQuery();
            switch (command)
            {
                case "check":
                    var year = _myView.YearQuery();
                    _myView.ShowIsLeap(Check(year), year);
                    Add("check", Check(year).ToString());
                    break;
                case "calc":
                    var first = _myView.FullDateQuery();
                    var second = _myView.FullDateQuery();
                    _myView.ShowInterval(Calc(first, second));
                    Add("calc", Calc(first, second).ToString());
                    break;
                case "day":
                    var fulldate = _myView.FullDateQuery();
                    _myView.ShowDay(Day(fulldate));
                    Add("day", Day(fulldate).ToString());
                    break;
                case "operations":
                    _myView.ShowOperations(_operations);
                    break;
                case "quit":
                    running = !running;
                    break;
            }
        }

        switch (options)
        {
            case 1:
                _myRepository.DbSave(_operations);
                break;
            case 2:
                _myRepository.JsonSave(_operations);
                break;
        }
    }
}
