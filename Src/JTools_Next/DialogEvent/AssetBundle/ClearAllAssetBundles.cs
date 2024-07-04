using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_ClearAllAssetBundles")]
[DialogEvent("JT_清空所有缓存AB资源")]
public class ClearAllAssetBundles : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        AssetBundleManager.Inst.ClearAllAssetBundles();
        callback?.Invoke();
    }
}