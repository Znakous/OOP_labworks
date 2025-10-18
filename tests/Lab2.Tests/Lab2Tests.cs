using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Writers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Lab2Tests
{
    [Fact]
    public void Message_Should_BeUnread_When_ReceivedByUser()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium());
        user.ReceiveMessage(message);
        Assert.Equal(MessageStatus.Unread, user.MessageStatus[message]);
    }

    [Fact]
    public void Message_Should_BeRead_When_ReadByUser()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium());
        user.ReceiveMessage(message);
        user.ReadMessage(message);
        Assert.Equal(MessageStatus.Read, user.MessageStatus[message]);
    }

    [Fact]
    public void ReadMessage_Should_ReturnFailure_When_CalledOnReadMessage()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium());
        user.ReceiveMessage(message);
        user.ReadMessage(message);
        Assert.IsType<MessageReadResult.Failure>(user.ReadMessage(message));
        Assert.Equal(MessageStatus.Read, user.MessageStatus[message]);
    }

    [Fact]
    public void User_Shoul_NotReceiveMessage_When_FilterStopsMessage()
    {
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new FilterDecorator(mockRecipient, ImportanceLevel.High());
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low());
        filter.AddMessage(message);
        mockRecipient.Received(0).AddMessage(Arg.Any<Message>());
    }

    [Fact]
    public void Log_Should_BeCalled_When_MessageIsAddedToLoggerDecorator()
    {
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        ILogger mockLogger = Substitute.For<ILogger>();
        var logger = new LoggerDecorator(mockRecipient, mockLogger);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low());
        logger.AddMessage(message);
        mockLogger.Received(2).Log(Arg.Any<string>());
    }

    [Fact]
    public void WriteHeader_Shoul()
    {
        IWriter mockWriter = Substitute.For<IWriter>();
        var formatingArchiver = new FormatingArchiver(mockWriter);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low());
        formatingArchiver.AddMessage(message);
        mockWriter.Received(1).WriteHeader(Arg.Any<string>());
        mockWriter.Received(1).WriteBody(Arg.Any<string>());
    }

    [Fact]
    public void AddMessage_Should_ReceiveOneCall_When_BeingCalleddirectlyAndThroughFilter()
    {
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new FilterDecorator(mockRecipient, ImportanceLevel.High());
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium());
        filter.AddMessage(message);
        mockRecipient.AddMessage(message);
        mockRecipient.Received(1).AddMessage(Arg.Any<Message>());
    }
}