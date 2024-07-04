using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_LoadScenesAndNoCache")]
[DialogEvent("JT_加载所有场景AB资源")]
public class LoadScenesAndNoCache : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        AssetBundleManager.Inst.LoadScenesAndNoCache();
        callback?.Invoke();
    }
}