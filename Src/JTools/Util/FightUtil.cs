using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using KBEngine;
using YSGame;
using YSGame.Fight;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// 战斗相关工具类
    /// </summary>
    public static class FightUtil
    {
        /// <summary>
        /// 主角移除指定编号的 神通技能
        /// </summary>
        /// <param name="player">Avatar 对象</param>
        /// <param name="skillId">技能编号</param>
        public static void FightClearSkill(this Avatar player, int skillId)
        {
            if (!player.isPlayer())
            {
                return;
            }

            foreach (var fightSkill in from fightSkill in UIFightPanel.Inst.FightSkills
                     where fightSkill.HasSkill
                     let skill = Traverse.Create(fightSkill).Field("nowSkill").GetValue<GUIPackage.Skill>()
                     where skill.SkillID == skillId
                     select fightSkill)
            {
                fightSkill.Clear();
                $"已移除指定技能 Skill_ID： {skillId}".Log();
            }
        }

        /// <summary>
        /// 主角添加指定编号的 神通技能
        /// </summary>
        /// <param name="player">Avatar 对象</param>
        /// <param name="skillId">技能编号</param>
        public static void FightAddSkill(this Avatar player, int skillId)
        {
            if (!player.isPlayer())
            {
                return;
            }

            skillId = Tools.instance.getSkillKeyByID(skillId, player);

            if (skillId == -1)
            {
                $"执行自定义 Seid318 失败, SkillId 不存在: {skillId}".Error();
                return;
            }

            var gSkill = new GUIPackage.Skill(skillId, 0, 10);

            foreach (var fightSkill in UIFightPanel.Inst.FightSkills.Where(fightSkill => !fightSkill.HasSkill))
            {
                player.skill.Add(gSkill);
                fightSkill.SetSkill(gSkill);
                $"已添加指定技能 Skill_ID： {skillId}".Log();
                break;
            }
        }

        /// <summary>
        /// 主角添加指定编号的 神通技能
        /// </summary>
        /// <param name="player">Avatar 对象</param>
        /// <param name="skillId">技能编号</param>
        /// <param name="toSkillId">技能编号</param>
        public static void FightChangeSkill(this Avatar player, int skillId, int toSkillId)
        {
            if (!player.isPlayer())
            {
                return;
            }

            foreach (var fightSkill in from fightSkill in UIFightPanel.Inst.FightSkills
                     where fightSkill.HasSkill
                     let skill = Traverse.Create(fightSkill).Field("nowSkill").GetValue<GUIPackage.Skill>()
                     where skill.SkillID == skillId
                     select fightSkill)
            {
                toSkillId = Tools.instance.getSkillKeyByID(toSkillId, player);

                if (toSkillId == -1)
                {
                    $"执行自定义 Seid319 失败, SkillId 不存在: {toSkillId}".Error();
                    return;
                }

                var gSkill = new GUIPackage.Skill(toSkillId, 0, 10);

                fightSkill.Clear();
                player.skill.Add(gSkill);
                fightSkill.SetSkill(gSkill);
                $"已替换指定技能 Skill_ID： {skillId} -> {toSkillId}".Log();
            }
        }

        public static void FightUseSkill(int skillId)
        {
            var avatar = PlayerEx.Player;
            skillId = Tools.instance.getSkillKeyByID(skillId, avatar);

            Tools.AddQueue(() =>
            {
                RoundManager.instance.NowUseLingQiType = UseLingQiType.释放技能后消耗;

                avatar.UsedSkills?.Add(skillId);

                RoundManager.instance.NowUseLingQiType = UseLingQiType.None;
                YSFuncList.Ints.Continue();
            });
        }

        public static void FightUseSkill(this Avatar avatar, int skillId)
        {
            skillId = Tools.instance.getSkillKeyByID(skillId, avatar);

            Tools.AddQueue(() =>
            {
                RoundManager.instance.NowUseLingQiType = UseLingQiType.释放技能后消耗;

                avatar.UsedSkills?.Add(skillId);

                RoundManager.instance.NowUseLingQiType = UseLingQiType.None;
                YSFuncList.Ints.Continue();
            });
        }

        public static void FightUseSkill(this Avatar avatar, int skillId, Buff instance)
        {
            skillId = Tools.instance.getSkillKeyByID(skillId, avatar);
            var skill = new GUIPackage.Skill(skillId, 0, 10);

            Tools.AddQueue(() =>
            {
                RoundManager.instance.NowUseLingQiType = UseLingQiType.释放技能后消耗;

                var damage = new List<int>();

                switch (jsonData.instance.skillJsonData[skillId.ToString()].GetFieldStr("script"))
                {
                    case "SkillAttack":
                        damage = skill.PutingSkill(avatar, avatar.OtherAvatar);
                        break;
                    case "SkillSelf":
                        damage = skill.PutingSkill(avatar, avatar);
                        break;
                }

                avatar.UsedSkills?.Add(skillId);

                if (!instance.seid.Contains(129))
                {
                    avatar.spell.onBuffTickByType(8, damage);
                }

                RoundManager.instance.NowUseLingQiType = UseLingQiType.None;
                YSFuncList.Ints.Continue();
            });
        }
    }
}