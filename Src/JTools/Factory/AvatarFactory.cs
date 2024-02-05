using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 角色数据工厂类
    /// </summary>
    public class AvatarFactory
    {
        /// <summary>
        /// 获取指定参数的 Avatar 实例方法
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="title">角色称号</param>
        /// <param name="lastName">姓</param>
        /// <param name="firstName">名</param>
        /// <param name="face">立绘编号</param>
        /// <param name="fightFace">战斗立绘编号</param>
        /// <param name="sex">性别 (1:男 2:女 3:不男不女)</param>
        /// <param name="type">种族 (1:人 2:妖 3:魔 4:鬼)</param>
        /// <param name="level">境界</param>
        /// <param name="hp">气血</param>
        /// <param name="dunSu">遁速</param>
        /// <param name="ziZhi">资质</param>
        /// <param name="wuXing">悟性</param>
        /// <param name="shenShi">神识</param>
        /// <param name="shaQi">煞气</param>
        /// <param name="shouYuan">寿元</param>
        /// <param name="age">出场年龄</param>
        /// <param name="menPai">门派</param>
        /// <param name="equipWeapon">武器</param>
        /// <param name="equipClothing">防具</param>
        /// <param name="equipRing">饰品</param>
        /// <param name="lingGen">灵根属性</param>
        /// <param name="skills">神通列表</param>
        /// <param name="staticSkills">功法列表</param>
        /// <param name="yuanYing">元婴特有功法</param>
        /// <param name="huaShenLingYu">化神领域</param>
        /// <param name="moneyType">富有度</param>
        /// <param name="isRefresh">死亡是否刷新</param>
        /// <param name="dropType">战场掉落方式</param>
        /// <param name="canJiaPaiMai">是否参加拍卖</param>
        /// <param name="paiMaiFenZu">拍卖分组</param>
        /// <param name="wuDaoType">悟道类型</param>
        /// <param name="xingQuType">兴趣类型</param>
        /// <param name="guDingJiaGe">是否固定价格</param>
        /// <param name="sellPercent">出售物品固定系数</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int id,
            string title,
            string lastName,
            string firstName,
            int face,
            int fightFace,
            int sex,
            int type,
            int level,
            int hp,
            int dunSu,
            int ziZhi,
            int wuXing,
            int shenShi,
            int shaQi,
            int shouYuan,
            int age,
            string menPai,
            int equipWeapon,
            int equipClothing,
            int equipRing,
            List<int> lingGen,
            List<int> skills,
            List<int> staticSkills,
            int yuanYing,
            int huaShenLingYu,
            int moneyType,
            int isRefresh,
            int dropType,
            int canJiaPaiMai,
            List<int> paiMaiFenZu,
            int wuDaoType,
            int xingQuType,
            int guDingJiaGe,
            int sellPercent
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("Title", title);
            data.AddField("FirstName", lastName);
            data.AddField("Name", firstName);
            data.AddField("face", face);
            data.AddField("fightFace", fightFace);
            data.AddField("SexType", sex);
            data.AddField("AvatarType", type);
            data.AddField("Level", level);
            data.AddField("HP", hp);
            data.AddField("dunSu", dunSu);
            data.AddField("ziZhi", ziZhi);
            data.AddField("wuXin", wuXing);
            data.AddField("shengShi", shenShi);
            data.AddField("shaQi", shaQi);
            data.AddField("shouYuan", shouYuan);
            data.AddField("age", age);
            data.AddField("menPai", menPai);
            data.AddField("equipWeapon", equipWeapon);
            data.AddField("equipClothing", equipClothing);
            data.AddField("equipRing", equipRing);
            data.AddField("LingGen", lingGen.ToJsonObject());
            data.AddField("skills", skills.ToJsonObject());
            data.AddField("staticSkills", staticSkills.ToJsonObject());
            data.AddField("yuanying", yuanYing);
            data.AddField("HuaShenLingYu", huaShenLingYu);
            data.AddField("MoneyType", moneyType);
            data.AddField("IsRefresh", isRefresh);
            data.AddField("dropType", dropType);
            data.AddField("canjiaPaiMai", canJiaPaiMai);
            data.AddField("paimaifenzu", paiMaiFenZu.ToJsonObject());
            data.AddField("wudaoType", wuDaoType);
            data.AddField("XinQuType", xingQuType);
            data.AddField("gudingjiage", guDingJiaGe);
            data.AddField("sellPercent", sellPercent);
            return data;
        }

        /// <summary>
        /// 获取指定参数的简易 Avatar 实例方法
        /// </summary>
        /// <param name="id">NPC 编号</param>
        /// <param name="title">角色称号</param>
        /// <param name="firstName">名</param>
        /// <param name="face">立绘编号</param>
        /// <param name="sex">性别 (1:男 2:女 3:不男不女)</param>
        /// <param name="level">境界</param>
        /// <param name="moneyType">富有度</param>
        /// <param name="lastName">姓</param>
        /// <param name="type">种族 (1:人 2:妖 3:魔 4:鬼)</param>
        /// <param name="isRefresh">死亡是否刷新</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleInstance(int id, string title, string firstName, int face, int sex,
            int level = 1, int moneyType = 5, string lastName = "", int type = 1, int isRefresh = 1)
        {
            // 简单 NPC 无需战斗立绘
            const int fightFace = 0;
            // 简易 NPC 属性模板
            const int hp = 999999;
            const int dunSu = 100;
            const int ziZhi = 100;
            const int wuXing = 100;
            const int shenShi = 100;
            const int shaQi = 0;
            const int shouYuan = 5000;
            const int age = 16;
            const string menPai = "";
            const int equipWeapon = 0;
            const int equipClothing = 0;
            const int equipRing = 0;
            var lingGen = new List<int>
            {
                20,
                20,
                20,
                20,
                20
            };
            var skills = new List<int>
            {
                1,
                201,
                101,
                301,
                401,
                501
            };
            var staticSkills = new List<int>
            {
                1
            };
            const int yuanYing = 0;
            const int huaShenLingYu = 0;
            const int dropType = 0;
            // 简易 NPC 默认不参加拍卖
            const int canJiaPaiMai = 0;
            var paiMaiFenZu = new List<int>();
            // 简易 NPC 默认不提供悟道
            const int wuDaoType = 1;
            // 简易 NPC 默认兴趣类型 1
            const int xingQuType = 1;
            // 简易 NPC 默认固定价格为 0
            const int guDingJiaGe = 0;
            // 简易 NPC 默认物品固定系数为 0
            const int sellPercent = 0;

            return GetInstance(id, title, lastName, firstName, face, fightFace, sex, type, level, hp, dunSu, ziZhi,
                wuXing, shenShi, shaQi, shouYuan, age, menPai, equipWeapon, equipClothing, equipRing, lingGen, skills,
                staticSkills, yuanYing, huaShenLingYu, moneyType, isRefresh, dropType, canJiaPaiMai, paiMaiFenZu,
                wuDaoType, xingQuType, guDingJiaGe, sellPercent);
        }
    }
}