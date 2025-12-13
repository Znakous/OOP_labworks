namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

public abstract class FlagParseResult<T>
{
    public T Builder { get; }

    public bool Remaining { get; }

    protected FlagParseResult(T builder, bool remaining)
    {
        Builder = builder;
        Remaining = remaining;
    }

    public sealed class Success : FlagParseResult<T>
    {
        public Success(T builder, bool remaining) : base(builder, remaining) { }
    }

    public sealed class Failure : FlagParseResult<T>
    {
        public Failure(T builder, bool remaining) : base(builder, remaining) { }
    }
}