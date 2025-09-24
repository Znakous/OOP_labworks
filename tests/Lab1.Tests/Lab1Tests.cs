using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Routing;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Tests
{
    [Theory]
    [MemberData(nameof(Scenario1))]
    [MemberData(nameof(Scenario2))]
    [MemberData(nameof(Scenario3))]
    [MemberData(nameof(Scenario4))]
    [MemberData(nameof(Scenario5))]
    [MemberData(nameof(Scenario6))]
    [MemberData(nameof(Scenario7))]
    [MemberData(nameof(Scenario8))]
    public void Tester(IEnumerable<IRoutePart> routeSegments, IMovingObj movingObj, PassResult expectedResult)
    {
        var route = new Route(routeSegments);
        PassResult result = route.ByPass(movingObj);
        Assert.Equal(expectedResult.GetType(), result.GetType());
        if (expectedResult is PassResult.Success expectedSuccess)
        {
            Assert.Equal(expectedSuccess.TimeTaken, ((PassResult.Success)result).TimeTaken);
        }
    }

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario1 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(1), new Force(10)),
                new CommonPath(new Coordinate(1)),
                new EndPoint(new Speed(100)),
            },
            new Train(new Weight(2), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Success(new Time(2))
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario2 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(1), new Force(11)),
                new CommonPath(new Coordinate(1)),
                new EndPoint(new Speed(1000)),
            },
            new Train(new Weight(2), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Failure.ForceThresholdExceeded()
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario3 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(6), new Force(1)),
                new CommonPath(new Coordinate(3)),
                new Station(new Speed(1000), new Time(1)),
                new EndPoint(new Speed(100)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Success(new Time(5))
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario4 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(15), new Force(1)),
                new Station(new Speed(3), new Time(1)),
                new CommonPath(new Coordinate(3)),
                new EndPoint(new Speed(10000)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Failure.SpeedLimitExceeded()
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario5 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(15), new Force(1)),
                new Station(new Speed(5), new Time(1)),
                new CommonPath(new Coordinate(3)),
                new EndPoint(new Speed(4)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Failure.SpeedLimitExceeded()
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario6 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(28), new Force(1)),
                new CommonPath(new Coordinate(3)),
                new PowerPath(new Coordinate(11), new Force(-1)),
                new Station(new Speed(5), new Time(1)),
                new CommonPath(new Coordinate(3)),
                new PowerPath(new Coordinate(21), new Force(1)),
                new CommonPath(new Coordinate(3)),
                new PowerPath(new Coordinate(18), new Force(-1)),
                new EndPoint(new Speed(5)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Success(new Time(19))
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario7 => new()
    {
        {
            new List<IRoutePart>
            {
                new CommonPath(new Coordinate(3)),
                new EndPoint(new Speed(5)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Failure.InsufficientSpeed()
        },
    };

    public static TheoryData<IEnumerable<IRoutePart>, Train, PassResult> Scenario8 => new()
    {
        {
            new List<IRoutePart>
            {
                new PowerPath(new Coordinate(30), new Force(3)),
                new PowerPath(new Coordinate(30), new Force(-6)),
            },
            new Train(new Weight(1), new Speed(0), new Acceleration(0), new Force(10), new Time(1)),
            new PassResult.Failure.InsufficientSpeed()
        },
    };
}