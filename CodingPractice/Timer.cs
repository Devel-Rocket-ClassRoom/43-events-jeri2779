using System;

class Timer
{
    public event Action Tick;
    private int _count;

    public void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            _count++;
            Console.WriteLine($"타이머: {_count}");
            Tick?.Invoke();
        }
    }
}

