using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_LoadAssetBundle")]
[DialogEvent("JT_加载AB资源")]
public class LoadAssetBundle : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var assetBundleFileName = command.GetStr(0);
        AssetBundleManager.Inst.LoadAssetBundle(assetBundleFileName);
        callback?.Invoke();
    }
}