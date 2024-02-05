using UnityEngine;
using UnityEngine.UI;

namespace TierneyJohn.MiChangSheng.JTools.Manager
{
    /// <summary>
    /// 画面显示管理器
    /// </summary>
    public class CanvasManager : MonoBehaviour
    {
        #region 字段/属性定义

        public static CanvasManager Inst;

        public Canvas canvas;
        public Image image;

        #endregion

        #region Unity事件函数

        private void Awake()
        {
            Inst = this;
        }

        #endregion

        #region 公开方法

        public void Show(string path)
        {
            Show(ResManager.inst.LoadSprite(path));
        }

        public void Show(Sprite sprite)
        {
            Init();
            image.sprite = sprite;
            image.gameObject.SetActive(true);
        }

        public void Close()
        {
            image.gameObject.SetActive(false);
        }

        #endregion

        #region 私有方法

        private void Init()
        {
            if (!gameObject.GetComponent<Canvas>())
            {
                canvas = gameObject.AddComponent<Canvas>();
                canvas.sortingOrder = 20;
                canvas.planeDistance = 100;
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }

            if (transform.GetComponentInChildren<Image>()) return;

            var imageObject = new GameObject("CG Mask");
            imageObject.transform.SetParent(transform);
            image = imageObject.AddComponent<Image>();

            var imageRect = image.rectTransform;
            imageRect.position = Vector3.zero;
            imageRect.localScale = Vector3.one;
            imageRect.anchorMin = Vector2.zero;
            imageRect.anchorMax = Vector2.one;
            imageRect.offsetMin = Vector2.zero;
            imageRect.offsetMax = Vector2.zero;

            image.gameObject.SetActive(false);
        }

        #endregion
    }
}