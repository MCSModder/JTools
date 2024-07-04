using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Scene;

[DialogEvent("JT_LoadScene")]
[DialogEvent("JT_加载场景")]
public class LoadScene : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var sceneName = command.GetStr(0);
        sceneName.LoadScene();
        callback?.Invoke();
    }
}