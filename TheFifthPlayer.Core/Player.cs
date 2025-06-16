using System.Collections.Generic;

namespace TheFifthPlayer.Core;

public class Player
{
    readonly Dictionary<Character, float> ability = [];

    public required string Name { get; set; }
    public required string Nick { get; set; }
    public required Position Position { get; set; }

    public required float CoolHead { get; set; }
    public required float Discipline { get; set; }
    
    public float GetAbility(Character character)
    {
        if (ability.TryGetValue(character, out var value))
            return value;
        
        ability[character] = 0.5f;
        return 0.5f;
    }
}