using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Scene;

[DialogEvent("JT_LoadMap")]
[DialogEvent("JT_返回宁州")]
public class LoadMap : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        "AllMaps".LoadScene();
        callback?.Invoke();
    }
}