using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "任務", menuName = "DATA/任務", order = 2)]
public class Task : ScriptableObject {
    [Header("主線任務")]
    public task main;
    [Header("支線任務")]
    public task Branch_line;
    [System.Serializable]
    public struct task {
        [Header("任務ID")]
        public int ID;
        [Header("任務名稱")]
        public string name;
        [Header("任務說明")]
        public string Description;
        [Header("任務內容")]
        public string[] content;
        [Header("任務所需物件")]
        public GameObject[] gameObject;
        [Header("任務所需圖片")]
        public Sprite[] sprite;
    }

}
