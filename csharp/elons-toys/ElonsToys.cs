using System;

class RemoteControlCar
{
    private int _driveCallsCount = 0;
    private const int PercentPerDriveCall = 1;
    private const int MetersPerDriveCall = 20;
    public static RemoteControlCar Buy() => new();
    public string DistanceDisplay() => $"Driven {Distance()} meters";
    public string BatteryDisplay() => BatteryPercent() == 0
        ? "Battery empty"
        : $"Battery at {BatteryPercent()}%";
    public int BatteryPercent() => 100 - _driveCallsCount * PercentPerDriveCall;
    public int Distance() => _driveCallsCount * MetersPerDriveCall;
    public void Drive() { if (BatteryPercent() >= PercentPerDriveCall) _driveCallsCount++; }
}
