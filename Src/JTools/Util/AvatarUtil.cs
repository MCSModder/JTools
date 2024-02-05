using KBEngine;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// Avatar 角色增强工具类
    /// </summary>
    public static class AvatarUtil
    {
        private static Avatar Player => PlayerEx.Player;

        /// <summary>
        /// 安全设置 Avatar 对象血量 (不会超出血量上限，也不会低于1)
        /// </summary>
        /// <param name="avatar">角色对象</param>
        /// <param name="hp">血量</param>
        public static void SafeSetHp(this Avatar avatar, int hp)
        {
            if (hp > avatar.HP_Max)
            {
                avatar.HP = avatar.HP_Max;
                return;
            }

            if (hp < 1)
            {
                avatar.HP = 1;
                return;
            }

            avatar.HP = hp;
        }

        /// <summary>
        /// 安全修改 Avatar 对象血量上限 (不会低于1)
        /// </summary>
        /// <param name="avatar">角色对象</param>
        /// <param name="hpMax">血量上限变化量 (正负均可)</param>
        public static void SafeChangeHpMax(this Avatar avatar, int hpMax)
        {
            if (avatar.HP_Max + hpMax < 1)
            {
                avatar.HP_Max = 1;
            }
            else
            {
                avatar.HP_Max += hpMax;
            }
        }

        /// <summary>
        /// 安全修改 Avatar 对象神识 (不会低于1)
        /// </summary>
        /// <param name="avatar">角色对象</param>
        /// <param name="shenShi">神识变化量 (正负均可)</param>
        public static void SafeChangeShenShi(this Avatar avatar, int shenShi)
        {
            if (avatar.shengShi + shenShi < 1)
            {
                avatar.shengShi = 1;
            }
            else
            {
                avatar.shengShi += shenShi;
            }
        }

        /// <summary>
        /// 给主角添加天赋 Buff
        /// </summary>
        /// <param name="buffId">Buff 编号</param>
        public static void AddTianFuBuff(this int buffId)
        {
            if (!Player.TianFuID.HasField("16"))
            {
                Player.TianFuID.AddField("16", JSONObject.arr);
            }

            Player.TianFuID["16"].Add(buffId);
        }

        /// <summary>
        /// 给主角添加指定类型悟道经验值
        /// </summary>
        /// <param name="wuDaoEx">(悟道类型，经验值)</param>
        public static void AddWuDaoEx(this (int, int) wuDaoEx)
        {
            Player.wuDaoMag.addWuDaoEx(wuDaoEx.Item1, wuDaoEx.Item2);
        }

        /// <summary>
        /// 给主角添加指定数量悟道点
        /// </summary>
        /// <param name="wuDaoDian">悟道点 (正负均可)</param>
        public static void AddWuDaoDian(this int wuDaoDian)
        {
            Player.WuDaoDian += wuDaoDian;
        }

        /// <summary>
        /// 解锁主角指定悟道技能 (会自动消耗对应的悟道点，可以配合悟道点添加方法使用)
        /// </summary>
        /// <param name="wuDaoSkill">(悟道类型，技能编号)</param>
        public static void AddWuDaoSkill(this (int, int) wuDaoSkill)
        {
            Player.wuDaoMag.addWuDaoSkill(wuDaoSkill.Item1, wuDaoSkill.Item2);
        }
    }
}