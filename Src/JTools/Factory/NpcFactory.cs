using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// NPC 数据工厂类
    /// </summary>
    public class NpcFactory
    {
        /// <summary>
        /// 获取指定参数的 NpcImportant 实例方法
        /// </summary>
        /// <param name="id">NPC 编号</param>
        /// <param name="liuPai">流派</param>
        /// <param name="level">境界</param>
        /// <param name="sex">性别</param>
        /// <param name="ziZhi">资质</param>
        /// <param name="wuXing">悟性</param>
        /// <param name="nianLing">初始年龄</param>
        /// <param name="xingGe">性格</param>
        /// <param name="chengHao">称号</param>
        /// <param name="tag">标签</param>
        /// <param name="zhuJiTime">筑基时间</param>
        /// <param name="jinDanTime">金丹时间</param>
        /// <param name="yuanYingTime">元婴时间</param>
        /// <param name="huaShenTime">化神时间</param>
        /// <param name="daShiXiong">大师兄</param>
        /// <param name="zhangMen">掌门</param>
        /// <param name="zhangLao">长老</param>
        /// <param name="eventValue">事件列表</param>
        /// <param name="fuHao">符号</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetNpcImportant(
            int id,
            int liuPai,
            int level,
            int sex,
            int ziZhi,
            int wuXing,
            int nianLing,
            int xingGe,
            int chengHao,
            int tag,
            string zhuJiTime,
            string jinDanTime,
            string yuanYingTime,
            string huaShenTime,
            int daShiXiong,
            int zhangMen,
            int zhangLao,
            List<int> eventValue,
            string fuHao
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("LiuPai", liuPai);
            data.AddField("level", level);
            data.AddField("sex", sex);
            data.AddField("zizhi", ziZhi);
            data.AddField("wuxing", wuXing);
            data.AddField("nianling", nianLing);
            data.AddField("XingGe", xingGe);
            data.AddField("ChengHao", chengHao);
            data.AddField("NPCTag", tag);
            data.AddField("ZhuJiTime", zhuJiTime);
            data.AddField("JinDanTime", jinDanTime);
            data.AddField("YuanYingTime", yuanYingTime);
            data.AddField("HuaShengTime", huaShenTime);
            data.AddField("DaShiXiong", daShiXiong);
            data.AddField("ZhangMeng", zhangMen);
            data.AddField("ZhangLao", zhangLao);
            data.AddField("EventValue", eventValue.ToJsonObject());
            data.AddField("fuhao", fuHao);
            return data;
        }
        
        /// <summary>
        /// 获取指定参数的 NpcImportant 实例方法
        /// </summary>
        /// <param name="id">NPC 编号</param>
        /// <param name="liuPai">流派</param>
        /// <param name="level">境界</param>
        /// <param name="sex">性别</param>
        /// <param name="ziZhi">资质</param>
        /// <param name="wuXing">悟性</param>
        /// <param name="nianLing">初始年龄</param>
        /// <param name="xingGe">性格</param>
        /// <param name="chengHao">称号</param>
        /// <param name="tag">标签</param>
        /// <param name="zhuJiTime">筑基时间</param>
        /// <param name="jinDanTime">金丹时间</param>
        /// <param name="yuanYingTime">元婴时间</param>
        /// <param name="huaShenTime">化神时间</param>
        /// <param name="daShiXiong">大师兄</param>
        /// <param name="zhangMen">掌门</param>
        /// <param name="zhangLao">长老</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleNpcImportant(
            int id,
            int liuPai,
            int level,
            int sex,
            int ziZhi,
            int wuXing,
            int nianLing,
            int xingGe,
            int chengHao,
            int tag,
            string zhuJiTime,
            string jinDanTime,
            string yuanYingTime,
            string huaShenTime,
            int daShiXiong,
            int zhangMen,
            int zhangLao
        )
        {
            var eventValue = new List<int>();
            const string fuHao = "";

            return GetNpcImportant(id, liuPai, level, sex, ziZhi, wuXing, nianLing, xingGe, chengHao, tag, zhuJiTime,
                jinDanTime, yuanYingTime, huaShenTime, daShiXiong, zhangMen, zhangLao, eventValue, fuHao);
        }
        

        /// <summary>
        /// 获取指定参数的简易 NpcImportant 实例方法
        /// </summary>
        /// <param name="id">NPC 编号</param>
        /// <param name="sex">性别</param>
        /// <param name="xingGe">性格</param>
        /// <param name="chengHao">称号</param>
        /// <param name="tag">标签</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleNpcImportant(int id, int sex, int xingGe, int chengHao, int tag)
        {
            // 简易 NPC 属性模板
            const int liuPai = 161;
            const int level = 1;
            const int ziZhi = 100;
            const int wuXing = 100;
            const int age = 16;
            const string zhuJiTime = "";
            const string jinDanTime = "";
            const string yuanYingTime = "";
            const string huaShenTime = "";
            const int daShiXiong = 0;
            const int zhangMen = 0;
            const int zhangLao = 0;

            return GetSimpleNpcImportant(id, liuPai, level, sex, ziZhi, wuXing, age, xingGe, chengHao, tag, zhuJiTime,
                jinDanTime, yuanYingTime, huaShenTime, daShiXiong, zhangMen, zhangLao);
        }

        /// <summary>
        /// 重要 NPC 时间判定
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="xingWei">NPC 行为</param>
        /// <param name="eventValue">事件列表</param>
        /// <param name="fuHao">判定</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetNpcImportantPanDing(
            int id,
            int npcId,
            string startTime,
            string endTime,
            int xingWei,
            List<int> eventValue,
            string fuHao
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("NPC", npcId);
            data.AddField("EventValue", eventValue.ToJsonObject());
            data.AddField("fuhao", fuHao);
            data.AddField("StartTime", startTime);
            data.AddField("EndTime", endTime);
            data.AddField("XingWei", xingWei);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 NpcChengHao 实例方法
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="npcType">NPC 类型</param>
        /// <param name="chengHao">称号名称</param>
        /// <param name="chengHaoType">唯一称号标识</param>
        /// <param name="gongXian">门派贡献</param>
        /// <param name="level">境界区间</param>
        /// <param name="isOnly">是否唯一</param>
        /// <param name="chengHaoLv">称号等级</param>
        /// <param name="maxLevel">最大等级</param>
        /// <param name="change">称号权重行为</param>
        /// <param name="changeTo">增加值</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetNpcChengHao(
            int id,
            int npcType,
            string chengHao,
            int chengHaoType,
            int gongXian,
            List<int> level,
            int isOnly,
            int chengHaoLv,
            int maxLevel,
            List<int> change,
            List<int> changeTo
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("NPCType", npcType);
            data.AddField("GongXian", gongXian);
            data.AddField("Level", level.ToJsonObject());
            data.AddField("IsOnly", isOnly);
            data.AddField("ChengHaoLv", chengHaoLv);
            data.AddField("MaxLevel", maxLevel);
            data.AddField("ChengHao", chengHao);
            data.AddField("ChengHaoType", chengHaoType);
            data.AddField("Change", change.ToJsonObject());
            data.AddField("ChangeTo", changeTo.ToJsonObject());
            return data;
        }
        
        /// <summary>
        /// 获取指定参数的 NpcChengHao 实例方法
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="npcType">NPC 类型</param>
        /// <param name="chengHao">称号名称</param>
        /// <param name="chengHaoType">唯一称号标识</param>
        /// <param name="level">境界区间</param>
        /// <param name="isOnly">是否唯一</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleNpcChengHao(
            int id,
            int npcType,
            string chengHao,
            int chengHaoType,
            List<int> level,
            int isOnly = 1
        )
        {
            const int gongXian = 0;
            const int chengHaoLv = 1;
            const int maxLevel = 1;
            var change = new List<int>();
            var changeTo = new List<int>();

            return GetNpcChengHao(id, npcType, chengHao, chengHaoType, gongXian, level, isOnly, chengHaoLv, maxLevel,
                change, changeTo);
        }

        /// <summary>
        /// 获取指定参数的 NpcChengHao 实例方法
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="npcType">NPC 类型</param>
        /// <param name="chengHao">称号名称</param>
        /// <param name="chengHaoType">唯一称号标识</param>
        /// <param name="isOnly">是否唯一</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleNpcChengHao(
            int id,
            int npcType,
            string chengHao,
            int chengHaoType,
            int isOnly = 1
        )
        {
            var level = new List<int> { 1, 15 };

            return GetSimpleNpcChengHao(id, npcType, chengHao, chengHaoType, level, isOnly);
        }

        /// <summary>
        /// 武将绑定数据
        /// </summary>
        /// <param name="id">流水编号</param>
        /// <param name="name">Npc 名称</param>
        /// <param name="title">Npc 称号</param>
        /// <param name="image">Npc 形象</param>
        /// <param name="auction">Npc 拍卖场形象</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="avatars">绑定 Avatar 数据</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetAvatarBind(int id, string name, string title, int image, int auction,
            List<int> avatars, string startTime = "0001-01-01", string endTime = "5000-12-31")
        {
            var data = JSONObject.Create();
            data.AddField("id", id);
            data.AddField("Name", name);
            data.AddField("Title", title);
            data.AddField("Image", image);
            data.AddField("PaiMaiHang", auction);
            data.AddField("TimeStart", startTime);
            data.AddField("TimeEnd", endTime);
            data.AddField("avatar", avatars.ToJsonObject());
            return data;
        }
        
        /// <summary>
        /// 武将绑定数据
        /// </summary>
        /// <param name="id">流水编号</param>
        /// <param name="name">Npc 名称</param>
        /// <param name="title">Npc 称号</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="avatars">绑定 Avatar 数据</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetSimpleAvatarBind(int id, string name, string title,
            List<int> avatars, string startTime = "0001-01-01", string endTime = "5000-12-31")
        {
            var image = id * 10;
            var auction = id * 10;
            return GetAvatarBind(id, name, title, image, auction, avatars, startTime, endTime);
        }
    }
}