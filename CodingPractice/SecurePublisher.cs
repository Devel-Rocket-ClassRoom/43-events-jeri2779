using System;

class SecurePublisher
{
    private EventHandler _myEvent;
    private readonly object _lock = new object();   
    public event EventHandler MyEvent
    {
        add
        {
            lock (_lock)
            {
                Console.WriteLine($"구독자 추가: {value.Method.Name}");
                _myEvent += value;
            }
        }
        remove
        {
            lock (_lock)
            {
                Console.WriteLine($"구독자 제거: {value.Method.Name}");
                _myEvent -= value;
            }
        }
    }
    public void RaiseEvent()
    {
        _myEvent?.Invoke(this, EventArgs.Empty);
    }
}

