using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.MapEvent;

[DialogEvent("JT_ActiveMapEvent")]
[DialogEvent("JT_激活地图事件")]
public class ActiveMapEvent : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var eventId = command.GetInt(0);
        var eventType = command.GetInt(1);
        var nodeIndex = command.GetInt(2);
        MapEventManager.Inst.ActiveMapEvent(nodeIndex, eventId, eventType);
        callback?.Invoke();
    }
}