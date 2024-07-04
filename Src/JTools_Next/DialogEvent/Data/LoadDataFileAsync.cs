using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Data;

[DialogEvent("JT_LoadDataFileAsync")]
[DialogEvent("JT_异步加载数据文件")]
public class LoadDataFileAsync : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var path = command.GetStr(0);
        DataManager.Inst.LoadDataFileAsync(path);
        callback?.Invoke();
    }
}