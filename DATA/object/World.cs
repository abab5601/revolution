using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "world", menuName = "DATA/world", order = 2)]
public class World : ScriptableObject {
    [Header("移動")]
    public float Ability;
    [Header("跳")]
    public float jump;//天賦1點代表數量
    [Header("力量")]
    public float power;
    [Header("敏捷")]
    public float agile;
    [Header("智慧")]
    public float wisdom;
    [Header("物件旋轉速度")]
    public float object_seed;
    [Header("物件銷毀時間")]
    public float object_time;
    [Header("物品丟出距離")]
    public float object_distance;
    [Header("背包物件加疊最高數量")]
    public int Cumulative_quantity;
    [Header("初始升級經驗值")]
    public int LV_UP;
    [Header("每等增加所需數")]
    public int LV_TO_UP;
    [Header("視角靈敏度")]
    public float Sensitivity;
    [Header("第三人稱 鏡頭距離")]
    public float Lens_distance;
    [Header("職業初始天賦")]
    [Header("  沒職業 = 0 ,  戰士 = 1 , 弓手 = 2, 法師 = 3, 刺客 = 4, 槍手 = 5")]
    public ability[] Career = new ability[6];
    [Header("基本值(如遇能力縮減的最低值)")]
    public ability Basic;
    [Header("天賦上限")]
    public int Upper_limit;
    [Header("玩家掉落高度損寫")]
    public float high;
    [Header("超過掉落高度美多少家1層")]
    public float high_up;
    [Header("每一層鎖扣血量")]
    public float high_hp;
    [Header("時間")]
    public int Time;
    [Header("與現實時間倍率")]
    public float Time_x;
    [Header("NPC最大數量")]
    public int NPC_MAX;
    [Header("NPC巡邏點數量")]
    public int NPC_GO;
    [Header("2點間最大距離")]
    public float NPC_distance;
    [Header("NPC與玩家距離限制")]
    public float NPC_distance_MAX;
    [Header("轉換場僅用圖片")]
    public Sprite Screen;
    [Header("小提示")]
    public string[] prompt;
    [Header("彈跳視窗講話速度")]
    public float delay;
    public enum map
    {
        home = 0,//首頁
        Account_registration = 1,//一開始的傳送用
        Trainingteam = 2,//初始城鎮
        UI = 3
    };
    [System.Serializable]
    public struct ability
    {
        [Header("職業名")]
        public string name;
        [Header("移動 = 0 , 跳 = 1 , 力量 = 2 , 敏捷 = 3 , 智慧 = 4")]
        public int[] value;

    }
    public enum Ability_menu
    {
        mobile = 0,
        jump = 1,
        power = 2,
        agile = 3,
        wisdom = 4
    }
    public string[] Tag = { "Player", " NPC", "Monster", "Prop", "building_damage", "building" };

}



