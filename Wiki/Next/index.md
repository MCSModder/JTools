# Next 指令扩展

## 简介

提供了一系列特殊功能的指令扩展,这里就不额外介绍 Next 指令的使用方式了。

另外为了显示更加清晰,会将相似功能的指令整合到一起,而不再根据 Event 和 Env 进行区分,使用时请注意指令类别。

## 指令列表

- [AssetBundle 相关指令](#assetbundle-相关指令)
- [CG 相关指令](#cg-相关指令)
- [Fight 相关指令](#fight-相关指令)
- [Log 相关指令](#log-相关指令)
- [MapEvent 相关指令](#mapevent-相关指令)
- [Mod 相关指令](#mod-相关指令)
- [Scene 相关指令](#scene-相关指令)
- [Spine 相关指令](#spine-相关指令)
- [Task 相关指令](#task-相关指令)

### AssetBundle 相关指令

> AssetBundle 相关的 Next 指令，仅为推荐作为临时测试时使用<br/>
> 受限于 Next 的运行模式，许多功能都为阉割版本，完整功能请参考 [AB资源管理器]()

| 指令类型        | 指令名称                                       | 参数列表                      | 指令描述                                                                                                        |
|-------------|--------------------------------------------|---------------------------|-------------------------------------------------------------------------------------------------------------|
| DialogEvent | JT_SetAssetBundlePatch<br/>JT_设置AB加载路径     | path (string) 文件存放路径      | 设置AB包资源的加载路径<br/>因为JTools需要同时对多个Mod提供AB资源管理的支持,因此加载路径可能会受其他mod影响发生变动。<br/>建议在每次AB资源加载前,都手动指定一次加载路径          |
| DialogEvent | JT_LoadAssetBundle<br/>JT_加载AB资源           | fileName (string) AB资源文件名 | 加载指定路径下的一个AB包资源<br/>该方法的原始版本会返回一个AssetBundle数据,但是受限于Next指令的运行模式,所以这里不再返回数据，仅作数据加载用                          |
| DialogEvent | JT_LoadAvatarSpine<br/>JT_加载所有角色立绘资源       |                           | 加载指定路径下的所有Spine立绘资源<br/>所有的立绘数据会缓存到 SpineManager 之中,相关功能使用可参考[Spine 动态立绘管理器](../Spine/index.md)             |
| DialogEvent | JT_LoadScenesAndNoCache<br/> JT_加载所有场景AB资源 |                           | 加载指定路径下的所有场景资源 (包括场景类动态CG资源)<br/>因为场景类资源只需要加载到内存中即可随时访问了，并且仅在场景使用时才会占用资源，故此没有必要针对该类资源做加载优化处理，建议游戏加载时期进行统一加载 |
| DialogEvent | JT_DestroyAssetBundle<br/>JT_释放AB资源        | fileName (string) AB资源文件名 | 卸载并释放指定名称的AB包资源<br/>仅针对常规资源类AB资源，场景类资源无法通过该方法进行资源释放                                                         |
| DialogEvent | JT_ClearAllAssetBundles<br/>JT_清空所有缓存AB资源  |                           | 清空并释放所有缓存的AB包资源<br/> 仅针对常规资源类AB资源，场景类资源无法通过该方法进行资源释放                                                        |

### CG 相关指令

> CG 相关的 Next 指令中，静态CG处理方法为阉割版本，完整功能请参考 [CG管理器]()

| 指令类型        | 指令名称                          | 参数列表                                                                 | 指令描述                                                                                            |
|-------------|-------------------------------|----------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| DialogEvent | JT_ShowCg<br/>JT_显示静态Cg       | cg (string) cg名称                                                     | 显示静态CG背景<br/>其中cg资源如果存放在合适的路径，仅提供名称即可，否则请使用完整资源路径名称或直接提供Sprite方式进行CG处理                          |
| DialogEvent | JT_HideCg<br/>JT_隐藏静态Cg       |                                                                      | 隐藏静态CG背景                                                                                        |
| DialogEvent | JT_ShowSpineCg<br/> JT_显示动态Cg | spineName (string) spine所在场景名称<br/>skinName (string) spine皮肤名称(可不提供) | 加载动态Spine类型CG背景<br/>当前通过独立场景来处理动态CG,后续将提供独立处理的方式。<br/>另外，若加载动态CG时，已经在显示静态CG，会自动隐藏静态CG界面，使用时还请注意 |
| DialogEvent | JT_HideSpineCg<br/>JT_隐藏动态Cg  |                                                                      | 隐藏动态CG背景                                                                                        |

### Fight 相关指令

> Fight 相关的 Next 指令中,对于神通释放部分为阉割版本，完整功能请参考 [战斗相关工具]()

| 指令类型        | 指令名称                                | 参数列表                                            | 返回数据                                     | 指令描述                                                                        |
|-------------|-------------------------------------|-------------------------------------------------|------------------------------------------|-----------------------------------------------------------------------------|
| DialogEvent | JT_FightAddSkill<br/>JT_添加战斗面板神通    | skillId (int) 神通唯一编号                            |                                          | 角色战斗面板上添加一个指定神通<br/>若战斗面板已经放满神通，则不会有任何变化                                    |
| DialogEvent | JT_FightClearSkill<br/>JT_移除战斗面板神通  | skillId (int) 神通唯一编号                            |                                          | 角色战斗面板上移除一个指定神通<br/>若战斗面板上已没有神通，则不会有任何变化                                    |
| DialogEvent | JT_FightChangeSkill<br/>JT_替换战斗面板神通 | skillId (int) 神通唯一编号<br/>toSkillId (int) 神通唯一编号 |                                          | 将角色战斗面板上的一个指定神通替换为另一个指定神通<br/>若需要移除的神通不存在，则只会执行添加操作<br/>若需要添加的神通不存在，则只会移除操作 |
| DialogEnv   | JT_GetFightResult<br/>JT_获取战斗结果     |                                                 | 战斗结果<br/>(1: 常规 2: 战斗胜利 3: 战斗失败 4: 战斗逃跑) | 获取上次战斗的战斗结果<br/>只要没有开启新的战斗，也没有重启游戏，就都可以获取到                                  |

### Log 相关指令

> Log 相关的 Next 指令,该功能通过 JTools_Editor 编辑器来处理会更加方便

| 指令类型        | 指令名称                              | 指令描述          |
|-------------|-----------------------------------|---------------|
| DialogEvent | JT_SettingLogConfig<br/>JT_修改日志配置 | 快捷修改当前日志输入模式  |
| DialogEvent | JT_ExportLog<br/>JT_导出日志          | 快捷导出并打开日志文件   |
| DialogEvent | JT_ExportData<br/> JT_导出存档数据      | 快捷导出附带日志的存档文件 |

### MapEvent 相关指令

> MapEvent 相关的 Next 指令中,对于地图事件的添加操作为阉割版本，完整功能请参考 [地图事件管理器]()

| 指令类型        | 指令名称                              | 参数列表                                                                     | 返回数据                           | 指令描述                                                                           |
|-------------|-----------------------------------|--------------------------------------------------------------------------|--------------------------------|--------------------------------------------------------------------------------|
| DialogEvent | JT_ActiveMapEvent<br/>JT_激活地图事件   | eventId (int) 事件编号<br/> eventType (int) 事件类型<br/> nodeIndex (int) 事件触发节点 |                                | 在大地图上添加并激活一个地图事件<br/>若事件触发节点为0，则会在地图上随机地点触发事件                                  |
| DialogEvent | JT_RefreshMapEvent<br/>JT_刷新大地图事件 |                                                                          |                                | 刷新大地图上的所有事件数据<br/>用于地图事件没有即时生效或出现问题的情况的额外处理                                    |
| DialogEnv   | JT_CheckMapEvent<br/>JT_验证地图事件    | eventId (int) 事件编号<br/> eventType (int) 事件类型                             | 验证结果<br/>(true: 存在 false: 不存在) | 验证指定大地图事件是否已经存在<br/>该方法仅用于事件数据检测，但是受限于原版大地图事件的实现模式，有些地图事件哪怕存在，在不满足条件时也不会显示在地图上 |

### Mod 相关指令

> Mod 相关的 Next 指令中，对于 Mod 数据获取的操作为阉割版本，完整功能请参考 [模组相关工具]()

| 指令类型      | 指令名称                               | 参数列表                     | 返回数据                           | 指令描述                                                                                                |
|-----------|------------------------------------|--------------------------|--------------------------------|-----------------------------------------------------------------------------------------------------|
| DialogEnv | JT_CheckModActive<br/>JT_检测Mod是否启用 | steamId (string) Mod工坊编号 | 验证结果<br/>(true: 存在 false: 不存在) | 验证指定 Mod 是否启用<br/>已针对 Mod 订阅情况及启用情况做了处理<br/>因为编号位数原因，参数类型选用string类型                                 |
| DialogEnv | JT_GetModName<br/>JT_获取Mod名称       | steamId (string) Mod工坊编号 | Mod名称 (string)                 | 获取指定 Mod 的工坊名称<br/>已针对 Mod 订阅情况及启用情况做了处理<br/>因为编号位数原因，参数类型选用string类型                                |
| DialogEnv | JT_GetModPath<br/>JT_获取Mod路径       | steamId (string) Mod工坊编号 | Mod工坊路径 (string)               | 获取指定 Mod 的工坊路径<br/>不会验证该 Mod 是否订阅及启用，仅返回相应的路径名称<br/>路径层级 workshop/content/1189490/%StemId%/plugins/ |

### Scene 相关指令

> Scene 相关的 Next 指令仅为原版指令的增强处理，并额外提供了两个便捷指令<br/>
> 该功能可通过 JTools_Editor 编辑器来处理会更加方便

| 指令类型        | 指令名称                     | 参数列表                      | 指令描述                                                                                            |
|-------------|--------------------------|---------------------------|-------------------------------------------------------------------------------------------------|
| DialogEvent | JT_LoadScene<br/>JT_加载场景 | sceneName (string) 场景名称   | 跳转并加载指定场景<br/>与原版场景加载相似，但是对加载配置做了调整                                                             |
| DialogEvent | JT_LoadGame<br/>JT_加载游戏  | sceneName (string) 游戏场景名称 | 跳转并加载指定游戏场景<br/>与原版场景加载相似，但是不附带 UI 显示，同时也对加载配置做了调整<br/>仅适用于一些特定的游戏场景使用，其他时间使用 JT_LoadScene 指令即可 |
| DialogEvent | JT_LoadMap<br/> JT_返回宁州  |                           | 跳转到宁州大地图的简化指令                                                                                   |
| DialogEvent | JT_LoadMenu<br/>JT_返回主界面 |                           | 跳转到主界面的简化指令                                                                                     |

### Spine 相关指令

> Spine 相关的 Next 指令中,对于 Spine 数据加载及相关处理的功能无法通过 Next
> 指令实现，完整功能请参考 [Spine动态立绘管理器](../Spine/index.md)

| 指令类型        | 指令名称                                 | 参数列表                                | 返回数据                           | 指令描述                                 |
|-------------|--------------------------------------|-------------------------------------|--------------------------------|--------------------------------------|
| DialogEnv   | JT_CheckSpine<br/>JT_验证Spine数据       | id (int) 角色编号                       | 验证结果<br/>(true: 存在 false: 不存在) | 验证是否存在对应的Spine数据                     |
| DialogEnv   | JT_GetSpineSkin<br/>JT_获取当前Spine数据皮肤 | id (int) 角色编号                       | 皮肤名称 (string)                  | 获取特定Spine立绘的当前皮肤<br/>若立绘数据不存在则返回null |
| DialogEvent | JT_ChangeSpineSkin<br/>JT_变更立绘皮肤     | id (int) 角色编号<br/>skin (string)角色名称 |                                | 变更特定Spine立绘的当前皮肤                     |

### Task 相关指令

> Task 相关的 Next 指令为早期版本代码，完整功能请参考 [任务相关工具]()

| 指令类型        | 指令名称                                   | 参数列表                                          | 返回数据                           | 指令描述               |
|-------------|----------------------------------------|-----------------------------------------------|--------------------------------|--------------------|
| DialogEvent | JT_AddTask<br/>JT_添加任务                 | taskId (int) 任务编号                             |                                | 角色添加指定编号的任务        |
| DialogEvent | JT_NextTask<br/>JT_任务跳转阶段              | taskId (int) 任务编号                             |                                | 将角色指定编号的任务跳转到下一阶段  |
| DialogEvent | JT_SetTaskIndex<br/>JT_任务跳转特定阶段        | taskId (int) 任务编号<br/> taskIndex (int) 任务阶段索引 |                                | 将角色指定编号的任务跳转到指定索引项 |
| DialogEvent | JT_SetTaskCompleted<br/>JT_任务完成        | taskId (int) 任务编号                             |                                | 将角色指定编号的任务结束       |
| DialogEnv   | JT_HasTask<br/>JT_验证任务是否存在             | taskId (int) 任务编号                             | 验证结果<br/>(true: 存在 false: 不存在) | 验证角色是否存在指定编号的任务    |
| DialogEnv   | JT_GetTaskData<br/>JT_获取任务数据           | taskId (int) 任务编号                             | 任务数据 (JSONObject)              | 获取指定编号的任务数据        |
| DialogEnv   | JT_GetTaskIndex<br/>JT_获取当前任务阶段        | taskId (int) 任务编号                             | 任务索引 (int)                     | 获取指定编号任务的当前阶段索引    |
| DialogEnv   | JT_GetTaskFinalIndex<br/>JT_获取任务最终阶段索引 | taskId (int) 任务编号                             | 任务最终阶段索引 (int)                 | 获取指定编号任务的最终阶段索引    |
