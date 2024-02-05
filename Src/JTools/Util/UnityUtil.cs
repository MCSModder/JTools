using System.Collections.Generic;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// Unity 相关工具扩展
    /// </summary>
    public static class UnityUtil
    {
        private const string ComponentName = "SpriteRenderer";
        private const string ErrorShaderName = "Hidden/InternalErrorShader";
        private const string DefaultShaderName = "Sprites/Default";

        #region Shader 相关

        public static void InitShader(this Transform transform)
        {
            foreach (var component in transform.GetComponents<Component>())
            {
                if (!ComponentName.Equals(component.GetType().Name)) continue;

                var material = component.GetComponent<SpriteRenderer>().material;

                if (material == null)
                {
                    "Material is Null".Warn();
                    continue;
                }

                var shader = material.shader;

                if (shader == null)
                {
                    "Shader is Null".Warn();
                    continue;
                }

                if (ErrorShaderName.Equals(shader.name))
                {
                    component.GetComponent<SpriteRenderer>().material.shader = Shader.Find(DefaultShaderName);
                }
            }

            var childCount = transform.childCount;
            for (var i = 0; i < childCount; i++)
            {
                transform.GetChild(i).InitShader();
            }
        }

        public static void InitShader(this GameObject gameObject)
        {
            gameObject.transform.InitShader();
        }

        public static void InitShader(this IEnumerable<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.InitShader();
            }
        }

        #endregion

        #region Image 相关

        public static Sprite ToSprite(this Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        #endregion

        #region Vector 相关

        public static Vector3 ToNew(this Vector3 vector)
        {
            return vector.ToNew(0, 0);
        }

        public static Vector3 ToNew(this Vector3 vector, float x, float y)
        {
            return vector.ToNew(x, y, 0);
        }

        public static Vector3 ToNew(this Vector3 vector, float x, float y, float z)
        {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        #endregion
    }
}