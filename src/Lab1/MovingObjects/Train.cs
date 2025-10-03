using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

namespace Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;

public struct Train : IMovingObj
{
    private readonly Time _precision;

    public Speed ObjSpeed { get; private set; }

    public Acceleration ObjAcceleration { get; private set; }

    public Weight ObjWeight { get; private set; }

    public Force ObjForceThreshold { get; private set; }

    public Train(Weight weight, Speed speed, Acceleration acceleration, Force forceThreshold, Time precision)
    {
        ObjWeight = weight;
        ObjSpeed = speed;
        ObjAcceleration = acceleration;
        ObjForceThreshold = forceThreshold;
        _precision = precision;
    }

    public bool TryApplyForce(Force force)
    {
        if (force > ObjForceThreshold)
        {
            return false;
        }

        ApplyForce(force);
        return true;
    }

    public Time? CountTime(Coordinate distance)
    {
        var curDistance = new Coordinate(0);
        bool passedThrough = true;
        var resultTime = new Time(0);
        while (curDistance < distance)
        {
            ObjSpeed += ObjAcceleration * _precision;
            curDistance += Coordinate.Create(ObjSpeed, _precision);
            resultTime += _precision;
            if (ObjSpeed <= new Speed(0) && ObjAcceleration <= new Acceleration(0))
            {
                passedThrough = false;
                break;
            }
        }

        return passedThrough ? resultTime : null;
    }

    private void ApplyForce(Force force)
    {
        ObjAcceleration = Acceleration.Create(force, ObjWeight);
    }
}