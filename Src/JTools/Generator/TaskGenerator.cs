using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Enum.Task;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>任务数据生成器</summary>
public static class TaskGenerator
{
    public static TaskEntity Generator(
        int taskId,
        string taskName,
        string title,
        string desc,
        List<(int, string, bool)> taskInfos
    )
    {
        List<TaskInfoEntity> infos = [];
        var index = 1;

        foreach ((var infoId, var infoDesc, var isFinal) in taskInfos)
        {
            infos.Add(TaskInfoGenerator(infoId, taskId, index++, infoDesc, isFinal));
        }

        return Generator(taskId, taskName, title, desc, infos);
    }

    public static TaskEntity Generator(
        int id,
        string taskName,
        string title,
        string desc,
        List<TaskInfoEntity> taskInfos,
        string startTime = null,
        string endTime = null,
        TaskType type = TaskType.任务,
        bool isFinish = false,
        int variable = 999,
        int circulation = 0,
        int continueTime = 0,
        int mapIndex = 0,
        List<int> eventValue = null,
        string flag = ""
    )
    {
        startTime ??= "0001-01-01";
        endTime ??= "5000-12-30";

        return new TaskEntity
        {
            Id = id,
            TaskName = taskName,
            Title = title,
            Desc = desc,
            TaskInfos = taskInfos,
            StartTime = startTime,
            EndTime = endTime,
            Type = type,
            IsFinish = isFinish,
            Variable = variable,
            Circulation = circulation,
            ContinueTime = continueTime,
            MapIndex = mapIndex,
            EventValue = eventValue,
            Flag = flag
        };
    }

    public static TaskInfoEntity TaskInfoGenerator(
        int id,
        int taskId,
        int taskIndex,
        string desc,
        bool isFinal = false,
        int mapIndex = 0
    )
    {
        return new TaskInfoEntity
        {
            Id = id,
            TaskId = taskId,
            TaskIndex = taskIndex,
            Desc = desc,
            IsFinal = isFinal,
            MapIndex = mapIndex
        };
    }
}