using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_DestroyAssetBundle")]
[DialogEvent("JT_释放AB资源")]
public class DestroyAssetBundle : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var assetBundleFileName = command.GetStr(0);
        AssetBundleManager.Inst.DestroyAssetBundle(assetBundleFileName);
        callback?.Invoke();
    }
}