namespace TheFifthPlayer.Core;

public enum SkillType
{
    Engage = 1,
    Disarm = 2,
    Disengage = 4,
    Damage = 8,
    Peel = 16,
    AreaDamage = 32,
    RangeDamage = 64,
    AreaDisarm = 128,
    Tank = 256,
    Mobility = 512,
    Sustain = 1024,
}