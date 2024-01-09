using NLab2.Controller;
using NLab2.View;

namespace NLab2.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(1888)]
    [InlineData(1996)]
    public void CheckTest(int year)
    {
        var myView = new MyView();
        var myController = new MyController(myView);
        Assert.True(myController.Check(year));
    }

    [Fact]
    public void DayTest()
    {
        var myView = new MyView();
        var myController = new MyController(myView);
        Assert.Equal("Friday", myController.Day(new DateTime(2024, 01, 05)).ToString());
    }
}
