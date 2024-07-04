using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 物品数据构造器
/// </summary>
public class ItemDataBuilder : BaseBuilder<ItemEntity>
{
    public override void Build() { Build(DataManager.ItemData); }

    public override void Load() { DataManager.Inst.itemEntities.AddRange(Data); }
}