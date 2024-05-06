using System.Collections.Generic;
using SkySwordKill.NextModEditor.Mod;
using SkySwordKill.NextModEditor.Mod.Data;

namespace TierneyJohn.MiChangSheng.JTools_Next.Data;

public class ItemSeidMetaData
{
    public static ItemSeidMetaData Inst => _inst ??= new ItemSeidMetaData();

    private static ItemSeidMetaData _inst;
    private bool _isInit;
    private readonly List<ModSeidMeta> _modSeidMetas = [];

    private ItemSeidMetaData()
    {
        ModSeidMeta40();
    }

    public void Load()
    {
        if (_isInit) return;

        foreach (var meta in _modSeidMetas)
        {
            ModEditorManager.I.ItemUseSeidMetas.Add(meta.Id, meta);
        }

        _isInit = true;
    }

    /// <summary>
    /// 调用 Fungus 剧情
    /// </summary>
    private void ModSeidMeta40()
    {
        _modSeidMetas.Add(new ModSeidMeta
        {
            Id = 40,
            IDName = "id",
            Name = "调用 Fungus 剧情 (JTools 剧情限定)",
            Desc = "调用 Fungus 剧情 (JTools 剧情限定)",
            Properties =
            [
                new ModSeidProperty
                {
                    ID = "flowchart",
                    Type = ModSeidPropertyType.String,
                    Desc = "Flowchart 名称"
                },
                new ModSeidProperty
                {
                    ID = "block",
                    Type = ModSeidPropertyType.String,
                    Desc = "Block 名称"
                },
            ]
        });
    }
}