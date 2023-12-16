using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {

        string sender = "Angel";
        string message = "Hello";

        this._chatRoom.SendMessage(sender,message);
        string result = this._chatRoom.DisplayChat();

        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain("Angel: Hello - Sent at "));

    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        
       
        string result = this._chatRoom.DisplayChat();

        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        string sender = "Angel";
        string message = "Hello";
        string sender2 = "Pesho";
        string message2 = "Hi";

        this._chatRoom.SendMessage(sender, message);
        this._chatRoom.SendMessage(sender2, message2);
        string result = this._chatRoom.DisplayChat();

        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain("Angel: Hello - Sent at "));
        Assert.That(result, Does.Contain("Pesho: Hi - Sent at "));

    }
}
