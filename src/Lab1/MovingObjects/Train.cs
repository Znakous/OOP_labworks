using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.TrainErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;

public class Train
{
    private readonly Time _precision;

    private readonly Weight _weight;

    private readonly Force _forceThreshold;

    private Acceleration _acceleration;

    public Speed CurSpeed { get; private set; }

    public Train(Weight weight, Speed speed, Acceleration acceleration, Force forceThreshold, Time precision)
    {
        CurSpeed = speed;
        _weight = weight;
        _acceleration = acceleration;
        _forceThreshold = forceThreshold;
        _precision = precision;
    }

    public bool TryApplyForce(Force force)
    {
        if (force > _forceThreshold)
        {
            return false;
        }

        ApplyForce(force);
        return true;
    }

    public TrainMoveResult Move(Distance distance)
    {
        var curDistance = Distance.Zero();
        var resultTime = Time.Zero();
        while (curDistance < distance)
        {
            CurSpeed += Speed.Create(_acceleration, _precision);
            curDistance += Distance.Create(CurSpeed, _precision);
            resultTime += _precision;
            if (CurSpeed <= Speed.Zero() && _acceleration <= Acceleration.Zero())
            {
                return new TrainMoveResult.Failure(new TrainStopped("Train stopped"));
            }
        }

        return new TrainMoveResult.Success(resultTime);
    }

    private void ApplyForce(Force force)
    {
        _acceleration = Acceleration.Create(force, _weight);
    }
}