using System.Collections.Generic;
using System.Linq;
using SkySwordKill.NextModEditor.Mod;
using SkySwordKill.NextModEditor.Mod.Data;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools_Next.Data;

public class SkillSeidMetaData
{
    public static SkillSeidMetaData Inst => _inst ??= new SkillSeidMetaData();

    private static SkillSeidMetaData _inst;
    private bool _isInit;
    private readonly List<ModSeidMeta> _modSeidMetas = [];

    private SkillSeidMetaData()
    {
        SkillSeidMeta181();
        SkillSeidMeta182();
        SkillSeidMeta183();
        SkillSeidMeta184();
        SkillSeidMeta185();
        SkillSeidMeta186();
        SkillSeidMeta187();
        SkillSeidMeta188();
        SkillSeidMeta189();
        SkillSeidMeta190();
        SkillSeidMeta191();
        SkillSeidMeta192();
        SkillSeidMeta193();
        SkillSeidMeta194();
        SkillSeidMeta195();
        SkillSeidMeta196();
        SkillSeidMeta197();
        SkillSeidMeta198();
        SkillSeidMeta199();
        SkillSeidMeta200();
        SkillSeidMeta201();
        SkillSeidMeta202();
        SkillSeidMeta203();
        SkillSeidMeta204();
        SkillSeidMeta205();
        SkillSeidMeta206();
        SkillSeidMeta207();
        SkillSeidMeta208();
    }

    public void Load()
    {
        if (_isInit) return;

        foreach (var meta in _modSeidMetas.Where(meta => !ModEditorManager.I.SkillSeidMetas.TryAdd(meta.Id, meta)))
        {
            $"SkillSeid [{meta.Id}] 发生冲突，请检查 Mod 列表".Warn();
        }

        _isInit = true;
    }

    #region Meta 数据

    /// <summary>
    /// 将自身的所有 X 系灵气转化为 Y 系灵气
    /// </summary>
    private void SkillSeidMeta181()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 181,
                IDName = "skillid",
                Name = "将自身的所有 X 系灵气转化为 Y 系灵气",
                Desc = "将自身的所有 X 系灵气转化为 Y 系灵气",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.IntArray, Desc = "X: 待转化灵气"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "Y: 转化后灵气"
                    }
                ]
            });
    }

    /// <summary>
    /// 将自身的所有 XBuff 变成 Y 倍 (整数)
    /// </summary>
    private void SkillSeidMeta182()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 182,
                IDName = "skillid",
                Name = "将自身的所有 XBuff 变成 Y 倍 (整数)",
                Desc = "将自身的所有 XBuff 变成 Y 倍 (整数)",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.IntArray, Desc = "XBuff: 待修改Buff"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "Y: 修改倍率 (整数)"
                    }
                ]
            });
    }

    /// <summary>
    /// 获得自身 XBuff 数量的 YBuff
    /// </summary>
    private void SkillSeidMeta183()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 183,
                IDName = "skillid",
                Name = "获得自身 XBuff 数量的 YBuff",
                Desc = "获得自身 XBuff 数量的 YBuff",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff: 参考 Buff"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.Int, Desc = "YBuff: 待添加 Buff"
                    }
                ]
            });
    }

    /// <summary>
    /// 获得自身 XBuff 数量的 YBuff
    /// </summary>
    private void SkillSeidMeta184()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 184,
                IDName = "skillid",
                Name = "获得自身 XBuff 数量的 YBuff",
                Desc = "获得自身 XBuff 数量的 YBuff",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff: 参考 Buff"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.Int, Desc = "YBuff: 待添加 Buff"
                    }
                ]
            });
    }

    /// <summary>
    /// 给目标自身 XBuff 数量的 YBuff
    /// </summary>
    private void SkillSeidMeta185()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 185,
                IDName = "skillid",
                Name = "给目标自身 XBuff 数量的 YBuff",
                Desc = "给目标自身 XBuff 数量的 YBuff",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff: 自身 Buff"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.Int, Desc = "YBuff: 目标 Buff"
                    }
                ]
            });
    }

    /// <summary>
    /// 给目标自身 XBuff 数量的 YBuff
    /// </summary>
    private void SkillSeidMeta186()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 186,
                IDName = "skillid",
                Name = "给目标自身 XBuff 数量的 YBuff",
                Desc = "给目标自身 XBuff 数量的 YBuff",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff: 自身 Buff"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2", Type = ModSeidPropertyType.Int, Desc = "YBuff: 目标 Buff"
                    }
                ]
            });
    }

    /// <summary>
    /// 如果玩家装备了特定武器，则触发后续特效
    /// </summary>
    private void SkillSeidMeta187()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 187,
                IDName = "skillid",
                Name = "如果玩家装备了特定武器，则触发后续特效",
                Desc = "如果玩家装备了特定武器，则触发后续特效",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "武器编号" }]
            });
    }

    /// <summary>
    /// 双方同时获得 XBuff Y层
    /// </summary>
    private void SkillSeidMeta188()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 188,
                IDName = "skillid",
                Name = "双方同时获得 XBuff Y层",
                Desc = "双方同时获得 XBuff Y层",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.IntArray, Desc = "XBuff" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "层数 Y" }
                ]
            });
    }

    /// <summary>
    /// 触发目标 XBuff Y 次
    /// </summary>
    private void SkillSeidMeta189()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 189,
                IDName = "skillid",
                Name = "触发目标 XBuff Y 次",
                Desc = "触发目标 XBuff Y 次",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.IntArray, Desc = "XBuff" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "次数 Y" }
                ]
            });
    }

    /// <summary>
    /// 将自身所有 XBuff 转化为 YBuff
    /// </summary>
    private void SkillSeidMeta190()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 190,
                IDName = "skillid",
                Name = "将自身所有 XBuff 转化为 YBuff",
                Desc = "将自身所有 XBuff 转化为 YBuff",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.Int, Desc = "YBuff" }
                ]
            });
    }

    /// <summary>
    /// 将自身所有 XBuff 转化为 YBuff
    /// </summary>
    private void SkillSeidMeta191()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 191,
                IDName = "skillid",
                Name = "多段效果",
                Desc = "多段效果同 SkillSeid11 无特殊处理",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "额外攻击次数" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.Int, Desc = "攻击技能" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.Int, Desc = "每段伤害" }
                ]
            });
    }

    /// <summary>
    /// 将自身所有 XBuff 转化为 YBuff
    /// </summary>
    private void SkillSeidMeta192()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 192,
                IDName = "skillid",
                Name = "若上一次使用的是 X 技能，则触发后续特性",
                Desc = "若上一次使用的是 X 技能，则触发后续特性",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "技能唯一编号" }
                ]
            });
    }

    /// <summary>
    /// 遁速每比对方高 X 点,伤害增加 Y 点
    /// </summary>
    private void SkillSeidMeta193()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 193,
                IDName = "skillid",
                Name = "遁速每比对方高 X 点,伤害增加 Y 点",
                Desc = "遁速每比对方高 X 点,伤害增加 Y 点",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "遁速差值 X" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.Int, Desc = "伤害增加量 Y" }
                ]
            });
    }

    /// <summary>
    /// 遁速每比对方高 X 点,伤害提升 Y%
    /// </summary>
    private void SkillSeidMeta194()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 194,
                IDName = "skillid",
                Name = "遁速每比对方高 X 点,伤害提升 Y%",
                Desc = "遁速每比对方高 X 点,伤害提升 Y%",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "遁速差值 X" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.Int, Desc = "伤害提升量 Y%" }
                ]
            });
    }

    /// <summary>
    /// 技能可额外释放 X 次
    /// </summary>
    private void SkillSeidMeta195()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 195,
                IDName = "skillid",
                Name = "技能可额外释放 X 次",
                Desc = "技能可额外释放 X 次",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "额外释放次数" }]
            });
    }

    /// <summary>
    /// 若本回合使用过 X 技能，则触发后续特性
    /// </summary>
    private void SkillSeidMeta196()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 196,
                IDName = "skillid",
                Name = "若本回合使用过 X 技能，则触发后续特性",
                Desc = "若本回合使用过 X 技能，则触发后续特性",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "检测神通固定编号" }
                ]
            });
    }

    /// <summary>
    /// 若本局战斗使用过 X 技能，则触发后续特性
    /// </summary>
    private void SkillSeidMeta197()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 197,
                IDName = "skillid",
                Name = "若本局战斗使用过 X 技能，则触发后续特性",
                Desc = "若本局战斗使用过 X 技能，则触发后续特性",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "检测神通固定编号" }
                ]
            });
    }

    /// <summary>
    /// 获得自身 XBuff 数量的 YBuff Z倍
    /// </summary>
    private void SkillSeidMeta198()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 198,
                IDName = "skillid",
                Name = "获得自身 XBuff 数量的 YBuff Z倍",
                Desc = "获得自身 XBuff 数量的 YBuff Z倍",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "XBuff" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "YBuff" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.IntArray, Desc = "Z倍" }
                ]
            });
    }

    /// <summary>
    /// 将自身当前血量的 X% 转化为生命上限
    /// </summary>
    private void SkillSeidMeta199()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 199,
                IDName = "skillid",
                Name = "将自身当前血量的 X% 转化为生命上限",
                Desc = "将自身当前血量的 X% 转化为生命上限",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量转化百分比" }]
            });
    }

    /// <summary>
    /// 该次伤害 * X倍
    /// </summary>
    private void SkillSeidMeta200()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 200,
                IDName = "skillid",
                Name = "该次伤害 * X倍",
                Desc = "该次伤害 * X倍",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "伤害倍率" }]
            });
    }

    /// <summary>
    /// 降低目标血量上限 X 点
    /// </summary>
    private void SkillSeidMeta201()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 201,
                IDName = "skillid",
                Name = "降低目标血量上限 X 点",
                Desc = "降低目标血量上限 X 点",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量上限变化量X" }]
            });
    }

    /// <summary>
    /// 降低目标血量上限 X 点
    /// </summary>
    private void SkillSeidMeta202()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 202,
                IDName = "skillid",
                Name = "降低目标血量上限 X 点",
                Desc = "降低目标血量上限 X 点",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量上限变化量X" }]
            });
    }

    /// <summary>
    /// 消耗自身 X 点血量,获得等量的 YBuff * Z
    /// </summary>
    private void SkillSeidMeta203()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 203,
                IDName = "skillid",
                Name = "消耗自身 X 点血量,获得等量的 YBuff * Z",
                Desc = "消耗自身 X 点血量,获得等量的 YBuff * Z",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量变化量X" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "YBuff" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.IntArray, Desc = "系数 Z" }
                ]
            });
    }

    /// <summary>
    /// 消耗自身 X% 血量,获得等量的 YBuff * Z
    /// </summary>
    private void SkillSeidMeta204()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 204,
                IDName = "skillid",
                Name = "消耗自身 X% 血量,获得等量的 YBuff * Z",
                Desc = "消耗自身 X% 血量,获得等量的 YBuff * Z",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量百分比 X%" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "YBuff" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.IntArray, Desc = "系数 Z" }
                ]
            });
    }

    /// <summary>
    /// 消耗自身 X% 血量上限的血量,获得等量的 YBuff * Z
    /// </summary>
    private void SkillSeidMeta205()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 205,
                IDName = "skillid",
                Name = "消耗自身 X% 血量上限的血量,获得等量的 YBuff * Z",
                Desc = "消耗自身 X% 血量上限的血量,获得等量的 YBuff * Z",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "血量百分比 X%" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "YBuff" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.IntArray, Desc = "系数 Z" }
                ]
            });
    }

    /// <summary>
    /// 吸收灵气 X 点，若其中包含 Y 灵气 则触发 Z 特性
    /// </summary>
    private void SkillSeidMeta206()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 206,
                IDName = "skillid",
                Name = "吸收灵气 X 点，若其中包含 Y 灵气 则触发 Z 特性",
                Desc = "吸收灵气 X 点，若其中包含 Y 灵气 则触发 Z 特性",
                Properties =
                [
                    new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "吸收灵气数量" },
                    new ModSeidProperty { ID = "value2", Type = ModSeidPropertyType.IntArray, Desc = "校验灵气 Y" },
                    new ModSeidProperty { ID = "value3", Type = ModSeidPropertyType.IntArray, Desc = "特性 Z" }
                ]
            });
    }

    /// <summary>
    /// 改变目标神识 X 点
    /// </summary>
    private void SkillSeidMeta207()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 207,
                IDName = "skillid",
                Name = "改变目标神识 X 点",
                Desc = "改变目标神识 X 点",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "神识改变量" }]
            });
    }

    /// <summary>
    /// X% 的概率,触发后续特性
    /// </summary>
    private void SkillSeidMeta208()
    {
        _modSeidMetas.Add(
            new ModSeidMeta
            {
                Id = 208,
                IDName = "skillid",
                Name = "X% 的概率,触发后续特性",
                Desc = "X% 的概率,触发后续特性",
                Properties = [new ModSeidProperty { ID = "value1", Type = ModSeidPropertyType.Int, Desc = "触发概率" }]
            });
    }

    #endregion
}