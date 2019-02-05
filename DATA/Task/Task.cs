using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主線任務DataBase + 格式
/// </summary>
[CreateAssetMenu(fileName = "Tack", menuName = "DATA/任務", order = 3)]
public class Task : ScriptableObject
{
    [Header("主線任務清單")]
    public task[] Tasks;
    [System.Serializable]
    public struct task
    {
        [Header("")]
        public string Name;
        [Header("")]
        public string Description;
        [Header("")]
        public string[] condition;
        [Header("")]
        public Object script;
    }
}
