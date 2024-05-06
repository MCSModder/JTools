using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// 地图 UI 界面管理器
/// </summary>
public class UICloseManager : MonoBehaviour
{
    #region 字段/属性

    public static UICloseManager Inst;

    public readonly List<IUIClose> MapUIList = [];

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        Inst = this;
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Update()
    {
        if (!MapUIList.Any()) return;

        Tools.canClickFlag = false;
        PanelMamager.CanOpenOrClose = false;

        if (Input.GetKeyUp(KeyCode.Tab) || Input.GetKeyUp(KeyCode.Escape))
        {
            CloseAll();
        }
    }

    #endregion

    #region 初始化加载方法

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CloseAll();
    }

    #endregion

    #region IMapUIClose 处理

    /// <summary>
    /// UI 注册方法
    /// </summary>
    public void Register(IUIClose ui)
    {
        if (MapUIList.Contains(ui)) MapUIList.Remove(ui);
        MapUIList.Add(ui);
    }

    /// <summary>
    /// UI 卸载方法
    /// </summary>
    public void Logout(IUIClose ui)
    {
        Tools.canClickFlag = true;
        PanelMamager.CanOpenOrClose = true;
        MapUIList.Remove(ui);
    }

    /// <summary>
    /// UI 快速关闭方法
    /// </summary>
    public void CloseAll()
    {
        for (var index = MapUIList.Count - 1; index >= 0; index--)
        {
            MapUIList[index]?.TryClose();
        }
    }

    #endregion
}

/// <summary>
/// UI 快捷关闭接口
/// </summary>
public interface IUIClose
{
    void TryClose();
}