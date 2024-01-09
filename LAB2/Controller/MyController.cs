using NLab2.View;

namespace NLab2.Controller;

public class MyController
{
    private readonly IMyView _myView;

    public MyController(IMyView myView)
    {
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


    public void Run()
    {
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
                    break;
                case "calc":
                    var first = _myView.FullDateQuery();
                    var second = _myView.FullDateQuery();
                    _myView.ShowInterval(Calc(first, second));
                    break;
                case "day":
                    _myView.ShowDay(Day(_myView.FullDateQuery()));
                    break;
                case "quit":
                    running = !running;
                    break;
            }
        }
    }
}
