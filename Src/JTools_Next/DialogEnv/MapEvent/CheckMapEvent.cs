using SkySwordKill.Next.DialogSystem;
using TierneyJohn.MiChangSheng.JTools_Next.Util;
using TierneyJohn.MiChangSheng.JTools.Manager;

namespace TierneyJohn.MiChangSheng.JTools_Next.DialogEnv.MapEvent;

[DialogEnvQuery("JT_CheckMapEvent")]
[DialogEnvQuery("JT_验证地图事件")]
public class CheckMapEvent : IDialogEnvQuery
{
    public object Execute(DialogEnvQueryContext context)
    {
        var eventId = context.GetValue<int>(0);
        var eventType = context.GetValue<int>(1);
        return MapEventManager.Inst.CheckMapEvent(eventId, eventType);
    }
}