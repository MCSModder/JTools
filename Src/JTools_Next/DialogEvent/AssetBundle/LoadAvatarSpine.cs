using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_LoadAvatarSpine")]
[DialogEvent("JT_加载所有角色立绘资源")]
public class LoadAvatarSpine : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        AssetBundleManager.Inst.LoadAvatarSpine();
        callback?.Invoke();
    }
}