using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TierneyJohn.MiChangSheng.JTools.Model;
using UnityEngine;
using UnityEngine.Events;

namespace TierneyJohn.MiChangSheng.JTools.Manager;

public class TimeFlagManager : MonoBehaviour
{
    #region 字段/属性

    public static TimeFlagManager Inst;
    private readonly TimeFlagEvent _timeFlagEvent = new();

    private readonly Dictionary<string, TimeFlag> _timeFlags = new();

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        MessageMag.Instance.Register(MessageName.MSG_Npc_JieSuan_COMPLETE, AfterComplete);
        _timeFlagEvent.AddListener(TimeFlagListener);
    }

    #endregion

    #region 公开方法

    public void RegisterTimeFlag(DateTime dateTime, Action action, bool isFinal = true)
    {
        var timeFlag = new TimeFlag(dateTime, action, isFinal);
        RegisterTimeFlag(timeFlag.id, timeFlag);
    }

    public void RegisterTimeFlag(string dateTime, Action action, bool isFinal = true)
    {
        var timeFlag = new TimeFlag(dateTime, action, isFinal);
        RegisterTimeFlag(timeFlag.id, timeFlag);
    }

    public void RegisterTimeFlag(string key, TimeFlag timeFlag)
    {
        _timeFlags[key] = timeFlag;
    }

    public void RemoveTimeFlag(string key)
    {
        if (_timeFlags.ContainsKey(key)) _timeFlags.Remove(key);
    }

    #endregion

    #region 私有方法

    private void TimeFlagListener(string dateTime, Action action, bool isFinal = true)
    {
        var timeFlag = new TimeFlag(dateTime, action, isFinal);
        RegisterTimeFlag(timeFlag.id, timeFlag);
    }

    private void AfterComplete(MessageData data = null)
    {
        StartCoroutine(AfterCompleteAction());
    }

    private IEnumerator AfterCompleteAction()
    {
        yield return null;
        var nowTime = PlayerEx.Player.worldTimeMag.getNowTime();
        var removeKeys = new List<string>();

        foreach (var item in _timeFlags.Where(item => item.Value.DateTime > nowTime))
        {
            item.Value.Action.Invoke();

            if (item.Value.isFinal)
            {
                removeKeys.Add(item.Key);
            }
        }

        foreach (var key in removeKeys)
        {
            RemoveTimeFlag(key);
        }
    }

    #endregion
}

internal class TimeFlagEvent : UnityEvent<string, Action, bool>;