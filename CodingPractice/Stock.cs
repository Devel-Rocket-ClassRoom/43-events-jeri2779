using System;

class Stock
{
    private string _symbol;
    private decimal _price;

    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    public Stock(string symbol, decimal initialPrice)
    {
        _symbol = symbol;
        _price = initialPrice;
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price == value)
            {
                return;
            }
            decimal oldPrice = _price;
            _price = value;

            OnPriceChanged(new PriceChangedEventArgs(oldPrice, _price));
        }
    }
    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
    public override string ToString()
    {
        return $"{_symbol}: {_price:C}";
    }

}
