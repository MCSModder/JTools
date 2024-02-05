using System.Collections.Generic;
using System.Linq;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// 数据刷新工具类
    /// </summary>
    public static class RefreshDataUtil
    {
        /// <summary>
        /// 刷新 Npc 背包数据 (直接替换)
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">背包数据</param>
        public static void ChangeNpcBackpackData(this int npcId, JSONObject backpackData)
        {
            jsonData.instance.AvatarBackpackJsonData[npcId.ToString()].SetField("Backpack", backpackData);
            $"已动态刷新 NPC: {npcId} 背包数据".Log();
        }

        /// <summary>
        /// 刷新 Npc 背包数据 (直接替换)
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">背包数据 (默认每种物品添加一个)</param>
        public static void ChangeNpcBackpackData(this int npcId, List<int> backpackData)
        {
            var backpack = JSONObject.arr;

            foreach (var item in backpackData)
            {
                backpack.Add(jsonData.instance.setAvatarBackpack(
                    Tools.getUUID(),
                    item,
                    1,
                    0,
                    100,
                    1,
                    Tools.CreateItemSeid(item)));
            }

            ChangeNpcBackpackData(npcId, backpack);
        }

        /// <summary>
        /// 刷新 Npc 背包数据 (直接替换)
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">背包数据</param>
        public static void ChangeNpcBackpackData(this int npcId, List<(int, int)> backpackData)
        {
            var backpack = JSONObject.arr;

            foreach (var item in backpackData)
            {
                backpack.Add(jsonData.instance.setAvatarBackpack(
                    Tools.getUUID(),
                    item.Item1,
                    item.Item2,
                    1,
                    100,
                    1,
                    Tools.CreateItemSeid(item.Item1)));
            }

            ChangeNpcBackpackData(npcId, backpack);
        }

        /// <summary>
        /// 添加 Npc 背包数据
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">新增背包数据</param>
        public static void AddNpcBackpackData(this int npcId, JSONObject backpackData)
        {
            if (jsonData.instance.AvatarBackpackJsonData[npcId.ToString()].HasField("Backpack"))
            {
                var backpack = jsonData.instance.AvatarBackpackJsonData[npcId.ToString()].GetField("Backpack");

                foreach (var data in backpackData.list)
                {
                    var flag = false;

                    foreach (var item in backpack.list.Where(item => item.EqualsField<int>(data, "ItemID")))
                    {
                        item.SetField("Num", item.GetFieldInt("Num") + data.GetFieldInt("Num"));
                        flag = true;
                        break;
                    }

                    if (flag) continue;

                    backpack.list.Add(data);
                }

                ChangeNpcBackpackData(npcId, backpack);
            }
            else
            {
                ChangeNpcBackpackData(npcId, backpackData);
            }
        }

        /// <summary>
        /// 添加 Npc 背包数据
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">新增背包数据 (默认每种物品添加一个)</param>
        public static void AddNpcBackpackData(this int npcId, List<int> backpackData)
        {
            var backpack = JSONObject.arr;

            foreach (var item in backpackData)
            {
                backpack.Add(jsonData.instance.setAvatarBackpack(
                    Tools.getUUID(),
                    item,
                    1,
                    0,
                    100,
                    1,
                    Tools.CreateItemSeid(item)));
            }

            AddNpcBackpackData(npcId, backpack);
        }

        /// <summary>
        /// 添加 Npc 背包数据
        /// </summary>
        /// <param name="npcId">NPC 编号</param>
        /// <param name="backpackData">新增背包数据</param>
        public static void AddNpcBackpackData(this int npcId, List<(int, int)> backpackData)
        {
            var backpack = JSONObject.arr;

            foreach (var item in backpackData)
            {
                backpack.Add(jsonData.instance.setAvatarBackpack(
                    Tools.getUUID(),
                    item.Item1,
                    item.Item2,
                    1,
                    100,
                    1,
                    Tools.CreateItemSeid(item.Item1)));
            }

            AddNpcBackpackData(npcId, backpack);
        }
    }
}