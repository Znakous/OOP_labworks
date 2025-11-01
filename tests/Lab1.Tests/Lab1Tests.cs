using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Routing;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Tests
{
    [Fact]
    public void ByPass_Should_Succeed_When_MaxSpeedReachedOnCommonPath()
    {
        var train = new Train(new Weight(2), new Speed(0), new Acceleration(0), new Force(10), new Time(1));
        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(1), new Force(10)),
            new CommonPath(new Distance(1)),
        };
        var stoppingCapability = new Speed(100);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Success>(result);
    }

    [Fact]
    public void ByPass_Should_Fail_When_PowerPathPushedTooHard()
    {
        var train = new Train(new Weight(2), new Speed(0), new Acceleration(0), new Force(10), new Time(1));
        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(1), new Force(11)),
            new CommonPath(new Distance(1)),
        };
        var stoppingCapability = new Speed(1000);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Failure>(result);
    }

    [Fact]
    public void ByPass_Should_Succeed_When_PassingStation()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(6), new Force(1)),
            new CommonPath(new Distance(3)),
            new Station(new Speed(1000), new Time(1)),
        };
        var stoppingCapability = new Speed(1000);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Success>(result);
    }

    [Fact]
    public void ByPass_Should_Fail_When_StationThresholdExceeded()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(15), new Force(1)),
            new Station(new Speed(3), new Time(1)),
            new CommonPath(new Distance(3)),
        };
        var stoppingCapability = new Speed(10000);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Failure>(result);
    }

    [Fact]
    public void ByPass_Should_Fail_When_SpeedLimitExceeded()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(15), new Force(1)),
            new CommonPath(new Distance(3)),
            new Station(new Speed(5), new Time(1)),
            new CommonPath(new Distance(3)),
        };

        var stoppingCapability = new Speed(4);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Failure>(result);
    }

    [Fact]
    public void ByPass_Should_Succeed_When_SpeedupOverThresholdThenSlowDownToThreshold()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(28), new Force(1)),
            new CommonPath(new Distance(3)),
            new PowerPath(new Distance(11), new Force(-1)),
            new Station(new Speed(5), new Time(1)),
            new CommonPath(new Distance(3)),
            new PowerPath(new Distance(21), new Force(1)),
            new CommonPath(new Distance(3)),
            new PowerPath(new Distance(18), new Force(-1)),
        };

        var stoppingCapability = new Speed(5);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Success>(result);
    }

    [Fact]
    public void ByPass_Should_Fail_When_NoSpeedGiven()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new CommonPath(new Distance(3)),
        };

        var stoppingCapability = new Speed(5);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Failure>(result);
    }

    [Fact]
    public void ByPass_Should_Fail_When_StoppedOnRoute()
    {
        var train = new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1));

        var sections = new List<IRoutePart>
        {
            new PowerPath(new Distance(30), new Force(3)),
            new PowerPath(new Distance(30), new Force(-6)),
        };

        var stoppingCapability = new Speed(10000);
        var route = new Route(sections, stoppingCapability);
        RouteBypassResult result = route.ByPass(train);
        Assert.IsType<RouteBypassResult.Failure>(result);
    }
}