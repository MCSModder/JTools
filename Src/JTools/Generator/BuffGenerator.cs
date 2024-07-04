using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Buff;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>Buff 数据生成器</summary>
public static class BuffGenerator
{
    public static BuffEntity Generator(
        int buffId,
        int buffIconId,
        string name,
        List<int> seid,
        BuffType buffType,
        StartTriggerType startTrigger,
        RemoveTriggerType removeTrigger,
        OverlayType overlayType,
        string desc,
        List<int> affix = null,
        bool isHide = false,
        bool showOnlyOne = false
    )
    {
        return new BuffEntity
        {
            Id = buffId,
            Name = name,
            BuffIconId = buffIconId,
            Affix = affix,
            Seid = seid,
            BuffType = buffType,
            StartTrigger = startTrigger,
            RemoveTrigger = removeTrigger,
            OverlayType = overlayType,
            Desc = desc,
            IsHide = isHide,
            ShowOnlyOne = showOnlyOne
        };
    }

    public static IEnumerable<BuffEntity> SkillGenerator(
        int buffId,
        string name,
        List<int> seid,
        BuffType buffType,
        StartTriggerType startTrigger,
        RemoveTriggerType removeTrigger,
        OverlayType overlayType,
        List<string> desc,
        List<int> affix = null,
        bool isHide = false,
        bool showOnlyOne = false
    )
    {
        return
        [
            Generator(
                buffId + 1,
                buffId,
                name,
                seid,
                buffType,
                startTrigger,
                removeTrigger,
                overlayType,
                desc[0],
                affix,
                isHide,
                showOnlyOne),
            Generator(
                buffId + 2,
                buffId,
                name,
                seid,
                buffType,
                startTrigger,
                removeTrigger,
                overlayType,
                desc[1],
                affix,
                isHide,
                showOnlyOne),
            Generator(
                buffId + 3,
                buffId,
                name,
                seid,
                buffType,
                startTrigger,
                removeTrigger,
                overlayType,
                desc[2],
                affix,
                isHide,
                showOnlyOne),
            Generator(
                buffId + 4,
                buffId,
                name,
                seid,
                buffType,
                startTrigger,
                removeTrigger,
                overlayType,
                desc[3],
                affix,
                isHide,
                showOnlyOne),
            Generator(
                buffId + 5,
                buffId,
                name,
                seid,
                buffType,
                startTrigger,
                removeTrigger,
                overlayType,
                desc[4],
                affix,
                isHide,
                showOnlyOne)
        ];
    }

    public static BuffEntity ElixirGenerator(
        int buffId,
        string name,
        List<int> seid,
        StartTriggerType startTrigger,
        string desc,
        int buffIconId = 5205,
        BuffType buffType = BuffType.丹药,
        RemoveTriggerType removeTrigger = RemoveTriggerType.不主动移除,
        OverlayType overlayType = OverlayType.叠加
    )
    {
        return Generator(buffId, buffIconId, name, seid, buffType, startTrigger, removeTrigger, overlayType, desc);
    }

    public static BuffEntity FireGenerator(
        int buffId,
        List<int> seid,
        StartTriggerType startTrigger,
        string name = "",
        string desc = "",
        RemoveTriggerType removeTrigger = RemoveTriggerType.不主动移除,
        OverlayType overlayType = OverlayType.叠加,
        BuffType buffType = BuffType.功法被动
    )
    {
        return Generator(
            buffId,
            buffId,
            name,
            seid,
            buffType,
            startTrigger,
            removeTrigger,
            overlayType,
            desc,
            [],
            true);
    }

    public static BuffEntity EquipGenerator(
        int buffId,
        string name,
        List<int> seid,
        StartTriggerType startTrigger,
        RemoveTriggerType removeTrigger,
        string desc,
        List<int> affix = null,
        BuffType buffType = BuffType.装备被动,
        OverlayType overlayType = OverlayType.增加,
        bool showOnlyOne = true
    )
    {
        return Generator(
            buffId,
            buffId,
            name,
            seid,
            buffType,
            startTrigger,
            removeTrigger,
            overlayType,
            desc,
            affix,
            false,
            showOnlyOne);
    }

    public static BuffEntity PointerGenerator(int buffId, string name, string desc, List<int> affix = null)
    {
        return Generator(
            buffId,
            buffId,
            name,
            [],
            BuffType.指示物,
            StartTriggerType.不主动触发,
            RemoveTriggerType.不主动移除,
            OverlayType.叠加,
            desc,
            affix);
    }
}