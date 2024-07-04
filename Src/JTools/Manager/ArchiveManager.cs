using System;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// 数据存读档管理器
/// </summary>
public class ArchiveManager : MonoBehaviour
{
    #region 字段/属性

    public static ArchiveManager Inst;

    public event Action OnSaved;

    public event Action OnLoaded;

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    #endregion

    #region 公开方法

    public void Saved() { OnSaved?.Invoke(); }

    public void Loaded() { OnLoaded?.Invoke(); }

    public void AutoSaveGame() { YSNewSaveSystem.AutoSave(); }

    public void AutoLoadGame() { YSNewSaveSystem.AutoLoad(); }

    #endregion
}