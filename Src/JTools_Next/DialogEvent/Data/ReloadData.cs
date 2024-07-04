using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Data;

[DialogEvent("JT_ReloadData")]
[DialogEvent("JT_数据重载")]
public class ReloadData : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        DataManager.Inst.LoadData();
        callback?.Invoke();
    }
}