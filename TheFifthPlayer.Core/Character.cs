namespace TheFifthPlayer.Core;

public class Character
{
    public required string Name { get; set; }
    public required Position Position { get; set; }
    public required Complexity Complexity { get; set; }
    public required Style Style { get; set; }
    public required SkillType Skill1 { get; set; }
    public required SkillType Skill2 { get; set; }
    public required SkillType Ultimate { get; set; }
}