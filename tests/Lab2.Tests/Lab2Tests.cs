using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Lab2Tests
{
    [Fact]
    public void User_Should_SaveMessageUnread()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);
        user.ReceiveMessage(message);
        Assert.Equal(MessageStatus.Unread, user.MessageStatus[message]);
    }

    [Fact]
    public void User_Should_ReadMessage()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);
        user.ReceiveMessage(message);
        Assert.IsType<MessageReadResult.Success>(user.ReadMessage(message));
        Assert.Equal(MessageStatus.Read, user.MessageStatus[message]);
    }

    [Fact]
    public void User_Should_NotifyAfterReadingMessageTwice()
    {
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);
        user.ReceiveMessage(message);
        user.ReadMessage(message);
        Assert.IsType<MessageReadResult.Failure>(user.ReadMessage(message));
        Assert.Equal(MessageStatus.Read, user.MessageStatus[message]);
    }

    [Fact]
    public void FilterProxy_Should_StopNotImportantMessages()
    {
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new FilterProxy(mockRecipient, ImportanceLevel.Medium);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);
        filter.AddMessage(message);
        mockRecipient.Received(0).AddMessage(Arg.Any<Message>());
    }

    [Fact]
    public void LoggerProxy_Should_CallLoggerAfterAddingMessage()
    {
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        ILogger mockLogger = Substitute.For<ILogger>();
        var logger = new LoggerProxy(mockRecipient, mockLogger);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);
        logger.AddMessage(message);
        mockLogger.Received(1).Log(Arg.Any<Message>());
    }

    [Fact]
    public void FormatingArchiver_Should_WriteHeaderAndBodySeparately()
    {
        IFormatter mockFormatter = Substitute.For<IFormatter>();
        var formatingArchiver = new FormatingArchiver(mockFormatter);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);
        formatingArchiver.AddMessage(message);
        mockFormatter.Received(1).WriteHeader(Arg.Any<string>());
        mockFormatter.Received(1).WriteBody(Arg.Any<string>());
    }

    [Fact]
    public void User_Should_ReceiveMessageTwiceWhileHavingTwoRecipients()
    {
        var user = new User();
        IRecipient mockRecipient = Substitute.ForTypeForwardingTo<IRecipient, UserRecipient>(user);
        var filter = new FilterProxy(mockRecipient, ImportanceLevel.Urgent);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.High);
        filter.AddMessage(message);
        mockRecipient.AddMessage(message);
        mockRecipient.Received(1).AddMessage(Arg.Any<Message>());
    }
}