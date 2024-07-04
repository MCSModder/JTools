# JTools Wiki

## 简介

JTools 是觅长生游戏的一个 Mod 工具库，提供了一系列的简化开发的工具方法。

另外，几乎所有的管理器都为 **MonoBehaviour** 的子类且使用了单例模式，因此可以随时通过 XXXManager.Inst 来直接访问管理器对象。

同时，管理器组件挂载在 **DontDestroyOnLoad** 层的 **JTools** 对象上，后续除非必要否则不再特殊说明。

## 目录

- [AB资源管理器](AssetBundle/index.md)
- [CG管理器](CG/index.md)
- [剧情编辑器](Fungus.md)
- [日志管理器](Log.md)
- [地图事件管理器](MapEvent.md)
- [Next指令扩展](Next/index.md)
- [额外特性扩展](Seid.md)
- [Spine动态立绘管理器](Spine/index.md)
- [时间标记管理器](TimeFlag)
- [其他实用工具]()