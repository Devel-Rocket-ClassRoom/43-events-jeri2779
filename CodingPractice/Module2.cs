using System;

class Module2
{
    public Module2()
    {
        GlobalNotifier.OnGlobalMessage += HandleGlobalMessage;

    }
    private void HandleGlobalMessage(string message)
    {
        Console.WriteLine($"[Module2] 수신: {message}");
    }
}

