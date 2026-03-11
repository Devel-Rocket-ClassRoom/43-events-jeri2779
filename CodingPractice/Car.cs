using System;

class Car
{
    private int _fuelLevel;
    
    public event EventHandler<FuelEventArgs> FuelLow;
    public event Action<int>  FuelChanged;

    public Car(int initialFuel)
    {
        _fuelLevel = initialFuel;
    }

    public int FuelLevel => _fuelLevel;

    public void Drive()
    {
        if(_fuelLevel <= 0)
        {
            Console.WriteLine("연료 없음! 운전 불가");
            return;
        }

        _fuelLevel -= 10;
        Console.WriteLine($"운전 중 ... 연료: {_fuelLevel}%");

        if(_fuelLevel <= 0)
        {
            OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 바닥났습니다!"));
            
        }
        else if(_fuelLevel <= 20)
        {
            OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 부족합니다!"));
        }  
    }
    protected virtual void OnFuelLow(FuelEventArgs e)
    {
        FuelLow?.Invoke(this, e);
    }
}

