using System;
using System.Collections.Generic;

namespace TheFifthPlayer.Core;

public class Player
{
    readonly Dictionary<Character, float> ability = [];

    public required string Nick { get; set; }
    public required Position Position { get; set; }

    public required float Mechanics { get; set; }
    public required float CoolHead { get; set; }
    public required float Discipline { get; set; }
    
    public float GetAbility(Character character)
    {
        if (ability.TryGetValue(character, out var value))
            return value;
        
        var initialValue = character.Complexity switch
        {
            Complexity.Easy => 0.5f,
            Complexity.Medium => 0.4f,
            _ => 0.3f
        };

        ability[character] = initialValue;
        return initialValue;
    }

    public float Train(Character character)
    {
        var effect = Random.Shared.NextSingle();
        var gain = character.Complexity switch
        {
            Complexity.Easy   => 0.05f * effect,
            Complexity.Medium => 0.035f * effect,
            _                 => 0.02f * effect,
        };

        ability[character] = float.Clamp(GetAbility(character) + gain, 0f, 1f);
        return effect;
    }
}