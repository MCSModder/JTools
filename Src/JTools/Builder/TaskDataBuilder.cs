using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// 任务数据构造器
/// </summary>
public class TaskDataBuilder : BaseBuilder<TaskEntity>
{
    public override void Build() { Build(DataManager.TaskData); }

    public override void Load() { DataManager.Inst.taskEntities.AddRange(Data); }
}