using System;

class Module1
{
    public Module1()
    {
        GlobalNotifier.OnGlobalMessage += HandleGlobalMessage;

    }
    private void HandleGlobalMessage(string message)
    {
        Console.WriteLine($"[Module1] 수신: {message}");
    }
}
