using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }

    public int NumberOfBadges { get; set; }

    public int NumberOfPokemon { get; set; }

    public Dictionary<string, List<Pokemon>> Pokemons { get; set; }

    public Trainer(string name)
    {
        this.Name = name;
        this.NumberOfBadges = 0;
        this.NumberOfPokemon = 0;
        this.Pokemons = new Dictionary<string, List<Pokemon>>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        if (!this.Pokemons.ContainsKey(pokemon.Element))
        {
            this.Pokemons.Add(pokemon.Element, new List<Pokemon>());
        }

        this.NumberOfPokemon++;
        this.Pokemons[pokemon.Element].Add(pokemon);
    }

    public bool HasPokemonOfType(string element)
    {
        return this.Pokemons.ContainsKey(element);
    }
}
