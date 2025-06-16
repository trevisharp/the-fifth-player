using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheFifthPlayer.Core;

public class Generator(int seed)
{
    readonly Random random = new(seed);
    readonly string[] mainLetters = [ 
        "b", "c", "d", "f", "g", "h",
        "j", "k", "l", "m", "n", "p",
        "r", "s", "t", "v", "x", "z",
        "cl", "lh", "cr", "gr", "gl",
        "tr", "fr", "fl", "pr", "pl"
    ];
    readonly string[] secondLetters = [
        "a", "e", "i", "o", "u"
    ];
    readonly string[] complementLetters = [
        "n", "m", "s", "r", "h"
    ];

    string GetRandomName()
    {
        int syllables = random.Next(2, 6);
        var sb = new StringBuilder();
        var main = random.GetItems(mainLetters, syllables);
        var secc = random.GetItems(secondLetters, syllables);
        foreach (var (a, b) in main.Zip(secc))
        {
            sb.Append(a);
            sb.Append(b);
            if (random.NextSingle() < 0.3)
                sb.Append(random.GetItems(complementLetters, 1).First());
        }
        return sb.ToString();
    }

    Character GetRandomCharacter(
        Position position, Complexity complexity, 
        Style laneStyle, SkillType[] skills
    )
    {
        return new Character {
            Name = GetRandomName(),
            Complexity = complexity,
            Main = position,
            Style = laneStyle,
            Skill1 = skills[0],
            Skill2 = skills[1],
            Ultimate = skills[2]
        };
    }

    public IEnumerable<Character> GenerateCaracters()
    {
        #region TOP Characters

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Easy, Style.Balanced,
            [ SkillType.Damage, SkillType.Tank, SkillType.Damage ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Easy, Style.Balanced,
            [ SkillType.Tank, SkillType.Sustain, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Hard, Style.Balanced,
            [ SkillType.Mobility, SkillType.Damage, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Medium, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Mobility, SkillType.Sustain ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Hard, Style.EarlyGame,
            [ SkillType.Sustain, SkillType.Engage, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Complexity.Easy, Style.LateGame,
            [ SkillType.Mobility, SkillType.Damage, SkillType.AreaDamage ]
        );

        #endregion
        
        #region JGL Characters

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Easy, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Engage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Medium, Style.EarlyGame,
            [ SkillType.Mobility, SkillType.Engage, SkillType.AreaDisarm ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Hard, Style.EarlyGame,
            [ SkillType.AreaDamage, SkillType.Engage, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Easy, Style.Balanced,
            [ SkillType.Sustain, SkillType.Engage, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Medium, Style.Balanced,
            [ SkillType.Tank, SkillType.Engage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Complexity.Hard, Style.Balanced,
            [ SkillType.Peel, SkillType.Engage, SkillType.AreaDisarm ]
        );

        #endregion

        #region MID Characters

        yield return GetRandomCharacter(
            Position.MID, Complexity.Easy, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Mobility, SkillType.AreaDisarm ]
        );

        yield return GetRandomCharacter(
            Position.MID, Complexity.Easy, Style.Balanced,
            [ SkillType.Mobility, SkillType.Disengage, SkillType.Damage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Complexity.Medium, Style.Balanced,
            [ SkillType.AreaDamage, SkillType.AreaDamage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Complexity.Hard, Style.Balanced,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.Disengage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Complexity.Medium, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Complexity.Hard, Style.LateGame,
            [ SkillType.Damage, SkillType.Damage, SkillType.Damage ]
        );

        #endregion

        #region ADC Characters
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Hard, Style.EarlyGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Easy, Style.Balanced,
            [ SkillType.RangeDamage, SkillType.Mobility, SkillType.AreaDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Easy, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Medium, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Mobility, SkillType.AreaDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Medium, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Disengage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Complexity.Hard, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Disarm, SkillType.AreaDamage ]
        );

        #endregion
    
        #region SUP Characters

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Easy, Style.EarlyGame,
            [ SkillType.Peel, SkillType.Disarm, SkillType.Disengage ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Medium, Style.EarlyGame,
            [ SkillType.Peel, SkillType.Mobility, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Hard, Style.EarlyGame,
            [ SkillType.RangeDamage, SkillType.Disarm, SkillType.RangeDamage ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Easy, Style.Balanced,
            [ SkillType.Engage, SkillType.Disarm, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Medium, Style.Balanced,
            [ SkillType.Engage, SkillType.Disarm, SkillType.Tank ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Complexity.Hard, Style.Balanced,
            [ SkillType.Peel, SkillType.Disengage, SkillType.Mobility ]
        );
        
        #endregion
    }
}