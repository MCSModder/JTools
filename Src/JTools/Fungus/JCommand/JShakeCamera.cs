using System;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 ShakeCamera 指令
/// </summary>
[Serializable]
public class JShakeCamera : global::Fungus.ShakeCamera
{
    /// <summary>
    /// 摇晃摄影机指令
    /// </summary>
    /// <returns>JShakeCamera 对象</returns>
    public JShakeCamera Create()
    {
        return this;
    }
}