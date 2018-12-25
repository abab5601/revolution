using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Article_inventory", menuName = "DATA/Article_inventory", order = 1)]
public class Article_inventory : ScriptableObject {
    [Header("類型對照")]
    public string[] Classification_Zh;

    public Commodity[] commodity;
    public Animation[] animation;
    #region 道具

    [System.Serializable]
    public struct Commodity
    {
        [Header("*為必填")]
        [Header("基本資料")]
        [Space(10)]
        [Header("*道具名子")]
        public string Name;/*名子*/
        [Space(-10)]
        [Header("*物品ID")]
        public int ID/*物件ID*/;
        [Header("道具取得處")]
        public string[] origin;
        [Header("道具故事")]
        public string story;
        [Header("不能使用的名單")]
        public no_use No_use;
        [Header("*選擇分類")]
        [Space(-10)]
        [Header("dagger = 匕首 , claw = 爪 , bow = 弓 , gun = 槍 , Staff = 法杖 , other = 其他 , sword = 劍 Prop = 道具 , food = 食物 , head = 頭 , body = 身體 , leg = 腿 , foot = 腳, Ring = 戒指 , necklace = 項鍊 , gloves = 手套 , Special_props = 特殊道具 , Throw = 丟掉 , NPC = NPC , monster = 怪物 , box = 箱子")]
        public Classification classification;/*物品分類*/
        [Header("*縮圖")]
        public Sprite image;/*圖片*/
        [Header("*物件")]
        public GameObject gameObject;/*物件*/
        [Header("是否重疊")]
        public bool overlapping;/*是否重疊*/
        [Header("可以放置清單")]
        public Place place;/*可放置清單*/
        [Header("耐久值(沒有耐久不用填)")]
        public float durable;/*耐久*/
        [Header("是否有等級下限")]
        public bool LV;/*是否有等級限制*/
        [Header("限制等級(沒有等級限制不用填)")]
        public int Level_limit;/*限制等級*/
        [Header("是否有力量下限")]
        public bool power;/*是否有力量限制*/
        [Header("限制力量(沒有力量下限不用填)")]
        public int power_limit;/*限制力量*/
        [Header("是否有力量下限")]
        public bool agile;/*是否有等級限制*/
        [Header("限制敏捷(沒有敏捷下限不用填)")]
        public int agile_limit;/*限制敏捷*/
        [Header("是否智慧下限")]
        public bool wisdom;/*是否有智慧限制*/
        [Header("限制智慧(沒有力量下限不用填)")]
        public int wisdom_limit;/*限制力量*/
        [Header("稀有度百分比")]
        public float rare;/*稀有*/
        [Header("*冷卻時間")]
        public float time;/*冷卻時間*/
        [Header("主動攻擊描述 or 道具效果 or 防具效果")]
        public string initiative_Attack_method;
        [Header("被動攻擊描述 or 道具說明 or 防具說明")]
        public string passive_Attack_method;
        [Header("商店是否販售")]
        public bool store;/*是否販賣*/
        [Header("是否會銷毀")]
        public bool destroy;
    }

    [System.Serializable]
    public struct Place
    {
        [Header("背包")]
        public bool backpack;/*背包*/
        [Header("道具欄")]
        [Header("右手")]
        public bool right;/*右手*/
        [Space(-5)]
        [Header("左手")]
        public bool left;/*左手*/
        [Space(-5)]
        [Header("頭")]
        public bool head;/*頭*/
        [Space(-5)]
        [Header("身")]
        public bool body;/*身體*/
        [Space(-5)]
        [Header("腿")]
        public bool leg;/*腿*/
        [Space(-5)]
        [Header("腳")]
        public bool foot;/*腳*/
        [Space(-5)]
        [Header("戒指")]
        public bool Ring;/*戒指*/
        [Space(-5)]
        [Header("項鍊")]
        public bool necklace;/*項鍊*/
        [Space(-5)]
        [Header("手套")]
        public bool gloves;/*手套*/
        [Space(-5)]
        [Header("特殊道具")]
        public bool Special_props;/*特殊道具*/
        [Space(-5)]
        [Header("丟掉")]
        public bool Throw;/*丟掉*/
        [Space(-5)]
        [Header("NPC")]
        public bool NPC;/*NPC*/
        [Space(-5)]
        [Header("怪物")]
        public bool monster;/*怪物*/
        [Space(-5)]
        [Header("箱子")]
        public bool box;/*箱子*/
    }
    [System.Serializable]
    public struct no_use
    {
        [Space(-5)]
        [Header("玩家")]
        public bool user;/*玩家*/
        [Space(-5)]
        [Header("NPC")]
        public bool NPC;/*NPC*/
        [Space(-5)]
        [Header("怪物")]
        public bool monster;/*怪物*/
    }
    [System.Serializable]
    public enum Character
    {
        NO,
        Player,
        NPC,
        monster
    }
    [System.Serializable]
    public enum Classification
    {
        dagger, claw, bow, gun, Staff, other, sword, Prop, food
        , head/*頭*/
    , body/*身體*/
    , leg/*腿*/
    , foot/*腳*/
    , Ring/*戒指*/
    , necklace/*項鍊*/
    , gloves/*手套*/
    , Special_props/*特殊道具*/
    }



    #endregion
    #region 動畫
    [System.Serializable]
    public struct Animation
    {
        public string Name;
        public int ID;/*動畫ID*/
        [Header("動畫故事")]
        public string story;
        [Header("攻擊速度")]
        public float time_play;
        [Header("動畫描述")]
        public string text;
        [Header("動畫冷卻時間")]
        public float time;
        [Header("道具取得處")]
        public string[] origin;
        [Header("是否有等級下限")]
        public bool LV;/*是否有等級限制*/
        [Header("限制等級(沒有等級限制填-1)")]
        public int Level_limit;/*限制等級*/
        [Header("限制力量(沒有力量下限填-1)")]
        public int power_limit;/*限制力量*/
        [Header("限制敏捷(沒有敏捷下限填-1)")]
        public int agile_limit;/*限制敏捷*/
        [Header("限制智慧(沒有力量下限填-1)")]
        public int wisdom_limit;/*限制力量*/
        [Header("動作分類")]
        public anim[] anims;
        [Header("使用權限")]
        public use place;
    }
    [System.Serializable]
public struct use
    {
        [Header("道具欄位")]
        public bool prop;
        [Header("特殊道具")]
        public bool Special_props;
        [Space(-5)]
        [Header("丟掉")]
        public bool Throw;/*丟掉*/
        [Space(-5)]
        [Header("NPC")]
        public bool NPC;
    }
    #endregion
    [System.Serializable]
    public enum anim
    {
        進戰,遠程
    }
    [System.Serializable]
    public enum Attack_attribute
    {
        physical/*物理*/, magic/*魔法*/, Direct_injury/*真傷*/
    }


}
