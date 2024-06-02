using System;
using System.Collections.Generic;

// Інтерфейс Builder
public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBodyType(string bodyType);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder SetInventory(List<string> inventory);
    Character Build();
}

// Клас Character
public class Character
{
    public int Height { get; set; }
    public string BodyType { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; }
    public List<string> Deeds { get; set; }
    public string Alignment { get; set; }

    public override string ToString()
    {
        return $"Height: {Height}\n" +
               $"BodyType: {BodyType}\n" +
               $"HairColor: {HairColor}\n" +
               $"EyeColor: {EyeColor}\n" +
               $"Clothing: {Clothing}\n" +
               $"Inventory: {string.Join(", ", Inventory)}\n" +
               $"Alignment: {Alignment}\n" +
               $"Deeds: {string.Join(", ", Deeds)}\n";
    }
}

// Клас HeroBuilder
public class HeroBuilder : ICharacterBuilder
{
    private Character _character;

    public HeroBuilder()
    {
        _character = new Character { Deeds = new List<string>(), Alignment = "Good" };
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBodyType(string bodyType)
    {
        _character.BodyType = bodyType;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder SetInventory(List<string> inventory)
    {
        _character.Inventory = inventory;
        return this;
    }

    public HeroBuilder AddGoodDeed(string deed)
    {
        _character.Deeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}

// Клас EnemyBuilder
public class EnemyBuilder : ICharacterBuilder
{
    private Character _character;

    public EnemyBuilder()
    {
        _character = new Character { Deeds = new List<string>(), Alignment = "Evil" };
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBodyType(string bodyType)
    {
        _character.BodyType = bodyType;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder SetInventory(List<string> inventory)
    {
        _character.Inventory = inventory;
        return this;
    }

    public EnemyBuilder AddEvilDeed(string deed)
    {
        _character.Deeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}

// Клас Director
public class CharacterDirector
{
    public Character ConstructHero(ICharacterBuilder builder)
    {
        return builder
            .SetHeight(180)
            .SetBodyType("Muscular")
            .SetHairColor("Blonde")
            .SetEyeColor("Blue")
            .SetClothing("Armor")
            .SetInventory(new List<string> { "Sword", "Shield" })
            .Build();
    }

    public Character ConstructEnemy(ICharacterBuilder builder)
    {
        return builder
            .SetHeight(175)
            .SetBodyType("Lean")
            .SetHairColor("Black")
            .SetEyeColor("Red")
            .SetClothing("Dark Robes")
            .SetInventory(new List<string> { "Dagger", "Potion" })
            .Build();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var heroBuilder = new HeroBuilder();
        var enemyBuilder = new EnemyBuilder();
        var director = new CharacterDirector();

        var hero = director.ConstructHero(heroBuilder);
        heroBuilder.AddGoodDeed("Saved a village").AddGoodDeed("Defeated a dragon");

        var enemy = director.ConstructEnemy(enemyBuilder);
        enemyBuilder.AddEvilDeed("Destroyed a town").AddEvilDeed("Stole a treasure");

        Console.WriteLine("Hero:");
        Console.WriteLine(hero);

        Console.WriteLine("Enemy:");
        Console.WriteLine(enemy);
    }
}
