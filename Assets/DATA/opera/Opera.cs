using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Opera", menuName = "Scenes/Opera", order = 1)]
public class Opera : ScriptableObject{

    public Dialogue[] dialogues;
    [System.Serializable]
	public struct Dialogue
    {
        [Header("腳色名")]
        public string Name/*腳色*/;
        [Header("腳色物件ID")]
        public int ID;
        [Header("對話內容")]
        public string People/*內容*/;
        [Header("對話閱讀時間")]
       public int Time/*持續時間*/;
    }


}
