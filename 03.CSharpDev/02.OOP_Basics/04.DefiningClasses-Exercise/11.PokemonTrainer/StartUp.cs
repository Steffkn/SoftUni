using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string input = string.Empty;
        var trainers = new Dictionary<string, Trainer>();

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var trainerArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = trainerArgs[0];
            var pokemon = new Pokemon(trainerArgs[1], trainerArgs[2], int.Parse(trainerArgs[3]));
            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer(trainerName));
            }

            trainers[trainerName].AddPokemon(pokemon);
        }


        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Value.HasPokemonOfType(input) &&
                    trainer.Value.Pokemons[input].Any(x => x.Health > 0))
                {
                    trainer.Value.NumberOfBadges++;
                }
                else
                {
                    foreach (var elementPokemons in trainer.Value.Pokemons)
                    {
                        for (int i = 0; i < elementPokemons.Value.Count; i++)
                        {
                            elementPokemons.Value[i].Health -= 10;
                            if (elementPokemons.Value[i].Health <= 0)
                            {
                                elementPokemons.Value.RemoveAt(i);
                                trainer.Value.NumberOfPokemon--;
                            }
                        }
                    }
                }
            }
        }

        foreach (var trainerKvPair in trainers.OrderByDescending(t => t.Value.NumberOfBadges))
        {
            var trainer = trainerKvPair.Value;
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.NumberOfPokemon}");
        }
    }
}
