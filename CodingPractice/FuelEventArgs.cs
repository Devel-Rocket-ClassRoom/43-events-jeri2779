using System;

class FuelEventArgs : EventArgs
    {
        public int FuelLevel { get; }
        public string Warning {  get; }
        public FuelEventArgs(int fuelLevel, string warning)
        {
            FuelLevel = fuelLevel;
            Warning = warning;
        }
    }
