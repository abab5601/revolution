using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任務
/// </summary>
public interface ITask
{
    /// <summary>
    /// 任務名
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// 任務說明
    /// </summary>
    string Description { get; set; }
    /// <summary>
    /// 任務達成條件
    /// </summary>
    List<Task_Condition> Conditions { get; set; }
    /// <summary>
    /// 是否UI開放一鍵引導任務
    /// </summary>
    /// <returns>呼叫Task_Start 權限</returns>
    bool Task_start_bool();
    /// <summary>
    /// 任務開始
    /// </summary>
    void Task_Start();
    /// <summary>
    /// 任務一鍵引導
    /// </summary>
    /// <param name="open">一件引導關閉開啟</param>
    void Task_Go(bool open);

}
/// <summary>
/// 任務達成條件格式
/// </summary>
[System.Serializable]
public class Task_Condition
{
    /// <summary>
    /// 條件名
    /// </summary>
    public string Name;
    /// <summary>
    /// 目前達成數量
    /// </summary>
    public int Currently;
    /// <summary>
    /// 預計完成數量
    /// </summary>
    public int Max;
    /// <summary>
    /// 小圖示
    /// </summary>
    public UnityEngine.Sprite Image;


    public Task_Condition(string Name, int Currently, int Max, Sprite Image) 
    {
        this.Name = Name;
        this.Currently = Currently;
        this.Max = Max;
        this.Image = Image;
    }
}
/// <summary>
/// 任務_生物相關
/// </summary>
public interface IStask_BiologicaSystem
{
    /// <summary>
    /// 死亡傳入資訊
    /// </summary>
    /// <param name="ID">怪物物件ID</param>
    /// <param name="id">怪物ID(怪物固定ID)</param>
    /// <param name="Name">怪物名字</param>
    /// <param name="LV">怪物等級</param>
    void BiologicaSystem_death(int ID, int id, string Name, int LV);
}
/// <summary>
/// 物品相關
/// </summary>
public interface IStask_prop
{
    /// <summary>
    /// 玩家撿到物品
    /// </summary>
    /// <param name="ID">物件ID(unity 內建ID)</param>
    /// <param name="DATA">撿到物品資訊</param>
    void prop_come(int ID, User.Backpack DATA);
    /// <summary>
    /// 玩家丟掉物品
    /// </summary>
    /// <param name="prop">丟掉物品後 GameObject 上的 Prop 腳本</param>
    void prop_throw(Prop prop);
}
