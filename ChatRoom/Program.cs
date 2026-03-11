using System;

// README.md를 읽고 아래에 코드를 작성하세요.
 
ChatRoom chatRoom = new ChatRoom();
ChatLogger logger = new ChatLogger();
NotificationService notificationService = new NotificationService();

chatRoom.MessageReceived += logger.TakeMessage;
chatRoom.MessageReceived += notificationService.TakeMessage;

chatRoom.SendMessage("철수", "안녕하세요");
chatRoom.SendMessage("영희", "긴급 회의가 있습니다");
chatRoom.SendMessage("민수", "점심 뭐 먹을까요?");

class ChatRoom
{
    public event Action<string, string> MessageReceived;

    public void SendMessage(string sender, string message)
    {
        MessageReceived?.Invoke(sender, message);
        //Console.WriteLine($"{sender}: {message}");
    }
}

class ChatLogger
{
    public void TakeMessage(string sender, string message)
    {
        Console.WriteLine($"[Log] {sender}: {message}");
    }   
}

class NotificationService
{
    public void TakeMessage(string sender, string message)
    {
        if (message.Contains("긴급"))
        {
            Console.WriteLine("[알림] 긴급 메시지 수신!");
        }
    }
}

