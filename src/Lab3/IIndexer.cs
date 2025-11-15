namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IIndexer
{
    int Value { get; }

    void Increment();

    void ChangeModule(int newModule);
}