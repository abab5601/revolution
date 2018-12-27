using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "USER", menuName = "DATA/USER", order = 1)]
public class User : USER_initial {
public void Jump(bool x) { jump = x; }
    public void but_No(bool x) { but_no = x; }
    public void skill_edit_(int f) { skill_edit = f; }
    public void mov0() { }
    public Ability ability;
    public bool Load;
    [Header("指向")]
    public Vector2 direction;
    [Header("跳")]
    public bool jump;
    [Header("取消按鍵狀態")]
    public bool but , but_no,too ;
    #region 狀態

    #region 能力
    [System.Serializable]
    public struct Ability
    {
        public float mobile, jump, power, agile, wisdom;
        public bool Stun;
        

    }
    #endregion
    public int skill_play;// 使用中技能
    public int skill_edit;//目前編輯道具欄
    public int AnimPlay;//陣列位置
    public int propL, propR;//陣列位置
    #endregion



}