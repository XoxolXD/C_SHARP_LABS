using NLab2.Controller;
using NLab2.View;

namespace NLab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var myView = new MyView();
        var myController = new MyController(myView);
        myController.Run();
    }
}
