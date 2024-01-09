namespace NLab2.View;

public class MyView : IMyView
{
    public void ShowInfo()
    {
        Console.WriteLine("Usage:\n" +
                          "Use on of commands:\n" +
                          "\"check\" to check is year leap\n" +
                          "\"calc\" to calc interval length\n" +
                          "\"day\" to get the name of day of week\n" +
                          "\"quit\" to exit.");
    }

    public string CommandQuery()
    {
        Console.WriteLine("Input the command:");
        var input = Console.ReadLine() ?? "";
        return input;
    }

    public int YearQuery()
    {
        Console.WriteLine("Input the year:");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid)
            throw new Exception("Wrong input.");
        return n;
    }

    public DateTime FullDateQuery()
    {
        var date = "";
        Console.WriteLine("Input the year:");
        var isValid = int.TryParse(Console.ReadLine(), out var year);
        if (!isValid)
            throw new Exception("Wrong input.");
        date += year + ".";

        Console.WriteLine("Input the month:");
        isValid = int.TryParse(Console.ReadLine(), out var month);
        if (!isValid || month < 1 || month > 12)
            throw new Exception("Wrong input.");
        date += month + ".";

        Console.WriteLine("Input the day:");
        isValid = int.TryParse(Console.ReadLine(), out var day);
        if (!isValid || day < 1 || day > 31)
            throw new Exception("Wrong input.");
        date += day.ToString();

        return Convert.ToDateTime(date);
    }

    public void ShowIsLeap(bool isleap, int year)
    {
        Console.WriteLine($"Is year {year} leap? {isleap}");
    }

    public void ShowInterval(int interval)
    {
        Console.WriteLine("Interval between dates: " + interval + " days");
    }

    public void ShowDay(DayOfWeek dayOfWeek)
    {
        Console.WriteLine(dayOfWeek);
    }
}
