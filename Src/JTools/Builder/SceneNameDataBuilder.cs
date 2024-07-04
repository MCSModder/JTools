using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 场景名称数据构造器
/// </summary>
public class SceneNameDataBuilder : BaseBuilder<SceneNameEntity>
{
    public override void Build() { Build(DataManager.SceneNameData); }

    public override void Load() { DataManager.Inst.sceneNameEntities.AddRange(Data); }
}