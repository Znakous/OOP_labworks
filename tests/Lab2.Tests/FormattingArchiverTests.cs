using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FormattingArchiverTests
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

    [Fact]
    public void Formatter_Should_WriteHeaderAndBodyOnce_When_MessageAddedToFormattingArchiver()
    {
        // arrange
        IFormatter mockFormatter = Substitute.For<IFormatter>();
        var formatingArchiver = new FormatingArchiver(mockFormatter);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);

        // act
        formatingArchiver.ReceiveMessage(message);

        // assert
        mockFormatter.Received(1).WriteHeader(Arg.Any<string>());
        mockFormatter.Received(1).WriteBody(Arg.Any<string>());
    }
}