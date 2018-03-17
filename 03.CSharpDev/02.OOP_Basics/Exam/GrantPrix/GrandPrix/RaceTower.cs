using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int totalLapsNumer;
    public int completedLapsnumber;
    private int totalTrackLength;
    private Dictionary<string, Driver> drivers;
    private List<Tuple<string, string>> crashedDrivers;
    private string weather;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;

    public RaceTower()
    {
        this.weather = "Sunny";
        this.completedLapsnumber = 0;
        this.drivers = new Dictionary<string, Driver>();
        this.crashedDrivers = new List<Tuple<string, string>>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        totalLapsNumer = lapsNumber;
        totalTrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Tyre tyre = this.tyreFactory.GetTyre(commandArgs);
            string driverName = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            var car = new Car(hp, fuelAmount, tyre);
            var driver = this.driverFactory.GetDriver(commandArgs, car);
            if (!this.drivers.ContainsKey(driverName))
            {
                this.drivers.Add(driverName, driver);
            }
        }
        catch (ArgumentException e)
        {
            // ignored
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.drivers[driverName];
        // driver.TotalTime += 20.0;
        switch (reasonToBox)
        {
            case "ChangeTyres":
                var tyreType = commandArgs[2];
                var tyreHardness = double.Parse(commandArgs[3]);
                switch (tyreType)
                {
                    case "Hard":
                        driver.Car.SetTyre(new HardTyre(tyreHardness));
                        break;
                    case "Ultrasoft":
                        var tyreGrip = double.Parse(commandArgs[5]);
                        driver.Car.SetTyre(new UltrasoftTyre(tyreHardness, tyreGrip));
                        break;
                }
                break;
            case "Refuel":
                driver.Car.Refuel(double.Parse(commandArgs[2]));
                break;
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int laps = int.Parse(commandArgs[0]);
        if (laps + this.completedLapsnumber > totalLapsNumer)
        {
            throw new ArgumentException($"There is no time! On lap {completedLapsnumber}.");
        }

        var sb = new StringBuilder();

        for (int i = 0; i < laps; i++)
        {
            this.completedLapsnumber++;

            foreach (var driver in drivers.Values.OrderBy(x => x.TotalTime))
            {
                try
                {
                    // driver.TotalTime += 60.0 / ((double)totalTrackLength / driver.Speed);
                    driver.Car.BurnFuel(totalTrackLength * driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.CompleteLap();
                }
                catch (ArgumentException e)
                {
                    crashedDrivers.Add(new Tuple<string, string>(driver.Name, e.Message));
                }
            }

            for (int j = 0; j < crashedDrivers.Count; j++)
            {
                if (this.drivers.ContainsKey(crashedDrivers[j].Item1))
                {
                    this.drivers.Remove(crashedDrivers[j].Item1);
                }
            }

            sb.AppendLine(TryOvertakeOtherCars());

            for (int j = 0; j < crashedDrivers.Count; j++)
            {
                if (this.drivers.ContainsKey(crashedDrivers[j].Item1))
                {
                    this.drivers.Remove(crashedDrivers[j].Item1);
                }
            }
        }

        return sb.ToString().TrimEnd();
    }

    private string TryOvertakeOtherCars()
    {
        StringBuilder stringBuilder = new StringBuilder();
        var driversDescending = drivers.Values.OrderByDescending(x => x.TotalTime).ToList();
        for (int j = 0; j < drivers.Count - 1; j++)
        {
            Driver firstDriver = driversDescending[j];
            Driver secondDriver = driversDescending[j + 1];
            double diff = Math.Abs(secondDriver.TotalTime - firstDriver.TotalTime);
            int interval = 0;

            bool aggressiveDriver = firstDriver is AggressiveDriver && firstDriver.Car.Tyre is UltrasoftTyre && diff <= 3;
            bool enduranceDriver = firstDriver is EnduranceDriver && firstDriver.Car.Tyre is HardTyre && diff <= 3;

            if ((aggressiveDriver && this.weather == "Foggy") || (enduranceDriver && this.weather == "Rainy"))
            {
                crashedDrivers.Add(new Tuple<string, string>(firstDriver.Name, "Crashed"));
                continue;
            }

            if (enduranceDriver || aggressiveDriver)
            {
                interval = 3;
            }
            else if (diff <= 2)
            {
                interval = 2;
            }

            if (interval != 0)
            {
                // secondDriver.TotalTime += interval;
                // firstDriver.TotalTime -= interval;
                // driversDescending = driversDescending.OrderByDescending(x => x.TotalTime).ToList();
                stringBuilder.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.completedLapsnumber}.");
                // j++;
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Lap {this.completedLapsnumber}/{this.totalLapsNumer}");

        int count = 1;
        foreach (var driver in drivers.Values.OrderBy(x => x.TotalTime))
        {
            sb.AppendLine($"{count} {driver.Name} {driver.TotalTime:f3}");
            count++;
        }

        for (int i = crashedDrivers.Count - 1; i >= 0; i--)
        {
            sb.AppendLine($"{count} {crashedDrivers[i].Item1} {crashedDrivers[i].Item2}");
            count++;
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public string PrintWinner()
    {
        var first = this.drivers.Values.OrderBy(x => x.TotalTime).FirstOrDefault();
        return $"{first.Name} wins the race for {first.TotalTime:f3} seconds.";
    }
}
