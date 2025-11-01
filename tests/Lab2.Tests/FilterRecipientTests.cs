using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FilterRecipientTests
{
    [Fact]
    public void Recipient_Should_NotReceiveMessage_When_FilterStopsMessage()
    {
        // arrange
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new FilterRecipient(mockRecipient, ImportanceLevel.High);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Low);

        // act
        filter.ReceiveMessage(message);

        // assert
        mockRecipient.Received(0).ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void AddMessage_Should_ReceiveOneCall_When_BeingCalleddirectlyAndThroughFilter()
    {
        // arrange
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new FilterRecipient(mockRecipient, ImportanceLevel.High);
        var message = new Message("aboba", "aboba goes for a stroll", ImportanceLevel.Medium);

        // act
        filter.ReceiveMessage(message);
        mockRecipient.ReceiveMessage(message);

        // assert
        mockRecipient.Received(1).ReceiveMessage(Arg.Any<Message>());
    }
}