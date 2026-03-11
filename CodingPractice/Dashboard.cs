using System;

class Dashboard
{
    public void Subscribe(Car car)
    {
        car.FuelChanged += OnFuelChanged;
        car.FuelLow += OnFuelLow;
    }

    public void Unsubscribe(Car car)
    {
        car.FuelChanged -= OnFuelChanged;
        car.FuelLow -= OnFuelLow;
    }
    private void OnFuelChanged(int fuelLevel)
    {
        string gauge = new string('█', fuelLevel / 10);
        Console.WriteLine($"[대시보드] 연료 게이지: {gauge}");
    }   

    public void OnFuelLow(object sender, FuelEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[경고!] {e.Warning} (잔량: {e.FuelLevel}%)");
        Console.ResetColor();
    }
}

