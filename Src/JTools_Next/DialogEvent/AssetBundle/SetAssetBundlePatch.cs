using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.AssetBundle;

[DialogEvent("JT_SetAssetBundlePatch")]
[DialogEvent("JT_设置AB加载路径")]
public class SetAssetBundlePatch : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var path = command.GetStr(0);
        AssetBundleManager.Inst.SetAssetBundlePatch(path);
        callback?.Invoke();
    }
}