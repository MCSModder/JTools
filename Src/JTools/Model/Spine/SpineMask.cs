using System;
using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools.Model.Spine;

/// <summary>
/// Spine 立绘圆形遮罩
/// </summary>
public class SpineMask : MonoBehaviour
{
    #region 字段,属性

    private Transform _canvas;
    private Transform _skeletonGraphic;

    /// <summary>
    /// 遮罩半径
    /// </summary>
    private float _radius;

    /// <summary>
    /// 遮罩内元素比例
    /// </summary>
    private float _scale;

    /// <summary>
    /// 遮罩内元素高度
    /// </summary>
    private float _high;

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        _canvas = transform.GetChild(0);
        _skeletonGraphic = _canvas.GetChild(0);
    }

    #endregion

    #region 公开方法

    public void ChangeMode(SpineMaskMode maskMode = SpineMaskMode.半身像)
    {
        switch (maskMode)
        {
            case SpineMaskMode.小头像:
                _radius = 60;
                _scale = 0.2f;
                _high = -620;
                break;

            case SpineMaskMode.半身像:
                _radius = 300;
                _scale = 0.36f;
                _high = -930;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(maskMode), maskMode, null);
        }

        InitMask();
    }

    public void Refresh(float radius, float scale, float high)
    {
        _radius = radius;
        _scale = scale;
        _high = high;

        InitMask();
    }

    #endregion

    #region 私有方法

    private void InitMask()
    {
        var go = new GameObject("AvatarMask");
        go.transform.SetParent(_canvas, false);

        // 生成圆形图片
        var image = go.AddComponent<Image>();
        image.sprite = CreateMaskSprite();
        image.type = Image.Type.Simple;

        var mask = go.AddComponent<Mask>();
        // 隐藏遮罩图像
        mask.showMaskGraphic = false;

        var rect = go.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(_radius * 2, _radius * 2);

        _skeletonGraphic.SetParent(go.transform, false);
        _skeletonGraphic.localPosition = new Vector3(10, _high);
        _skeletonGraphic.localScale = new Vector3(_scale, _scale);
    }

    private Sprite CreateMaskSprite()
    {
        var diameter = (int)(_radius * 2);
        var texture = new Texture2D(diameter, diameter, TextureFormat.ARGB32, false);
        var pixels = new Color32[diameter * diameter];

        var radiusSquared = _radius * _radius;
        var center = new Vector2(_radius, _radius);

        for (var y = 0; y < diameter; y++)
        {
            for (var x = 0; x < diameter; x++)
            {
                var pos = new Vector2(x, y);

                if (Vector2.SqrMagnitude(pos - center) <= radiusSquared)
                {
                    pixels[y * diameter + x] = new Color32(255, 255, 255, 255);
                }
                else
                {
                    pixels[y * diameter + x] = new Color32(0, 0, 0, 0);
                }
            }
        }

        texture.SetPixels32(pixels);
        texture.Apply();

        return Sprite.Create(texture, new Rect(0, 0, diameter, diameter), new Vector2(0.5f, 0.5f));
    }

    #endregion
}

public enum SpineMaskMode
{
    小头像,
    半身像
}