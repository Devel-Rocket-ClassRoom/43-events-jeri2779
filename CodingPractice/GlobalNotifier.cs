using System;

class GlobalNotifier
{
    public static event Action<string> OnGlobalMessage;
    public static void SendMessage(string message)
    {
        Console.WriteLine($"[Global] 메세지 전송: {message}");
        OnGlobalMessage?.Invoke(message);
    }
}
