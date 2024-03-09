# JTools Wiki

## 简介

JTools 是觅长生游戏的一个 Mod 工具库，提供了一系列的工具方法。

## 目录

- [Fungus 剧情编辑](#fungus-剧情编辑)
  + [Fungus 剧情编辑-使用方法](#fungus-剧情编辑-使用方法)
  + [Fungus 剧情编辑-案例演示](#fungus-剧情编辑-案例演示)
  + [Fungus 剧情编辑-JCommand列表](#fungus-剧情编辑-jcommand列表)
- [AssetBundle 资源处理](#assetbundle-资源处理)
  + [AssetBundle 资源处理-使用方法](#assetbundle-资源处理-使用方法)
  + [AssetBundle 资源处理-案例演示](#assetbundle-资源处理-案例演示)
- [大地图随机事件](#大地图随机事件)
  + [大地图随机事件-使用方法](#大地图随机事件-使用方法)
  + [大地图随机事件-案例演示](#大地图随机事件-案例演示)
- [额外的 Seid 实现](#额外的-seid-实现)
  + [额外的 Seid 功能列表](#额外的-seid-功能列表)
- [Next 功能扩展](#next-功能扩展)
  + [Next 功能扩展-NextEvent 扩展](#next-功能扩展-nextevent-扩展)
  + [Next 功能扩展-NextEnv 扩展](#next-功能扩展-nextenv-扩展)
  + [Next 功能扩展-Next 编辑器扩展](#next-功能扩展-next-编辑器扩展)
  + [Next 功能扩展-NextMod 便捷工具](#next-功能扩展-nextmod-便捷工具)
- [其他实用工具](#其他实用工具)
  + [数据存读档工具](#数据存读档工具)
  + [Harmony 数据挖掘增强工具](#harmony-数据挖掘增强工具)
  + [JSONObject 数据处理增强工具](#jsonobject-数据处理增强工具)
  + [jsonData 数据载入工具](#jsondata-数据载入工具)
  + [分级 Log 打印工具](#分级-log-打印工具)
  + [更多小工具](#更多小工具)

## Fungus 剧情编辑



### Fungus 剧情编辑-使用方法

1. 首先，JTools封装了一个 **FungusManager** 类，他是专门用来处理 **Fungus** 剧情相关的类，请将它与 **Fungus.FungusManager** 区分开。这个类挂载在 **DontDestroyOnLoad** 层，因此你随时可以在该层级的 **JTools/FungusManager** 访问到它。

2. 要想编写自定义剧情，首先需要有一个剧情主体，也就是一个 **Flowchart** 对象。而 JTools 定义了一个 Flowchart 的子类，用于扩展原有的方法，也即 **JFlowchart** 对象。同时也在 FungusManager 封装了一系列的方法用来操作 JFlowchart 对象。而对于使用者来说，您并不需要考虑太多的处理方法，只需要使用一个高度封装的方法 **FungusManager.Inst.RegisterFlowchart("剧情名字")** 即可获取一个 JFlowchart 对象，同时它也会自动加载到 FungusManager 中进行后续处理。

> FungusManager 采用了单例设计，请务必在调用时使用 FungusManager.Inst

### Fungus 剧情编辑-案例演示

### Fungus 剧情编辑-JCommand列表

## AssetBundle 资源处理

### AssetBundle 资源处理-介绍

### AssetBundle 资源处理-使用方法

### AssetBundle 资源处理-案例演示

## 大地图随机事件

### 大地图随机事件-介绍

### 大地图随机事件-使用方法

### 大地图随机事件-案例演示

## 额外的 Seid 实现

### 额外的 Seid 功能列表

## Next 功能扩展

### Next 功能扩展-介绍

### Next 功能扩展-NextEvent 扩展

### Next 功能扩展-NextEnv 扩展

### Next 功能扩展-Next 编辑器扩展

### Next 功能扩展-NextMod 便捷工具

# 其他实用工具

### 数据存读档工具

### Harmony 数据挖掘增强工具

### JSONObject 数据处理增强工具

### jsonData 数据载入工具

### 分级 Log 打印工具

### 更多小工具