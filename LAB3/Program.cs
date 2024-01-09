using NLab3.Controller;
using NLab3.Models;
using NLab3.Repositories;
using NLab3.View;

namespace NLab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var operations = new List<Operation>();
        var myView = new MyView();
        var myRepository = new MyRepository();
        var myController = new MyController(operations, myView, myRepository);
        myController.Run();
    }
}
