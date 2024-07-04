namespace TierneyJohn.MiChangSheng.JTools.Model.Enum.Buff;

/// <summary>Buff 移除类型枚举类</summary>
public enum RemoveTriggerType
{
    触发后移除一层 = 1,
    触发后移除所有 = 2,
    回合结束后移除一层 = 3,
    回合结束后移除所有 = 4,
    回合开始时移除一层 = 5,
    回合开始时移除所有 = 6,
    不主动移除 = 7,
    特殊移除 = 8,
    每受到一点伤害移除一层 = 9,
    使用技能时移除一层 = 10,
    每次收到一次伤害移除一层 = 11,
    回合结束后移除一半的层数 = 13,
    回合开始时移除一半的层数 = 14
}