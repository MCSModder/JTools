using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 背包数据工厂类
    /// </summary>
    public class BackpackFactory
    {
        /// <summary>
        /// 获取指定参数的 BackpackJson 数据
        /// </summary>
        /// <param name="backpackId">背包编号</param>
        /// <param name="avatarId">角色编号</param>
        /// <param name="backpackName">背包名称</param>
        /// <param name="type">背包类型</param>
        /// <param name="quality">背包品阶</param>
        /// <param name="itemId">物品编号</param>
        /// <param name="randomNumber">刷新数量</param>
        /// <param name="canSell">是否可以售卖</param>
        /// <param name="sellPercent">售价百分比</param>
        /// <param name="canDrop">能否掉落</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int backpackId,
            int avatarId,
            string backpackName,
            int type,
            int quality,
            List<int> itemId,
            List<int> randomNumber,
            int canSell,
            int sellPercent,
            int canDrop
        )
        {
            var data = JSONObject.Create();
            data.AddField("id", backpackId);
            data.AddField("AvatrID", avatarId);
            data.AddField("BackpackName", backpackName);
            data.AddField("Type", type);
            data.AddField("quality", quality);
            data.AddField("ItemID", itemId.ToJsonObject());
            data.AddField("randomNum", randomNumber.ToJsonObject());
            data.AddField("CanSell", canSell);
            data.AddField("SellPercent", sellPercent);
            data.AddField("CanDrop", canDrop);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 BackpackJson 数据
        /// </summary>
        /// <param name="backpackId">背包编号</param>
        /// <param name="avatarId">角色编号</param>
        /// <param name="backpackName">背包名称</param>
        /// <param name="type">背包类型</param>
        /// <param name="quality">背包品阶</param>
        /// <param name="items">物品组</param>
        /// <param name="canSell">是否可以售卖</param>
        /// <param name="sellPercent">售价百分比</param>
        /// <param name="canDrop">能否掉落</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(int backpackId,
            int avatarId,
            string backpackName,
            int type,
            int quality,
            List<(int, int)> items,
            int canSell,
            int sellPercent,
            int canDrop)
        {
            var itemId = new List<int>();
            var randomNumber = new List<int>();

            foreach (var item in items)
            {
                itemId.Add(item.Item1);
                randomNumber.Add(item.Item2);
            }

            return GetInstance(backpackId, avatarId, backpackName, type, quality, itemId, randomNumber, canSell,
                sellPercent, canDrop);
        }
    }
}