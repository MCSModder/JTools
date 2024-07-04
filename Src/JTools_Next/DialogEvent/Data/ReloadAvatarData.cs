using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Data;

[DialogEvent("JT_ReloadAvatarData")]
[DialogEvent("JT_立绘数据重载")]
public class ReloadAvatarData : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        DataManager.Inst.LoadAvatar();
        callback?.Invoke();
    }
}