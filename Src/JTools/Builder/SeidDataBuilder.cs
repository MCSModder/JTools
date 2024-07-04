using System;
using System.Collections.Generic;
using System.IO;
using TierneyJohn.MiChangSheng.JTools.Manager;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;
using TierneyJohn.MiChangSheng.JTools.Model.Entity.Seid;
using TierneyJohn.MiChangSheng.JTools.Util;

namespace TierneyJohn.MiChangSheng.JTools.Builder;

/// <summary>
/// Seid 数据构造器
/// </summary>
public class SeidDataBuilder
{
    #region 字段属性

    private string _path;

    private SeidEntity _seidEntity = new();

    #endregion

    #region Builder 方法

    public SeidDataBuilder Add(SeidEntity data)
    {
        _seidEntity = data;
        return this;
    }

    public SeidDataBuilder AddBuffSeid(Dictionary<int, List<BaseSeidEntity>> data)
    {
        _seidEntity.BuffSeidDictionary = data;
        return this;
    }

    public SeidDataBuilder AddBuffSeid(int key, List<BaseSeidEntity> data)
    {
        _seidEntity.BuffSeidDictionary[key] = data;
        return this;
    }

    public SeidDataBuilder AddEquipSeid(Dictionary<int, List<BaseSeidEntity>> data)
    {
        _seidEntity.EquipSeidDictionary = data;
        return this;
    }

    public SeidDataBuilder AddEquipSeid(int key, List<BaseSeidEntity> data)
    {
        _seidEntity.EquipSeidDictionary[key] = data;
        return this;
    }

    public SeidDataBuilder AddItemSeid(Dictionary<int, List<BaseSeidEntity>> data)
    {
        _seidEntity.ItemSeidDictionary = data;
        return this;
    }

    public SeidDataBuilder AddItemSeid(int key, List<BaseSeidEntity> data)
    {
        _seidEntity.ItemSeidDictionary[key] = data;
        return this;
    }

    public SeidDataBuilder AddSkillSeid(Dictionary<int, List<BaseSeidEntity>> data)
    {
        _seidEntity.SkillSeidDictionary = data;
        return this;
    }

    public SeidDataBuilder AddSkillSeid(int key, List<BaseSeidEntity> data)
    {
        _seidEntity.SkillSeidDictionary[key] = data;
        return this;
    }

    public SeidDataBuilder AddStaticSkillSeid(Dictionary<int, List<BaseSeidEntity>> data)
    {
        _seidEntity.StaticSkillSeidDictionary = data;
        return this;
    }

    public SeidDataBuilder AddStaticSkillSeid(int key, List<BaseSeidEntity> data)
    {
        _seidEntity.StaticSkillSeidDictionary[key] = data;
        return this;
    }

    public SeidDataBuilder SetBuildPath(Type mainClass, string path = "Data")
    {
        _path = $"{Directory.GetParent(mainClass.Assembly.Location)?.FullName}/{path}";
        return this;
    }

    public SeidEntity GetData() { return _seidEntity; }

    public void Build() { DataManager.SeidData.Archive(_path, _seidEntity); }

    public void Load()
    {
        foreach (var item in _seidEntity.BuffSeidDictionary)
        {
            DataManager.Inst.seidEntity.BuffSeidDictionary[item.Key] ??= [];
            DataManager.Inst.seidEntity.BuffSeidDictionary[item.Key].AddRange(item.Value);
        }

        foreach (var item in _seidEntity.EquipSeidDictionary)
        {
            DataManager.Inst.seidEntity.EquipSeidDictionary[item.Key] ??= [];
            DataManager.Inst.seidEntity.EquipSeidDictionary[item.Key].AddRange(item.Value);
        }

        foreach (var item in _seidEntity.ItemSeidDictionary)
        {
            DataManager.Inst.seidEntity.ItemSeidDictionary[item.Key] ??= [];
            DataManager.Inst.seidEntity.ItemSeidDictionary[item.Key].AddRange(item.Value);
        }

        foreach (var item in _seidEntity.SkillSeidDictionary)
        {
            DataManager.Inst.seidEntity.SkillSeidDictionary[item.Key] ??= [];
            DataManager.Inst.seidEntity.SkillSeidDictionary[item.Key].AddRange(item.Value);
        }

        foreach (var item in _seidEntity.StaticSkillSeidDictionary)
        {
            DataManager.Inst.seidEntity.StaticSkillSeidDictionary[item.Key] ??= [];
            DataManager.Inst.seidEntity.StaticSkillSeidDictionary[item.Key].AddRange(item.Value);
        }
    }

    #endregion
}