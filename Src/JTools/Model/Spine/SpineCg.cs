using System.Linq;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TierneyJohn.MiChangSheng.JTools.Model.Spine;

/// <summary>
/// Spine 动态 CG 组件
/// </summary>
public class SpineCg : MonoBehaviour
{
    #region 字段属性

    /// <summary>
    /// 单例模式
    /// </summary>
    public static SpineCg Inst;

    /// <summary>
    /// 当前所在场景数据
    /// </summary>
    public Scene scene;

    #region Spine 对象数据

    /// <summary>
    /// Spine 数据主体
    /// </summary>
    public Transform spine;

    /// <summary>
    /// SkeletonGraphic 数据
    /// </summary>
    public SkeletonGraphic skeletonGraphic;

    /// <summary>
    /// Skeleton 数据
    /// </summary>
    public Skeleton Skeleton
    {
        get => skeletonGraphic.Skeleton;
    }

    /// <summary>
    /// Skin 数据
    /// </summary>
    public Skin Skin
    {
        get => Skeleton.Skin;
        set
        {
            Skeleton.SetSkin(value);
            RefreshSpine();
        }
    }

    #endregion

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        Inst = this;
        scene = gameObject.scene;
        spine = scene.GetRootGameObjects().First(go => go.name.Equals("Spine") || go.name.Equals(scene.name)).transform;
        skeletonGraphic = spine?.GetChild(0).GetChild(0).GetComponent<SkeletonGraphic>();
    }

    private void Start() { ScreenAdaptive(); }

    #endregion

    #region 加载方法

    private void ScreenAdaptive()
    {
        var scale = spine.localScale;
        var scaleX = Screen.width / 1920f;
        var scaleY = Screen.height / 1080f;
        spine.localScale = new Vector3(scale.x * scaleX, scale.y * scaleY);
    }

    #endregion

    #region 公开方法

    public void SetSkin(string skinName)
    {
        Skeleton.SetSkin(skinName);
        RefreshSpine();
    }

    public void RefreshSpine()
    {
        skeletonGraphic.initialSkinName = Skin.Name;
        skeletonGraphic.Initialize(true);
    }

    #endregion
}