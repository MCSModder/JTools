using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.MapEvent;

[DialogEvent("JT_RefreshMapEvent")]
[DialogEvent("JT_刷新大地图事件")]
public class RefreshMapEvent : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        MapEventManager.Inst.RefreshMapEventData();
        callback?.Invoke();
    }
}