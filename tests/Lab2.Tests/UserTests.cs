using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class UserTests
{
    [Fact]
    public void Message_Should_BeUnread_When_ReceivedByUser()
    {
        // arrange
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);

        // act
        user.ReceiveMessage(message);

        // assert
        Assert.Equal(MessageStatus.Unread, user.GetMessageStatus(message));
    }

    [Fact]
    public void Message_Should_BeRead_When_ReadByUser()
    {
        // arrange
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);

        // act
        user.ReceiveMessage(message);
        user.ReadMessage(message);

        // assert
        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }

    [Fact]
    public void ReadMessage_Should_ReturnFailure_When_CalledOnReadMessage()
    {
        // arrange
        var user = new User();
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);

        // act
        user.ReceiveMessage(message);
        user.ReadMessage(message);

        // assert
        Assert.IsType<MessageReadResult.Failure>(user.ReadMessage(message));
        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }
}