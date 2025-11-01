using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggerRecipientTests
{
    [Fact]
    public void Log_Should_BeCalled_When_MessageIsAddedToLoggerDecorator()
    {
        // arrange
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        ILogger mockLogger = Substitute.For<ILogger>();
        var logger = new LoggerRecipient(mockRecipient, mockLogger);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);

        // act
        logger.ReceiveMessage(message);

        // assert
        mockLogger.Received(2).Log(Arg.Any<string>());
    }
}