using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Factory
{
    /// <summary>
    /// 拍卖数据工厂类
    /// </summary>
    public class AuctionFactory
    {
        /// <summary>
        /// 获取指定参数的 Auction 数据
        /// </summary>
        /// <param name="id">拍卖行编号</param>
        /// <param name="name">拍卖会名称</param>
        /// <param name="scene">拍卖会地点</param>
        /// <param name="itemNum">拍卖物品格子</param>
        /// <param name="price">入场持有金额</param>
        /// <param name="ruChangFei">入场费</param>
        /// <param name="startTime">拍卖会开始时间</param>
        /// <param name="endTime">拍卖会结束时间</param>
        /// <param name="circulation">拍卖会开启间隔</param>
        /// <param name="paiMaiFenZu">拍卖分组</param>
        /// <param name="jiMaiNum">寄卖格子数量</param>
        /// <param name="isBuShuaXin">是否不刷新</param>
        /// <param name="level">拍卖会主持人等级</param>
        /// <param name="type">商品类型</param>
        /// <param name="quality">商品品阶</param>
        /// <param name="quanZhong1">商品权重</param>
        /// <param name="guDing">固定商品类型</param>
        /// <param name="quanZhong2">固定商品权重</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int id,
            string name,
            string scene,
            int itemNum,
            int price,
            int ruChangFei,
            string startTime,
            string endTime,
            int circulation,
            int paiMaiFenZu,
            int jiMaiNum,
            int isBuShuaXin,
            int level,
            List<int> type,
            List<int> quality,
            List<int> quanZhong1,
            List<int> guDing,
            List<int> quanZhong2
        )
        {
            var data = JSONObject.Create();
            data.AddField("PaiMaiID", id);
            data.AddField("Name", name);
            data.AddField("ChangJing", scene);
            data.AddField("ItemNum", itemNum);
            data.AddField("Price", price);
            data.AddField("RuChangFei", ruChangFei);
            data.AddField("StarTime", startTime);
            data.AddField("EndTime", endTime);
            data.AddField("circulation", circulation);
            data.AddField("paimaifenzu", paiMaiFenZu);
            data.AddField("jimainum", jiMaiNum);
            data.AddField("IsBuShuaXin", isBuShuaXin);
            data.AddField("Type", type.ToJsonObject());
            data.AddField("quality", quality.ToJsonObject());
            data.AddField("quanzhong1", quanZhong1.ToJsonObject());
            data.AddField("guding", guDing.ToJsonObject());
            data.AddField("quanzhong2", quanZhong2.ToJsonObject());
            data.AddField("level", level);
            return data;
        }

        /// <summary>
        /// 获取指定参数的 Auction 数据
        /// </summary>
        /// <param name="id">拍卖行编号</param>
        /// <param name="name">拍卖会名称</param>
        /// <param name="scene">拍卖会地点</param>
        /// <param name="itemNum">拍卖物品格子</param>
        /// <param name="price">入场持有金额</param>
        /// <param name="ruChangFei">入场费</param>
        /// <param name="startTime">拍卖会开始时间</param>
        /// <param name="endTime">拍卖会结束时间</param>
        /// <param name="circulation">拍卖会开启间隔</param>
        /// <param name="paiMaiFenZu">拍卖分组</param>
        /// <param name="jiMaiNum">寄卖格子数量</param>
        /// <param name="isBuShuaXin">是否不刷新</param>
        /// <param name="level">拍卖会主持人等级</param>
        /// <param name="goods">拍卖品数据</param>
        /// <param name="goods2">固定拍卖品数据</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int id,
            string name,
            string scene,
            int itemNum,
            int price,
            int ruChangFei,
            string startTime,
            string endTime,
            int circulation,
            int paiMaiFenZu,
            int jiMaiNum,
            int isBuShuaXin,
            int level,
            IEnumerable<List<int>> goods,
            IEnumerable<List<int>> goods2
        )
        {
            var type = new List<int>();
            var quality = new List<int>();
            var quanZhong1 = new List<int>();
            var guDing = new List<int>();
            var quanZhong2 = new List<int>();

            foreach (var items in goods.Where(items => items.Count == 3))
            {
                type.Add(items[0]);
                quality.Add(items[1]);
                quanZhong1.Add(items[2]);
            }

            foreach (var items in goods2.Where(items => items.Count == 2))
            {
                guDing.Add(items[0]);
                quanZhong2.Add(items[1]);
            }

            return GetInstance(id, name, scene, itemNum, price, ruChangFei, startTime, endTime, circulation,
                paiMaiFenZu, jiMaiNum, isBuShuaXin, level, type, quality, quanZhong1, guDing, quanZhong2);
        }

        /// <summary>
        /// 获取指定参数的 Auction 数据
        /// </summary>
        /// <param name="id">拍卖行编号</param>
        /// <param name="name">拍卖会名称</param>
        /// <param name="scene">拍卖会地点</param>
        /// <param name="itemNum">拍卖物品格子</param>
        /// <param name="price">入场持有金额</param>
        /// <param name="ruChangFei">入场费</param>
        /// <param name="startTime">拍卖会开始时间</param>
        /// <param name="endTime">拍卖会结束时间</param>
        /// <param name="circulation">拍卖会开启间隔</param>
        /// <param name="paiMaiFenZu">拍卖分组</param>
        /// <param name="jiMaiNum">寄卖格子数量</param>
        /// <param name="isBuShuaXin">是否不刷新</param>
        /// <param name="level">拍卖会主持人等级</param>
        /// <param name="goods">拍卖品数据</param>
        /// <param name="goods2">固定拍卖品数据</param>
        /// <returns>JSONObject 实例</returns>
        public static JSONObject GetInstance(
            int id,
            string name,
            string scene,
            int itemNum,
            int price,
            int ruChangFei,
            string startTime,
            string endTime,
            int circulation,
            int paiMaiFenZu,
            int jiMaiNum,
            int isBuShuaXin,
            int level,
            List<(int, int, int)> goods,
            List<(int, int)> goods2
        )
        {
            var type = new List<int>();
            var quality = new List<int>();
            var quanZhong1 = new List<int>();
            var guDing = new List<int>();
            var quanZhong2 = new List<int>();

            foreach (var items in goods)
            {
                type.Add(items.Item1);
                quality.Add(items.Item2);
                quanZhong1.Add(items.Item3);
            }

            foreach (var items in goods2)
            {
                guDing.Add(items.Item1);
                quanZhong2.Add(items.Item2);
            }

            return GetInstance(id, name, scene, itemNum, price, ruChangFei, startTime, endTime, circulation,
                paiMaiFenZu, jiMaiNum, isBuShuaXin, level, type, quality, quanZhong1, guDing, quanZhong2);
        }
    }
}