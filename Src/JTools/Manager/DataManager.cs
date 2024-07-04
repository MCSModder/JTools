using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using KBEngine;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Map;
using TierneyJohn.MiChangSheng.JTools.Util;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

/// <summary>
/// 数据加载管理器
/// </summary>
public class DataManager : MonoBehaviour
{
    #region 字段/属性

    public static DataManager Inst;

    public event Action OnDataInitialized;

    public event Action OnDataLoaded;

    public event Action OnDataComplete;

    public event Action OnAvatarLoaded;

    private jsonData Instance
    {
        get => jsonData.instance;
    }

    private bool _onLoading;

    #endregion

    #region Unity 事件函数

    private void Awake() { Inst = this; }

    private void Start() { OnDataInitialized?.Invoke(); }

    #endregion

    #region 公开方法

    /// <summary>
    /// 加载 Data 数据文件
    /// </summary>
    /// <param name="mainClass">主函数 Type</param>
    /// <param name="path">数据存放路径</param>
    public void LoadDataFile(Type mainClass, string path = "Data")
    {
        var dataPath = $"{Directory.GetParent(mainClass.Assembly.Location)?.FullName}/{path}";
        foreach (var file in new DirectoryInfo(dataPath).GetFiles()) LoadFile(file, new BinaryFormatter());
    }

    /// <summary>
    /// 加载 Data 数据文件
    /// </summary>
    /// <param name="path">数据存放路径</param>
    public void LoadDataFile(string path)
    {
        foreach (var file in new DirectoryInfo(path).GetFiles()) LoadFile(file, new BinaryFormatter());
    }

    /// <summary>
    /// 异步加载 Data 数据文件
    /// </summary>
    /// <param name="mainClass">主函数 Type</param>
    /// <param name="path">数据存放路径</param>
    public void LoadDataFileAsync(Type mainClass, string path = "Data")
    {
        var dataPath = $"{Directory.GetParent(mainClass.Assembly.Location)?.FullName}/{path}";

        try
        {
            StartCoroutine(AsyncLoadFiles(dataPath));
        }
        catch (System.Exception e)
        {
            e.Error();
            _onLoading = false;
        }
    }

    /// <summary>
    /// 异步加载 Data 数据文件
    /// </summary>
    /// <param name="path">数据存放路径</param>
    public void LoadDataFileAsync(string path)
    {
        try
        {
            StartCoroutine(AsyncLoadFiles(path));
        }
        catch (System.Exception e)
        {
            e.Error();
            _onLoading = false;
        }
    }

    public void LoadData()
    {
        OnDataLoaded?.Invoke();

        while (_onLoading) { }

        "==================== JTools DataManager 数据加载开始 ====================".Log();
        LoadAffixData();
        LoadBackpackData();
        LoadBiographyData();
        LoadBuffData();
        LoadElixirFormulaData();
        LoadItemData();
        LoadNpcActionData();
        LoadNpcBindData();
        LoadNpcImportantData();
        LoadNpcLiuPaiData();
        LoadNpcSpawnData();
        LoadNpcTaoData();
        LoadNpcTitleData();
        LoadSceneNameData();
        LoadSeidData();
        LoadSkillData();
        LoadStaticSkillData();
        LoadTaskData();
        LoadTianJiDaBiData();
        LoadTianJiDaBiRewardData();
        "==================== JTools DataManager 数据加载完成 ====================".Log();

        OnDataComplete?.Invoke();
    }

    public void LoadAvatar()
    {
        OnAvatarLoaded?.Invoke();
        LoadNpcAvatarData();
    }

    #endregion

    #region 私有方法

    private IEnumerator AsyncLoadFiles(string path)
    {
        while (_onLoading) yield return null;

        _onLoading = true;

        foreach (var file in new DirectoryInfo(path).GetFiles())
        {
            LoadFile(file, new BinaryFormatter());
            yield return null;
        }

        _onLoading = false;
    }

    private void LoadFile(FileInfo file, BinaryFormatter binaryFormatter)
    {
        switch (file.Name)
        {
            case AffixData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<AffixEntity> affixData)
                {
                    affixEntities.AddRange(affixData);
                }

                break;

            case BackpackData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<BackpackEntity> backpackData)
                {
                    backpackEntities.AddRange(backpackData);
                }

                break;

            case BiographyData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<BiographyEntity> biographyData)
                {
                    biographyEntities.AddRange(biographyData);
                }

                break;

            case BuffData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<BuffEntity> buffData)
                {
                    buffEntities.AddRange(buffData);
                }

                break;

            case ElixirFormulaData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<ElixirFormulaEntity> elixirFormulaData)
                {
                    elixirFormulaEntities.AddRange(elixirFormulaData);
                }

                break;

            case GameplayData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<GameplayEntity> gameplayData)
                {
                    gameplayEntities.AddRange(gameplayData);
                }

                break;

            case ItemData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<ItemEntity> itemData)
                {
                    itemEntities.AddRange(itemData);
                }

                break;

            case MapInfoData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is Dictionary<string, MapInfo> mapInfoData)
                {
                    foreach (var item in mapInfoData)
                    {
                        MapInfos.TryAdd(item.Key, item.Value);
                    }
                }

                break;

            case NpcActionData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcActionEntity> npcActionData)
                {
                    npcActionEntities.AddRange(npcActionData);
                }

                break;

            case NpcAvatarData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcAvatarEntity> npcAvatarData)
                {
                    npcAvatarEntities.AddRange(npcAvatarData);
                }

                break;

            case NpcBindData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcBindEntity> npcBindData)
                {
                    npcBindEntities.AddRange(npcBindData);
                }

                break;

            case NpcImportantData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcImportantEntity> npcImportantData)
                {
                    npcImportantEntities.AddRange(npcImportantData);
                }

                break;

            case NpcLiuPaiData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcLiuPaiEntity> npcLiuPaiData)
                {
                    npcLiuPaiEntities.AddRange(npcLiuPaiData);
                }

                break;

            case NpcSpawnData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcSpawnEntity> npcSpawnData)
                {
                    npcSpawnEntities.AddRange(npcSpawnData);
                }

                break;

            case NpcTaoData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcTaoEntity> npcTaoData)
                {
                    npcTaoEntities.AddRange(npcTaoData);
                }

                break;

            case NpcTitleData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<NpcTitleEntity> npcTitleData)
                {
                    npcTitleEntities.AddRange(npcTitleData);
                }

                break;

            case SceneNameData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<SceneNameEntity> sceneNameData)
                {
                    sceneNameEntities.AddRange(sceneNameData);
                }

                break;

            case SeidData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is SeidEntity seidData)
                {
                    foreach (var item in seidData.BuffSeidDictionary)
                    {
                        if (!seidEntity.BuffSeidDictionary.ContainsKey(item.Key))
                        {
                            seidEntity.BuffSeidDictionary[item.Key] = [];
                        }

                        seidEntity.BuffSeidDictionary[item.Key].AddRange(item.Value);
                    }

                    foreach (var item in seidData.EquipSeidDictionary)
                    {
                        if (!seidEntity.EquipSeidDictionary.ContainsKey(item.Key))
                        {
                            seidEntity.EquipSeidDictionary[item.Key] = [];
                        }

                        seidEntity.EquipSeidDictionary[item.Key].AddRange(item.Value);
                    }

                    foreach (var item in seidData.ItemSeidDictionary)
                    {
                        if (!seidEntity.ItemSeidDictionary.ContainsKey(item.Key))
                        {
                            seidEntity.ItemSeidDictionary[item.Key] = [];
                        }

                        seidEntity.ItemSeidDictionary[item.Key].AddRange(item.Value);
                    }

                    foreach (var item in seidData.SkillSeidDictionary)
                    {
                        if (!seidEntity.SkillSeidDictionary.ContainsKey(item.Key))
                        {
                            seidEntity.SkillSeidDictionary[item.Key] = [];
                        }

                        seidEntity.SkillSeidDictionary[item.Key].AddRange(item.Value);
                    }

                    foreach (var item in seidData.StaticSkillSeidDictionary)
                    {
                        if (!seidEntity.StaticSkillSeidDictionary.ContainsKey(item.Key))
                        {
                            seidEntity.StaticSkillSeidDictionary[item.Key] = [];
                        }

                        seidEntity.StaticSkillSeidDictionary[item.Key].AddRange(item.Value);
                    }
                }

                break;

            case SkillData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<SkillEntity> skillData)
                {
                    skillEntities.AddRange(skillData);
                }

                break;

            case StaticSkillData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<StaticSkillEntity> staticSkillData)
                {
                    staticSkillEntities.AddRange(staticSkillData);
                }

                break;

            case TaskData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<TaskEntity> taskData)
                {
                    taskEntities.AddRange(taskData);
                }

                break;

            case TianJiDaBiData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<TianJiDaBiEntity> tianJiDaBiData)
                {
                    tianJiDaBiEntities.AddRange(tianJiDaBiData);
                }

                break;

            case TianJiDaBiRewardData:
                if (binaryFormatter.Deserialize(file.OpenRead()) is List<TianJiDaBiRewardEntity> tianJiDaBiRewardData)
                {
                    tianJiDaBiRewardEntities.AddRange(tianJiDaBiRewardData);
                }

                break;

            default:
                file.DataLoadError();
                return;
        }
    }

    private void LoadAffixData()
    {
        if (affixEntities == null || !affixEntities.Any()) return;
        "词缀".DataLoadStart();

        foreach (var affix in affixEntities)
        {
            if (Instance.TuJianChunWenBen.HasField(affix.Id.ToString())) "词缀".DataLoadWarn(affix.Id);
            Instance.TuJianChunWenBen[affix.Id.ToString()] = affix.ToJsonObject();
        }

        "词缀".DataLoadComplete();
    }

    private void LoadBackpackData()
    {
        if (backpackEntities == null || !backpackEntities.Any()) return;
        "背包".DataLoadStart();

        foreach (var backpack in backpackEntities)
        {
            if (Instance.BackpackJsonData.HasField(backpack.Id.ToString())) "背包".DataLoadWarn(backpack.Id);
            Instance.BackpackJsonData[backpack.Id.ToString()] = backpack.ToJsonObject();
        }

        "背包".DataLoadComplete();
    }

    private void LoadBiographyData()
    {
        if (biographyEntities == null || !biographyEntities.Any()) return;
        "生平".DataLoadStart();

        foreach (var biography in biographyEntities)
        {
            if (Instance.ShengPing.HasField(biography.Id)) "生平".DataLoadWarn(biography.Id);
            Instance.ShengPing[biography.Id] = biography.ToJsonObject();
        }

        "生平".DataLoadComplete();
    }

    private void LoadBuffData()
    {
        if (buffEntities == null || !buffEntities.Any()) return;
        "Buff".DataLoadStart();

        foreach (var buff in buffEntities)
        {
            if (Instance.BuffJsonData.ContainsKey(buff.Id.ToString())) "Buff".DataLoadWarn(buff.Id);
            Instance.BuffJsonData[buff.Id.ToString()] = buff.ToJsonObject();
            Instance._BuffJsonData[buff.Id.ToString()] = buff.ToJsonObject();
            Instance.Buff[buff.Id] = new Buff(buff.Id);
        }

        "Buff".DataLoadComplete();
    }

    private void LoadElixirFormulaData()
    {
        if (elixirFormulaEntities == null || !elixirFormulaEntities.Any()) return;
        "丹方".DataLoadStart();

        foreach (var elixirFormula in elixirFormulaEntities)
        {
            if (Instance.LianDanDanFangBiao.HasField(elixirFormula.Id.ToString())) "丹方".DataLoadWarn(elixirFormula.Id);
            Instance.LianDanDanFangBiao[elixirFormula.Id.ToString()] = elixirFormula.ToJsonObject();
        }

        "丹方".DataLoadComplete();
    }

    private void LoadItemData()
    {
        if (itemEntities == null || !itemEntities.Any()) return;
        "物品".DataLoadStart();

        foreach (var item in itemEntities)
        {
            if (Instance.ItemJsonData.ContainsKey(item.Id.ToString())) "物品".DataLoadWarn(item.Id);
            Instance.ItemJsonData[item.Id.ToString()] = item.ToJsonObject();
            Instance._ItemJsonData[item.Id.ToString()] = item.ToJsonObject();
        }

        "物品".DataLoadComplete();
    }

    private void LoadNpcActionData()
    {
        if (npcActionEntities == null || !npcActionEntities.Any()) return;
        "NPC 行为".DataLoadStart();

        foreach (var action in npcActionEntities)
        {
            if (Instance.NPCActionDate.HasField(action.Id.ToString())) "NPC 行为".DataLoadWarn(action.Id);
            Instance.NPCActionDate[action.Id.ToString()] = action.ToJsonObject();
        }

        "NPC 行为".DataLoadComplete();
    }

    private void LoadNpcAvatarData()
    {
        if (npcAvatarEntities == null || !npcAvatarEntities.Any()) return;
        "==================== JTools 立绘数据加载开始 ====================".Log();

        foreach (var npcAvatar in npcAvatarEntities)
        {
            if (Instance.AvatarJsonData.HasField(npcAvatar.Id.ToString())) "NPC 立绘".DataLoadWarn(npcAvatar.Id);
            Instance.AvatarJsonData[npcAvatar.Id.ToString()] = npcAvatar.ToJsonObject();
        }

        "==================== JTools 立绘数据加载完成 ====================".Log();
    }

    private void LoadNpcBindData()
    {
        if (npcBindEntities == null || !npcBindEntities.Any()) return;
        "NPC 绑定".DataLoadStart();

        foreach (var npcBind in npcBindEntities)
        {
            if (Instance.WuJiangBangDing.HasField(npcBind.Id.ToString())) "NPC 绑定".DataLoadWarn(npcBind.Id);
            Instance.WuJiangBangDing[npcBind.Id.ToString()] = npcBind.ToJsonObject();
        }

        "NPC 绑定".DataLoadComplete();
    }

    private void LoadNpcImportantData()
    {
        if (npcImportantEntities == null || !npcImportantEntities.Any()) return;
        "NPC 实例".DataLoadStart();

        foreach (var npcImportant in npcImportantEntities)
        {
            if (Instance.NPCImportantDate.HasField(npcImportant.Id.ToString())) "NPC 实例".DataLoadWarn(npcImportant.Id);
            Instance.NPCImportantDate[npcImportant.Id.ToString()] = npcImportant.ToJsonObject();
        }

        "NPC 实例".DataLoadComplete();
    }

    private void LoadNpcLiuPaiData()
    {
        if (npcLiuPaiEntities == null || !npcLiuPaiEntities.Any()) return;
        "NPC 流派".DataLoadStart();

        foreach (var npcLiuPai in npcLiuPaiEntities)
        {
            if (Instance.NPCLeiXingDate.HasField(npcLiuPai.Id.ToString())) "NPC 流派".DataLoadWarn(npcLiuPai.Id);
            Instance.NPCLeiXingDate[npcLiuPai.Id.ToString()] = npcLiuPai.ToJsonObject();
        }

        "NPC 流派".DataLoadComplete();
    }

    private void LoadNpcSpawnData()
    {
        if (npcSpawnEntities == null || !npcSpawnEntities.Any()) return;
        "NPC 生成".DataLoadStart();

        foreach (var npcSpawn in npcSpawnEntities)
        {
            if (Instance.NPCChuShiHuaDate.HasField(npcSpawn.Id.ToString())) "NPC 生成".DataLoadWarn(npcSpawn.Id);
            Instance.NPCChuShiHuaDate[npcSpawn.Id.ToString()] = npcSpawn.ToJsonObject();
        }

        "NPC 生成".DataLoadComplete();
    }

    private void LoadNpcTaoData()
    {
        if (npcTaoEntities == null || !npcTaoEntities.Any()) return;
        "NPC 悟道".DataLoadStart();

        foreach (var npcTao in npcTaoEntities)
        {
            if (Instance.NPCWuDaoJson.HasField(npcTao.Id.ToString())) "NPC 悟道".DataLoadWarn(npcTao.Id);
            Instance.NPCWuDaoJson[npcTao.Id.ToString()] = npcTao.ToJsonObject();
        }

        "NPC 悟道".DataLoadComplete();
    }

    private void LoadNpcTitleData()
    {
        if (npcTitleEntities == null || !npcTitleEntities.Any()) return;
        "NPC 称号".DataLoadStart();

        foreach (var npcTitle in npcTitleEntities)
        {
            if (Instance.NPCChengHaoData.HasField(npcTitle.Id.ToString())) "NPC 称号".DataLoadWarn(npcTitle.Id);
            Instance.NPCChengHaoData[npcTitle.Id.ToString()] = npcTitle.ToJsonObject();
        }

        "NPC 称号".DataLoadComplete();
    }

    private void LoadSceneNameData()
    {
        if (sceneNameEntities == null || !sceneNameEntities.Any()) return;
        "场景名称".DataLoadStart();

        foreach (var sceneName in sceneNameEntities)
        {
            if (Instance.SceneNameJsonData.HasField(sceneName.Id)) "场景名称".DataLoadWarn(sceneName.Id);
            Instance.SceneNameJsonData[sceneName.Id] = sceneName.ToJsonObject();
        }

        "场景名称".DataLoadComplete();
    }

    private void LoadSeidData()
    {
        if (seidEntity == null) return;
        "Seid".DataLoadStart();

        foreach (var buffSeid in seidEntity.BuffSeidDictionary)
        {
            foreach (var seid in buffSeid.Value)
            {
                if (Instance.BuffSeidJsonData[buffSeid.Key].HasField(seid.Id.ToString()))
                    "Buff Seid".DataLoadWarn(seid.Id);

                Instance.BuffSeidJsonData[buffSeid.Key][seid.Id.ToString()] = seid.ToJsonObject();
            }
        }

        foreach (var equipSeid in seidEntity.EquipSeidDictionary)
        {
            foreach (var seid in equipSeid.Value)
            {
                if (Instance.EquipSeidJsonData[equipSeid.Key].HasField(seid.Id.ToString()))
                    "Equip Seid".DataLoadWarn(seid.Id);

                Instance.EquipSeidJsonData[equipSeid.Key][seid.Id.ToString()] = seid.ToJsonObject();
            }
        }

        foreach (var itemSeid in seidEntity.ItemSeidDictionary)
        {
            foreach (var seid in itemSeid.Value)
            {
                if (Instance.ItemsSeidJsonData[itemSeid.Key].HasField(seid.Id.ToString()))
                    "Item Seid".DataLoadWarn(seid.Id);

                Instance.ItemsSeidJsonData[itemSeid.Key][seid.Id.ToString()] = seid.ToJsonObject();
            }
        }

        foreach (var skillSeid in seidEntity.SkillSeidDictionary)
        {
            foreach (var seid in skillSeid.Value)
            {
                if (Instance.SkillSeidJsonData[skillSeid.Key].HasField(seid.Id.ToString()))
                    "Skill Seid".DataLoadWarn(seid.Id);

                Instance.SkillSeidJsonData[skillSeid.Key][seid.Id.ToString()] = seid.ToJsonObject();
            }
        }

        foreach (var staticSkillSeid in seidEntity.StaticSkillSeidDictionary)
        {
            foreach (var seid in staticSkillSeid.Value)
            {
                if (Instance.StaticSkillSeidJsonData[staticSkillSeid.Key].HasField(seid.Id.ToString()))
                    "StaticSkill Seid".DataLoadWarn(seid.Id);

                Instance.StaticSkillSeidJsonData[staticSkillSeid.Key][seid.Id.ToString()] = seid.ToJsonObject();
            }
        }

        "Seid".DataLoadComplete();
    }

    private void LoadSkillData()
    {
        if (skillEntities == null || !skillEntities.Any()) return;
        "神通".DataLoadStart();

        foreach (var skill in skillEntities)
        {
            if (Instance.skillJsonData.ContainsKey(skill.Id.ToString())) "神通".DataLoadWarn(skill.Id);
            Instance.skillJsonData[skill.Id.ToString()] = skill.ToJsonObject();
            Instance._skillJsonData[skill.Id.ToString()] = skill.ToJsonObject();
        }

        "神通".DataLoadComplete();
    }

    private void LoadStaticSkillData()
    {
        if (staticSkillEntities == null || !staticSkillEntities.Any()) return;
        "功法".DataLoadStart();

        foreach (var staticSkill in staticSkillEntities)
        {
            if (Instance.StaticSkillJsonData.HasField(staticSkill.Id.ToString())) "功法".DataLoadWarn(staticSkill.Id);
            Instance.StaticSkillJsonData[staticSkill.Id.ToString()] = staticSkill.ToJsonObject();
        }

        "功法".DataLoadComplete();
    }

    private void LoadTaskData()
    {
        if (taskEntities == null || !taskEntities.Any()) return;
        "任务".DataLoadStart();

        foreach (var task in taskEntities)
        {
            if (Instance.TaskJsonData.HasField(task.Id.ToString())) "任务".DataLoadWarn(task.Id);
            Instance.TaskJsonData[task.Id.ToString()] = task.ToJsonObject();

            foreach (var taskInfo in task.TaskInfos)
            {
                if (Instance.TaskInfoJsonData.HasField(taskInfo.Id.ToString())) "子任务".DataLoadWarn(taskInfo.Id);
                Instance.TaskInfoJsonData[taskInfo.Id.ToString()] = taskInfo.ToJsonObject();
            }
        }

        "任务".DataLoadComplete();
    }

    private void LoadTianJiDaBiData()
    {
        if (tianJiDaBiEntities == null || !tianJiDaBiEntities.Any()) return;
        "天机大比".DataLoadStart();

        foreach (var tianJiDaBi in tianJiDaBiEntities)
        {
            if (Instance.TianJiDaBi.HasField(tianJiDaBi.Id.ToString())) "天机大比".DataLoadWarn(tianJiDaBi.Id);
            Instance.TianJiDaBi[tianJiDaBi.Id.ToString()] = tianJiDaBi.ToJsonObject();
        }

        "天机大比".DataLoadComplete();
    }

    private void LoadTianJiDaBiRewardData()
    {
        if (tianJiDaBiRewardEntities == null || !tianJiDaBiRewardEntities.Any()) return;
        "天机大比奖励".DataLoadStart();

        foreach (var tianJiDaBiReward in tianJiDaBiRewardEntities)
        {
            if (Instance.TianJiDaBiReward.HasField(tianJiDaBiReward.Id.ToString()))
                "天机大比奖励".DataLoadWarn(tianJiDaBiReward.Id);

            Instance.TianJiDaBiReward[tianJiDaBiReward.Id.ToString()] = tianJiDaBiReward.ToJsonObject();
        }

        "天机大比奖励".DataLoadComplete();
    }

    #endregion

    #region 数据文件名称

    public const string AffixData = "Affix.dat";
    public const string BackpackData = "Backpack.dat";
    public const string BiographyData = "Biography.dat";
    public const string BuffData = "Buff.dat";
    public const string ElixirFormulaData = "ElixirFormula.dat";
    public const string GameplayData = "Gameplay.dat";
    public const string ItemData = "Item.dat";
    public const string MapInfoData = "MapInfo.dat";
    public const string NpcActionData = "NpcAction.dat";
    public const string NpcAvatarData = "NpcAvatar.dat";
    public const string NpcBindData = "NpcBind.dat";
    public const string NpcImportantData = "NpcImportant.dat";
    public const string NpcLiuPaiData = "NpcLiuPai.dat";
    public const string NpcSpawnData = "NpcSpawn.dat";
    public const string NpcTaoData = "NpcTao.dat";
    public const string NpcTitleData = "NpcTitle.dat";
    public const string SceneNameData = "SceneName.dat";
    public const string SeidData = "Seid.dat";
    public const string SkillData = "Skill.dat";
    public const string StaticSkillData = "StaticSkill.dat";
    public const string TaskData = "Task.dat";
    public const string TianJiDaBiData = "TianJiDaBi.dat";
    public const string TianJiDaBiRewardData = "TianJiDaBiReward.dat";

    #endregion

    #region 数据集

    public List<AffixEntity> affixEntities = [];
    public List<BackpackEntity> backpackEntities = [];
    public List<BiographyEntity> biographyEntities = [];
    public List<BuffEntity> buffEntities = [];
    public List<ElixirFormulaEntity> elixirFormulaEntities = [];
    public List<GameplayEntity> gameplayEntities = [];
    public List<ItemEntity> itemEntities = [];
    public readonly Dictionary<string, MapInfo> MapInfos = [];
    public List<NpcActionEntity> npcActionEntities = [];
    public List<NpcAvatarEntity> npcAvatarEntities = [];
    public List<NpcBindEntity> npcBindEntities = [];
    public List<NpcImportantEntity> npcImportantEntities = [];
    public List<NpcLiuPaiEntity> npcLiuPaiEntities = [];
    public List<NpcSpawnEntity> npcSpawnEntities = [];
    public List<NpcTaoEntity> npcTaoEntities = [];
    public List<NpcTitleEntity> npcTitleEntities = [];
    public List<SceneNameEntity> sceneNameEntities = [];
    public SeidEntity seidEntity = new();
    public List<SkillEntity> skillEntities = [];
    public List<StaticSkillEntity> staticSkillEntities = [];
    public List<TaskEntity> taskEntities = [];
    public List<TianJiDaBiEntity> tianJiDaBiEntities = [];
    public List<TianJiDaBiRewardEntity> tianJiDaBiRewardEntities = [];

    #endregion
}