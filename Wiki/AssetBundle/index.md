# AB 资源管理器

## 简介

提供了一套 AssetBundle 资源的便捷处理方式，关于 AssetBundle 资源的处理及 Unity 相关的处理这里不做过多描述。

同时提供有 AssetBundle 加载及调用的相关方法，同时也配置了数据缓存及数据卸载相关的处理。另外针对 AssetBundle 数据存在的 **(
shader)** 材质丢失问题也做了通用处理。

## 目录

- [AB 资源存放路径](#ab-资源存放路径)
- [AB 资源管理器功能介绍](#ab-资源管理器功能介绍)
- [代码使用示例](#代码使用示例)

## AB 资源存放路径

理论上可以将 AssetBundle 数据存放到任意路径下，因为 JTools 有提供资源路径配置的方法，但仍旧建议存放到 JTools
推荐的*默认路径*内，以防止和其他工具库的资源加载发生冲突。

默认存放路径：**SteamId(Mod名称)/plugins/AssetBundle/**

> 另：因为现在版本中 Next 也提供了一种 AssetBundle 资源加载的方式，所以也可以将 AssetBundle 资源存放到 Next 支持的资源目录下
**SteamId(Mod名称)/plugins/Next/modXXX/AssetBundles/**

## AB 资源管理器功能介绍

> 因此该管理器中存在一些过时方法(仍旧可用只是不推荐,每个方法上都有相应的推荐方法) 因此会有部分方法没有在下方列出，但是可以根据方法上的说明对照使用

| 方法体                                                                        | 参数介绍                                                              | 返回值         | 方法说明                                                                                                                                                                                      |
|----------------------------------------------------------------------------|-------------------------------------------------------------------|-------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SetAssetBundlePatch(string directoryPath)                                  | directoryPath 资源存放路径                                              | void        | 设置 AB 资源加载路径<br/>这里需要配置完整的访问路径，如果想要简化访问，可以使用下面的方法<br/>因为要兼容多Mod的调用，因此建议在资源加载之前都手动设定一次加载路径，以防访问路径被其他 Mod 修改                                                                                |
| SetAssetBundlePatch(Type mainClass, string path = "/AssetBundle")          | mainClass 调用方主函数类型<br/>path 资源访问路径                                | void        | 通过主函数类型设定 AB 资源加载路径，基于类型反推 dll 文件所在路径，因此可以简化访问路径<br/>path参数使用了默认值，当然也可以根据实际需求自行更改                                                                                                         |
| LoadAssetBundle(string assetBundleFileName)                                | assetBundleFileName ab资源文件名称                                      | AssetBundle | 根据当前设定的资源加载路径加载指定名称的 AB 资源文件<br/>此方法在加载后，会将 AssetBundle 数据文件名作为 key 值，将数据缓存到资源字典里<br/>该方法仅做了简单的 IO 异常处理,若资源文件不存在会抛出 **AssetBundleFileNotFoundException** 异常，建议使用 **TryGetAssetBundle** 方法 |
| TryGetAssetBundle(string assetBundleFileName, out AssetBundle assetBundle) | assetBundleFileName  ab资源文件名称<br/>assetBundle 加载数据                | bool        | 根据当前设定的资源加载路径加载指定名称的 AB 资源文件<br/>需要注意若返回值为 False 则 assetBundle 对象仅为 default 值，请务必做返回值校验处理                                                                                                 |
| GetAsset<T>(string assetBundleFileName, string assetName)                  | assetBundleFileName ab资源文件名称<br/>assetName 资源名称                   | T           | 获取 AB 资源的某个资源数据<br/>此方法更适用于静态资源的获取                                                                                                                                                        |
| LoadUI<T>(string assetBundleFileName, string canvasPath, Transform parent) | assetBundleFileName ab资源文件名称<br/>canvasPath 数据路径<br/>parent 挂载父对象 | T           | 根据资源 key 值及数据路径，获取指定的 AB 资源内数据，同时在其上挂载一个 Component 组件<br/>对于深层次的数据对象，则可以通过类似 "AA/BB/C" 来获取，同时该方法返回绑定好的 Component 数据对象                                                                     |
| LoadUI<T>(string assetBundleFileName, string canvasPath)                   | assetBundleFileName ab资源文件名称<br/>canvasPath 数据路径                  | T           | 根据资源 key 值及数据路径，获取指定的 AB 资源内数据，同时在其上挂载一个 Component 组件<br/>同上方法，只是不再显式提供父组件                                                                                                                |
| LoadAvatarSpine()                                                          |                                                                   | void        | 加载指定路径的所有 Spine 立绘资源<br/>Spine数据的相关处理可以参考[Spine 动态立绘管理器](../Spine/index.md)                                                                                                               |
| LoadScenesAndNoCache()                                                     |                                                                   | void        | 加载指定路径的所有 AB 资源文件，此方法不会保存 AB 资源的数据缓存<br/>此方法可以对所有 AB 资源进行预载，同 Next 的加载处理相似<br/>此方法更适合场景类数据的预载                                                                                             |
| DestroyAssetBundle(string assetBundleFileName)                             | assetBundleFileName ab资源文件名称                                      | void        | 移除并释放一个 AB 资源<br/>因为 AssetBundle 数据文件名本身也是缓存数据的 key 值，因此移除时也通过此值进行索引                                                                                                                      |
| DestroyAssetBundle<T>(string assetBundleFileName)                          | assetBundleFileName ab资源文件名称                                      | void        | 移除并释放一个 AB 资源,并同时释放该资源所绑定的 Component 对象<br/>此方法为 UI 类型数据的增强处理                                                                                                                             |

## 代码使用示例

#### AssetBundle 方法增强处理

```C#
public static class AssetBundleTools
{
    private const string AssetBundleScenePath = "/AssetBundle/Scene";
    private const string AssetBundleUIPath = "/AssetBundle/UI";
    private const string AssetBundleUIFileName = "assets";

    public static void CreateAllScene()
    {
        AssetBundleManager.Inst.SetAssetBundlePatch(typeof(CoreMain), AssetBundleScenePath);
        AssetBundleManager.Inst.LoadScenesAndNoCache();
    }

    public static T LoadUI<T>(this string path) where T : MonoBehaviour
    {
        AssetBundleManager.Inst.SetAssetBundlePatch(typeof(CoreMain), AssetBundleUIPath);
        return AssetBundleManager.Inst.LoadUI<T>(AssetBundleUIFileName, path);
    }

    public static T LoadUI<T>(this string path, Transform parent) where T : MonoBehaviour
    {
        AssetBundleManager.Inst.SetAssetBundlePatch(typeof(CoreMain), AssetBundleUIPath);
        return AssetBundleManager.Inst.LoadUI<T>(AssetBundleUIFileName, path, parent);
    }
}
```

- 基于特定的资源存放路径，可以对资源加载进行额外的增强处理，简化参数
- 同时将资源路径设定也包含在资源调用方法中，确保每次资源加载的路径不会出错