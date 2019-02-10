using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskD", menuName = "DATA/task", order = 1)]
public class TaskData : ScriptableObject
{

    [Header("主線任務")]
    public BosTask[] BT;
    [Header("支線任務")]
    public BosTask[] VT;
    [Header("及時任務")]
    public AnxiousTask[] AT;


    [System.Serializable]
    public struct BosTask {
        [Header("任務名稱")]
        public string Name;                       //任務名稱
        [Header("任務敘述")]
        public string Description;                //任務敘述
        [Header("任務條件")]
        public List<Task_Condition> Conditions;   //任務條件
        // 條件名
        //public string Name;
        // 目前達成數量
        //public int Currently;
        // 預計完成數量
        //public int Max;
        // 小圖示
        //public UnityEngine.Sprite Image;

         [Header("任務進度")]
        public string Schedule;                   //任務進度
        //0=未完成 1=進行中 2=已完成

    }

    [System.Serializable]
    public struct VicesTask
    {
        [Header("任務名稱")]
        public string Name;                       //任務名稱
        [Header("任務敘述")]
        public string Description;                //任務敘述
        [Header("任務條件")]
        public List<Task_Condition> Conditions;   //任務條件
        // 條件名
        //public string Name;
        // 目前達成數量
        //public int Currently;
        // 預計完成數量
        //public int Max;
        // 小圖示
        //public UnityEngine.Sprite Image;
        [Header("任務進度")]
        public string Schedule;                   //任務進度
        //0=未完成 1=進行中 2=已完成
    }


    [System.Serializable]
    public struct AnxiousTask
    {
        [Header("任務名稱")]
        public string Name;                       //任務名稱
        [Header("任務敘述")]
        public string Description;                //任務敘述
        [Header("任務條件")]
        public List<Task_Condition> Conditions;   //任務條件
        // 條件名
        //public string Name;
        // 目前達成數量
        //public int Currently;
        // 預計完成數量
        //public int Max;
        // 小圖示
        //public UnityEngine.Sprite Image;
        [Header("任務進度")]
        public string Schedule;                   //任務進度
        //0=未完成 1=進行中 2=已完成

    }


}
