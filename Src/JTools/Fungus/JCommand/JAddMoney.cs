using System;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus.JCommand;

/// <summary>
/// JTools 封装 AddMoney 指令
/// </summary>
[Serializable]
public class JAddMoney : AddMoney
{
    private string _message;

    #region 构造方法

    /// <summary>
    /// 添加灵石
    /// </summary>
    /// <param name="money">灵石数量</param>
    /// <param name="message">自定义提示文本</param>
    /// <returns>JAddMoney 对象</returns>
    public JAddMoney Create(int money, string message = "")
    {
        AddNum = money;
        _message = message;
        return this;
    }

    #endregion

    #region 公开方法

    public override void OnEnter()
    {
        if (string.IsNullOrEmpty(_message))
        {
            PlayerEx.Player.AddMoney(AddNum);
        }
        else
        {
            var money = (int)PlayerEx.Player.money + AddNum;

            UIPopTip.Inst.Pop(_message, AddNum >= 0 ? PopTipIconType.上箭头 : PopTipIconType.下箭头);

            if (money < 0) money = 0;

            PlayerEx.Player.money = (ulong)money;
        }

        Continue();
    }

    #endregion
}