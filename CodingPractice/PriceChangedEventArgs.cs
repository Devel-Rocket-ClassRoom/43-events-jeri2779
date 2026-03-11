using System;

class PriceChangedEventArgs : EventArgs
{
    public decimal OldPrice { get; }
    public decimal NewPrice { get; }
    public decimal ChangeAmount { get; }

    public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;
        if(oldPrice != 0)
        {
            ChangeAmount = (newPrice - oldPrice) / oldPrice * 100;
        }
    }

    
}
