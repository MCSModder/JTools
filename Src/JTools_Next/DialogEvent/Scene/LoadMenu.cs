using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Scene;

[DialogEvent("JT_LoadMenu")]
[DialogEvent("JT_返回主界面")]
public class LoadMenu : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        "MainMenu".LoadScene();
        callback?.Invoke();
    }
}