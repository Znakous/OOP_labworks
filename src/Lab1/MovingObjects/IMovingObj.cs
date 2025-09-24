using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

namespace Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;

public interface IMovingObj
{
    Speed ObjSpeed { get; }

    Acceleration ObjAcceleration { get; }

    Weight ObjWeight { get; }

    Force ObjForceThreshold { get; }

    bool TryApplyForce(Force force);

    Time? CountTime(Coordinate distance);
}