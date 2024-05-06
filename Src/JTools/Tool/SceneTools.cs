using GUIPackage;
using Tab;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TierneyJohn.MiChangSheng.JTools.Tool;

/// <summary>
/// 场景工具类
/// </summary>
public static class SceneTools
{
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    public static void LoadScene(this string sceneName)
    {
        PlayerEx.Player.lastScence = sceneName;
        Tools.jumpToName = sceneName;
        Tools.instance.loadSceneType = 1;

        SceneManager.LoadScene(sceneName);

        if (PanelMamager.inst.UIBlackMaskGameObject == null)
        {
            Object.Instantiate(ResManager.inst.LoadPrefab("BlackHide"));
        }

        PanelMamager.inst.UIBlackMaskGameObject.SetActive(false);
        PanelMamager.inst.UIBlackMaskGameObject.SetActive(true);

        if (PanelMamager.inst.UISceneGameObject == null)
        {
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
        }

        if (PanelMamager.inst.UISceneGameObject != null)
        {
            var npcTransform = PanelMamager.inst.UISceneGameObject.transform.Find("ThreeSceneNpcCanvas");
            if (npcTransform != null) npcTransform.gameObject.SetActive(true);
        }

        if (UI_Manager.inst != null)
        {
            if (ThreeSceernUIFab.inst != null) Object.Destroy(ThreeSceernUIFab.inst.gameObject);
            if (ThreeSceneMagFab.inst != null) Object.Destroy(ThreeSceneMagFab.inst.gameObject);
            if (SingletonMono<TabUIMag>.Instance != null) SingletonMono<TabUIMag>.Instance.TryEscClose();
        }

        Tools.instance.isNeedSetTalk = true;
        Tools.instance.CanOpenTab = true;
    }

    /// <summary>
    /// 加载游戏场景
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    public static void LoadGame(this string sceneName)
    {
        PlayerEx.Player.lastScence = sceneName;
        Tools.instance.ohtherSceneName = sceneName;
        Tools.instance.loadSceneType = 0;

        if (UI_Manager.inst != null)
        {
            if (ThreeSceernUIFab.inst != null) Object.Destroy(ThreeSceernUIFab.inst.gameObject);
            if (ThreeSceneMagFab.inst != null) Object.Destroy(ThreeSceneMagFab.inst.gameObject);
            if (SingletonMono<TabUIMag>.Instance != null) SingletonMono<TabUIMag>.Instance.TryEscClose();
        }

        Tools.instance.isNeedSetTalk = true;
        Tools.instance.CanOpenTab = true;

        SceneManager.LoadSceneAsync(sceneName);
        PanelMamager.inst.destoryUIGameObjet();
        Object.Destroy(PanelMamager.inst.UIBlackMaskGameObject);
    }
}