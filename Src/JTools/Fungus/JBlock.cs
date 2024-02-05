using System;
using System.Collections.Generic;
using Fungus;

namespace TierneyJohn.MiChangSheng.JTools.Fungus
{
    /// <summary>
    /// JTools 封装 Block 对象
    /// </summary>
    [Serializable]
    public class JBlock : Block
    {
        #region 字段/属性

        /// <summary>
        /// Block 内部缓存数据
        /// </summary>
        public int intData;

        /// <summary>
        /// Block 内部缓存数据
        /// </summary>
        public string stringData;

        /// <summary>
        /// Block 内部缓存数据
        /// </summary>
        public bool boolData;

        #endregion

        #region 构造方法

        /// <summary>
        /// 创建并初始化一个 JBlock 对象
        /// </summary>
        /// <param name="jBlockName">Block 名称</param>
        /// <returns>JBlock 对象</returns>
        public JBlock Create(string jBlockName)
        {
            BlockName = jBlockName;
            ItemId = GetFlowchart().NextItemId();
            return this;
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 挂载一个 Command 对象
        /// </summary>
        /// <param name="command">Command 对象</param>
        /// <returns>Command 对象</returns>
        public Command CreateCommand(Command command)
        {
            command.ParentBlock = this;
            command.CommandIndex = commandList.Count;
            command.ItemId = GetFlowchart().NextItemId();
            commandList.Add(command);
            return command;
        }

        /// <summary>
        /// 创建并挂载一个 Command 对象
        /// </summary>
        /// <param name="callback">回调函数 (当Command对象挂载成功后自动执行)</param>
        /// <typeparam name="T">Command 对象类型</typeparam>
        /// <returns>Command 对象</returns>
        public T CreateCommand<T>(Action<T> callback = null) where T : Command
        {
            var command = gameObject.AddComponent<T>();
            CreateCommand(command);
            callback?.Invoke(command);
            return command;
        }

        /// <summary>
        /// 挂载一组 Command 对象
        /// </summary>
        /// <param name="commands">Command 对象组</param>
        public void CreateCommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                CreateCommand(command);
            }
        }

        /// <summary>
        /// Block 对象执行完成后的回调函数
        /// 将在该 Block 关闭前触发
        /// </summary>
        /// <param name="callback">回调函数</param>
        public void SetLastAction(Action callback)
        {
            lastOnCompleteAction += callback;
        }

        #endregion
    }
}