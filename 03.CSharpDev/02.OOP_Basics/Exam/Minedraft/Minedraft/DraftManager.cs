using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        harvesterFactory = new HarvesterFactory();
        providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(harvesterFactory.GetHarvester(arguments));
        }
        catch (ArgumentException e)
        {
            return $"Harvester is not registered, because of it's {e.ParamName}";
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(providerFactory.GetProvider(arguments));
        }
        catch (ArgumentException e)
        {
            return $"Provider is not registered, because of it's {e.ParamName}";
        }

        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        var eneryForTheDay = 0.0;
        var oreForTheDay = 0.0;

        foreach (var provider in providers)
        {
            eneryForTheDay += provider.EnergyOutput;
        }

        this.totalEnergyStored += eneryForTheDay;

        var eneryConsumptionModifier = 1.0;
        var harvesterProductionModifier = 1.0;

        if (this.mode.Equals("Half"))
        {
            eneryConsumptionModifier = 0.6;
            harvesterProductionModifier = 0.5;
        }

        if (!this.mode.Equals("Energy"))
        {
            var eneryRequirement = 0.0;

            foreach (var harvester in harvesters)
            {
                eneryRequirement += harvester.EnergyRequirement;
            }

            eneryRequirement *= eneryConsumptionModifier;

            if (eneryRequirement <= this.totalEnergyStored)
            {
                foreach (var harvester in harvesters)
                {
                    oreForTheDay += harvester.OreOutput;
                }

                oreForTheDay *= harvesterProductionModifier;

                this.totalEnergyStored -= eneryRequirement;
                this.totalMinedOre += oreForTheDay;
            }
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {eneryForTheDay}");
        sb.AppendLine($"Plumbus Ore Mined: {oreForTheDay}");
        return sb.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Machine machine = this.harvesters.FirstOrDefault(x => x.Id == id);

        if (machine == null)
        {
            machine = this.providers.FirstOrDefault(x => x.Id == id);
        }

        return machine?.ToString() ?? $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
        return sb.ToString().TrimEnd();
    }
}
