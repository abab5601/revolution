using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lottery", menuName = "DATA/Lottery", order = 1)]
public class Lottery : ScriptableObject {
    public Commodity[] commodity;
    [System.Serializable]
    public struct Commodity
    {
        public string Name/*標題名子用誤用於輸出，後面改成是比較好改*/;
        public int ID/*物件ID*/, Quantity/*抽種1次獲得的數量*/;
        public float Probability/*得到的機率最大值為100*/;
    }
}
