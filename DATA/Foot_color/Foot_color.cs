using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Foot color", menuName = "DATA/Foot_color", order = 4)]
public class Foot_color : ScriptableObject
{
    [Header("腳色")]
    public Model[] model;

    //生物類別
    [System.Serializable]
    public struct Model
    {
        [Header("名字")]
        public string name;
        [Header("ID")]
        public int ID;
        [Header("模型物件")]
        public  GameObject GameObject;
    }
}
