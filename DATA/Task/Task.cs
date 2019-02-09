using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任務DataBase + 格式
/// </summary>
[CreateAssetMenu(fileName = "Tack", menuName = "DATA/任務", order = 3)]
public class Task : ScriptableObject
{

    /// <summary>
    /// 主線任務
    /// </summary>
    [Header("主線任務清單")]
    public List< Object > main;
    /// <summary>
    /// 支線任務
    /// </summary>
    [Header("支線任務")]
    public List<string> Branch_line;
    /// <summary>
    /// 限時任務
    /// </summary>
    [Header("限時任務")]
    public List<Time_limited> time_limited;
    /// <summary>
    /// 限時任務格式
    /// </summary>
    [System.Serializable]
    public struct Time_limited
    {
        [Header("任務腳本Class名")]
        public string Task;
        [Header("限時任務結束倒數")]
        public float Time_limited_time;
        [Header("任務再次開始時間(24小時制 格式 : (HHmm) HH 時 mm 分)")]
        [Header("再次開起時會將腳本刪除重新add")]
        [Header("沒有要再次開啟可空")]
        public string[] time;
    }
}
