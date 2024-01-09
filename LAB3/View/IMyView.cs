using NLab3.Models;

namespace NLab3.View;

public interface IMyView
{
    public void ShowInfo();
    public string CommandQuery();
    public int YearQuery();
    public DateTime FullDateQuery();
    public void ShowIsLeap(bool isleap, int year);
    public void ShowInterval(int interval);
    public void ShowDay(DayOfWeek dayOfWeek);
    public int OptionsQuery();
    public void ShowOperations(List<Operation> operations);
}
