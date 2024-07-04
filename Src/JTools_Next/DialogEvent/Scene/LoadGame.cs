using System;
using SkySwordKill.Next.DialogEvent;
using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools.Tool;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEvent.Scene;

[DialogEvent("JT_LoadGame")]
[DialogEvent("JT_加载游戏")]
public class LoadGame : IDialogEvent
{
    public void Execute(DialogCommand command, DialogEnvironment env, Action callback)
    {
        var gameSceneName = command.GetStr(0);
        gameSceneName.LoadGame();
        callback?.Invoke();
    }
}