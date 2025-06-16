using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheFifthPlayer.Core;

public class Generator(int? seed = null)
{
    readonly Random random = new(seed ?? Random.Shared.Next());
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
    readonly string[] nicks = [
        "FadeFlash", "BronzeLord", "GapNaCall", "AutoChad", "SmitePraQue", "FlashPraBase", "RunadoTop", "WardsOnPoint",
        "CritNoAronguejo", "MuteAllDay", "NoPingNoWin", "MidSemRoaming", "BackdoorKing", "ADCdeZAP", "1v9Hope", "FarmPerdido",
        "TiltadoComEstilo", "RoamingNaVida", "ClutchDasCall", "NexusOuNada", "MainTab", "UltDeFlash", "MordeReporta", "XPDoSuporte",
        "FreezeMan", "ObjetivoÉKill", "LateGameCarry", "Baitador", "DropaMeuLP", "ChoraNoDraft", "CoachDeSoloQ", "MuteiGeral",
        "SplitNaAlma", "CaiuMasCarreguei", "CallErrada", "TropaDoElo", "BRTTavaCerto", "Fakou", "JukesDoPrata", "QuaseChallenger",
        "SemMuteSemPaz", "KillNaVoz", "SoloqAnalyst", "PinkNoDragon", "LateÉMeta", "FullClearEnjoyer", "SuporteAlpha", "ReportMidAfk",
        "DragãoSemSmite", "PerdiProBarão", "JungleNoTopo", "MuteMidFirst", "FingeQueVenceu", "TrocaDeLane", "PingSemVisão", "CallDeBronze",
        "SplitEmARAM", "VontadeDeGanhar", "ChoraProCoach", "EloDeCristal", "ArdilosoDoMeta", "BateuNoTeclado", "CansadoDoMeta", "ZedFake",
        "MacroZero", "HardGapBot", "JungleSagrado", "InstalockGG", "DesviaDoGank", "FarmAFK", "SemMapaMesmo", "FlashNoMinion",
        "VoltaPraBase", "KillÉObjetivo", "Farm4Win", "SoloDuoFlex", "PingDoSuporte", "GhostNoBarão", "HardEngage", "BarãoSemTime",
        "MaisUmReset", "SmiteNaCatapulta", "PermaPushTop", "BuildErrada", "VontadeDeSplitar", "SextouNaBase", "PingInfinito", "FullMuteMode"
    ];

    string GetRandomName()
    {
        int syllables =
            random.NextSingle() < 0.2f ? 
            4 : random.Next(2, 4);
        var main = random.GetItems(mainLetters, syllables);
        var secc = random.GetItems(secondLetters, syllables);

        var sb = new StringBuilder();
        foreach (var (a, b) in main.Zip(secc))
        {
            sb.Append(a);
            sb.Append(b);
            if (random.NextSingle() < 0.15)
                sb.Append(random.GetItems(complementLetters, 1).First());
        }
        return sb.ToString();
    }

    Character GetRandomCharacter(
        Position position, Style laneStyle, SkillType[] skills
    )
    {
        var complexity = random.GetItems([
            Complexity.Easy, Complexity.Medium, Complexity.Hard 
            ], 1)[0];
        return new Character {
            Name = GetRandomName(),
            Complexity = complexity,
            Position = position,
            Style = laneStyle,
            Skill1 = skills[0],
            Skill2 = skills[1],
            Ultimate = skills[2]
        };
    }

    Player GetRandomPlayer(
        Position position, float experience, float ability, string nick
    )
    {
        return new Player {
            Position = position,
            CoolHead = experience,
            Discipline = experience,
            Mechanics = ability,
            Nick = nick
        };
    }

    public IEnumerable<Character> GenerateCaracters()
    {
        #region TOP Characters

        yield return GetRandomCharacter(
            Position.TOP, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Mobility, SkillType.Sustain ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Style.EarlyGame,
            [ SkillType.Sustain, SkillType.Engage, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Style.Balanced,
            [ SkillType.Damage, SkillType.Tank, SkillType.Damage ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Style.Balanced,
            [ SkillType.Tank, SkillType.Sustain, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Style.Balanced,
            [ SkillType.Mobility, SkillType.Damage, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.TOP, Style.LateGame,
            [ SkillType.Mobility, SkillType.Damage, SkillType.AreaDamage ]
        );

        #endregion
        
        #region JGL Characters

        yield return GetRandomCharacter(
            Position.JGL, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Engage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Style.EarlyGame,
            [ SkillType.Mobility, SkillType.Engage, SkillType.AreaDisarm ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Style.EarlyGame,
            [ SkillType.AreaDamage, SkillType.Engage, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Style.Balanced,
            [ SkillType.Sustain, SkillType.Engage, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Style.Balanced,
            [ SkillType.Tank, SkillType.Engage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.JGL, Style.Balanced,
            [ SkillType.Peel, SkillType.Engage, SkillType.AreaDisarm ]
        );

        #endregion

        #region MID Characters

        yield return GetRandomCharacter(
            Position.MID, Style.EarlyGame,
            [ SkillType.Damage, SkillType.Mobility, SkillType.AreaDisarm ]
        );

        yield return GetRandomCharacter(
            Position.MID, Style.Balanced,
            [ SkillType.Mobility, SkillType.Disengage, SkillType.Damage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Style.Balanced,
            [ SkillType.AreaDamage, SkillType.AreaDamage, SkillType.Engage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Style.Balanced,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.Disengage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );

        yield return GetRandomCharacter(
            Position.MID, Style.LateGame,
            [ SkillType.Damage, SkillType.Damage, SkillType.Damage ]
        );

        #endregion

        #region ADC Characters
        
        yield return GetRandomCharacter(
            Position.ADC, Style.EarlyGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Style.Balanced,
            [ SkillType.RangeDamage, SkillType.Mobility, SkillType.AreaDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.RangeDamage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Mobility, SkillType.AreaDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Disengage, SkillType.RangeDamage ]
        );
        
        yield return GetRandomCharacter(
            Position.ADC, Style.LateGame,
            [ SkillType.RangeDamage, SkillType.Disarm, SkillType.AreaDamage ]
        );

        #endregion
    
        #region SUP Characters

        yield return GetRandomCharacter(
            Position.SUP, Style.EarlyGame,
            [ SkillType.Peel, SkillType.Disarm, SkillType.Disengage ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Style.EarlyGame,
            [ SkillType.Peel, SkillType.Mobility, SkillType.Peel ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Style.EarlyGame,
            [ SkillType.RangeDamage, SkillType.Disarm, SkillType.RangeDamage ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Style.Balanced,
            [ SkillType.Engage, SkillType.Disarm, SkillType.Disarm ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Style.Balanced,
            [ SkillType.Engage, SkillType.Disarm, SkillType.Tank ]
        );

        yield return GetRandomCharacter(
            Position.SUP, Style.Balanced,
            [ SkillType.Peel, SkillType.Disengage, SkillType.Mobility ]
        );
        
        #endregion
    }

    public IEnumerable<Player> GeneratePlayers(Player mainPlayer)
    {
        random.Shuffle(nicks);
        string[] pickedNicks = [ ..nicks.Take(39) ];
        List<Position> positions = [ 
            ..Enumerable.Repeat(Position.TOP, 8),
            ..Enumerable.Repeat(Position.JGL, 8),
            ..Enumerable.Repeat(Position.MID, 8),
            ..Enumerable.Repeat(Position.ADC, 8),
            ..Enumerable.Repeat(Position.SUP, 8)
        ];
        positions.Remove(mainPlayer.Position);
        for (int i = 0; i < 39; i++)
        {
            yield return GetRandomPlayer(
                positions[i], 
                0.6f * random.NextSingle() + 0.2f,
                0.6f * random.NextSingle() + 0.2f,
                pickedNicks[i]
            );
        }
    }
}