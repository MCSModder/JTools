using System.Collections.Generic;
using SkySwordKill.NextModEditor.Mod;
using SkySwordKill.NextModEditor.Mod.Data;

namespace TierneyJohn.MiChangSheng.JTools_Next.Data
{
    public class ModSeidMetaData
    {
        public static ModSeidMetaData Inst => _inst ?? new ModSeidMetaData();

        private static ModSeidMetaData _inst;
        private bool _isInit;
        private readonly List<ModSeidMeta> _modSeidMetas = [];

        private ModSeidMetaData()
        {
            _inst = this;
            ModSeidMeta316();
            ModSeidMeta317();
            ModSeidMeta318();
            ModSeidMeta319();
            ModSeidMeta320();
            ModSeidMeta321();
            ModSeidMeta322();
            ModSeidMeta323();
            ModSeidMeta324();
            ModSeidMeta325();
            ModSeidMeta326();
            ModSeidMeta327();
            ModSeidMeta328();
            ModSeidMeta329();
            ModSeidMeta330();
            ModSeidMeta331();
            ModSeidMeta332();
            ModSeidMeta333();
            ModSeidMeta334();
            ModSeidMeta335();
        }

        public void Load()
        {
            if (_isInit) return;

            foreach (var meta in _modSeidMetas)
            {
                ModEditorManager.I.BuffSeidMetas.Add(meta.Id, meta);
            }

            _isInit = true;
        }

        /// <summary>
        /// 将角色血量修改为固定值
        /// </summary>
        private void ModSeidMeta316()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 316,
                IDName = "id",
                Name = "将角色血量修改为固定值",
                Desc = "将对应角色血量修改为 X (进行了安全处理，修改后不会超出血量上限也不会低于1)",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "X:修改后的血量值"
                    }
                ]
            });
        }

        /// <summary>
        /// 移除玩家当前战斗面板指定神通组
        /// </summary>
        private void ModSeidMeta317()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 317,
                IDName = "id",
                Name = "移除玩家当前战斗面板中的指定神通组",
                Desc = "将玩家当前战斗面板中的，存在于 X 集合中的神通全部移除",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "新神通唯一编号列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 添加玩家当前战斗面板指定神通组
        /// </summary>
        private void ModSeidMeta318()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 318,
                IDName = "id",
                Name = "添加玩家当前战斗面板中的指定神通组",
                Desc = "在玩家当前战斗面板中添加，存在于 X 集合中的神通(需要有空余位置)",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "新神通唯一编号列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 替换玩家当前战斗面板指定神通组
        /// </summary>
        private void ModSeidMeta319()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 319,
                IDName = "id",
                Name = "替换玩家当前战斗面板中的指定神通组",
                Desc = "对玩家当前的战斗面板神通进行替换",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "原神通唯一编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "新神通唯一编号列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 若角色背包拥有指定数量的对应物品,则触发后续特效
        /// </summary>
        private void ModSeidMeta320()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 320,
                IDName = "id",
                Name = "若角色背包拥有指定数量的对应物品,则触发后续特效",
                Desc = "若角色背包内X物品数量大于等于Y,则触发后续特效",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:物品编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "Y:物品数量列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 移除角色背包指定数量物品
        /// </summary>
        private void ModSeidMeta321()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 321,
                IDName = "id",
                Name = "移除角色背包指定数量物品",
                Desc = "移除角色背包指定X物品Y个",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:物品编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "Y:物品数量列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 移除玩家背包指定数量物品 (不论该buff由谁触发)
        /// </summary>
        private void ModSeidMeta322()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 322,
                IDName = "id",
                Name = "移除玩家背包指定数量物品(不论该buff由谁触发)",
                Desc = "移除玩家背包指定X物品Y个(不论该buff由谁触发)",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:物品编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "Y:物品数量列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 给角色背包添加指定数量物品
        /// </summary>
        private void ModSeidMeta323()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 323,
                IDName = "id",
                Name = "给角色背包添加指定数量物品",
                Desc = "给角色背包添加指定X物品Y个",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:物品编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "Y:物品数量列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 给玩家背包添加指定数量物品 (不论该buff由谁触发)
        /// </summary>
        private void ModSeidMeta324()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 324,
                IDName = "id",
                Name = "给玩家背包添加指定数量物品(不论该buff由谁触发)",
                Desc = "给玩家背包添加指定X物品Y个(不论该buff由谁触发)",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:物品编号列表"
                    },

                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "Y:物品数量列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 随机释放神通
        /// </summary>
        private void ModSeidMeta325()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 325,
                IDName = "id",
                Name = "随机释放神通",
                Desc = "随机释放一次X列表内的神通，可与129特性配合",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:神通列表列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 连续释放多个神通
        /// </summary>
        private void ModSeidMeta326()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 326,
                IDName = "id",
                Name = "连续释放多个神通",
                Desc = "连续释放一次X列表内的神通，可与129特性配合",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "X:神通列表列表"
                    }
                ]
            });
        }

        /// <summary>
        /// 连续释放多个神通
        /// </summary>
        private void ModSeidMeta327()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 327,
                IDName = "id",
                Name = "将当前角色与对方的境界做比较，满足条件时触发后续特性",
                Desc = "正数比较是否大于对方指定境界；负数比较是否小于对方指定境界；0表示境界相等时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "正数比较是否大于对方指定境界；负数比较是否小于对方指定境界；0表示境界相等时触发"
                    }
                ]
            });
        }

        /// <summary>
        /// 连续释放多个神通
        /// </summary>
        private void ModSeidMeta328()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 328,
                IDName = "id",
                Name = "将当前角色与对方的大境界做比较，满足条件时触发后续特性",
                Desc = "正数比较是否大于对方指定大境界；负数比较是否小于对方指定大境界；0表示大境界相等时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "正数比较是否大于对方指定大境界；负数比较是否小于对方指定大境界；0表示大境界相等时触发"
                    }
                ]
            });
        }

        /// <summary>
        /// 若该次伤害超过 X% 血量，则触发后续特性
        /// </summary>
        private void ModSeidMeta329()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 329,
                IDName = "id",
                Name = "若该次伤害超过 X% 血量，则触发后续特性",
                Desc = "判断该次所受伤害，若该次伤害超过 X% 血量时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(0~100)"
                    }
                ]
            });
        }

        /// <summary>
        /// 若该次伤害未超过 X% 血量，则触发后续特性
        /// </summary>
        private void ModSeidMeta330()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 330,
                IDName = "id",
                Name = "若该次伤害未超过 X% 血量，则触发后续特性",
                Desc = "判断该次所受伤害，若该次伤害未超过 X% 血量时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(0~100)"
                    }
                ]
            });
        }

        /// <summary>
        /// 若该次伤害导致血量低于 X%，则触发后续特性
        /// </summary>
        private void ModSeidMeta331()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 331,
                IDName = "id",
                Name = "若该次伤害导致血量低于 X%，则触发后续特性",
                Desc = "判断该次所受伤害，若该次伤害导致血量低于 X% 时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(0~100)"
                    }
                ]
            });
        }

        /// <summary>
        /// 若该次伤害导致血量未低于 X%，则触发后续特性
        /// </summary>
        private void ModSeidMeta332()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 332,
                IDName = "id",
                Name = "若该次伤害导致血量未低于 X%，则触发后续特性",
                Desc = "判断该次所受伤害，若该次伤害导致血量未低于 X% 时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(0~100)"
                    }
                ]
            });
        }

        /// <summary>
        /// 角色血量增加(减少) X%
        /// </summary>
        private void ModSeidMeta333()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 333,
                IDName = "id",
                Name = "角色血量增加(减少) X%",
                Desc = "使角色血量增加或降低 X%,不会超出血量上限以及低于1点。",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(-100~100)"
                    }
                ]
            });
        }

        /// <summary>
        /// 若该次伤害导致血量低于 [X%,Y%,Z%...]，则触发后续特性
        /// </summary>
        private void ModSeidMeta334()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 334,
                IDName = "id",
                Name = "若该次伤害导致血量低于 [X%,Y%,Z%...] ，则触发后续特性",
                Desc = "判断该次所受伤害，若该次伤害导致血量低于 [X%,Y%,Z%...] 时触发",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "血量百分比(0~100) 是一个血量阈值组"
                    }
                ]
            });
        }

        /// <summary>
        /// 角色每受到 X% 血量伤害，获得一个 Y buff Z 层
        /// </summary>
        private void ModSeidMeta335()
        {
            _modSeidMetas.Add(new ModSeidMeta
            {
                Id = 335,
                IDName = "id",
                Name = "角色每受到 X% 血量伤害，获得一个 Y buff Z 层",
                Desc = "角色每受到 X% 血量伤害，获得一个 Y buff Z 层",
                Properties =
                [
                    new ModSeidProperty
                    {
                        ID = "value1",
                        Type = ModSeidPropertyType.Int,
                        Desc = "血量百分比(0~100) 是一个血量伤害值"
                    },
                    new ModSeidProperty
                    {
                        ID = "value2",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "待添加Buff编号组,要和Buff数量一一对应"
                    },
                    new ModSeidProperty
                    {
                        ID = "value3",
                        Type = ModSeidPropertyType.IntArray,
                        Desc = "待添加Buff层数组,要和Buff编号一一对应"
                    }
                ]
            });
        }
    }
}