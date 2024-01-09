using Moq;
using NLab3.Controller;
using NLab3.Models;
using NLab3.Repositories;
using NLab3.View;

namespace NLab3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(1888)]
    [InlineData(1996)]
    public void CheckTest(int year)
    {
        var myView = new MyView();
        var operations = new List<Operation>();
        var mock = new Mock<IMyRepository>();
        var myController = new MyController(operations, myView, mock.Object);
        Assert.True(myController.Check(year));
    }

    [Fact]
    public void DayTest()
    {
        var operations = new List<Operation>();
        var myView = new MyView();
        var mock = new Mock<IMyRepository>();
        var myController = new MyController(operations, myView, mock.Object);
        Assert.Equal("Friday", myController.Day(new DateTime(2024, 01, 05)).ToString());
    }
}
