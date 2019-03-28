using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 更新文字用
/// </summary>
public class skill_chk : MonoBehaviour {
    public Toggle[] buttons = new Toggle[5];
    public User user;
    public Article_inventory article_inventory;
    private int[] propR=new int[5], propL = new int[5], anim = new int[5];
    private bool[] on=new bool[5];
    private int x = 0;//更新計數用
    private Text[] text=new Text[5];
    // Update is called once per frame
    private void Start()
    {
        for (x = 0; x <= 4; x++)
        {
            text[x] = buttons[x].GetComponentInChildren<Text>();
            buttons[x].interactable = user.Skill[x];
            anim[x] = -1;
        }
    }//尋找文字物件
    void Update()
    {

        if (x > 4) x = 0;//計數
        buttons[x].interactable = user.Skill[x];
        if (!user.Skill_op[x])
        {
            text[x].text = "技能欄未開啟";
            on[x] = false;
        }
        else if (!on[x])
            Reset(x);
        if (anim[x] != -1)
        {
            if (user.Anim[anim[x]].skill != (User.Skill_)x + 1)
                Reset(x);
        }
        else if (anim[x] == -1&&user.Skill_op[x])
        {
           Reset(x);
        }
        else if (propR[x] != -1)
        {
            if (user.backpack[propR[x]].skill != (User.Skill_)x + 1)
                Reset(x);
        }
        else if (propR[x] == -1 && user.Skill_op[x])
        {
            Reset(x);
        }
        else if (propL[x] != -1)
        {
            if (user.backpack[propL[x]].skill != (User.Skill_)x + 5)
                Reset(x);
        }
        else if (propL[x] == -1 && user.Skill_op[x])
        {
            Reset(x);
        }
        x++;
    }
    /// <summary>
    /// 文字更新
    /// </summary>
    private void Reset(int x)
    {
        int i;
        on[x] = true;
        #region 引入資料
        var anim = new List<User.anim>(user.Anim);
        var Animation = new List<Article_inventory.Animation>(article_inventory.animation);
        var prop = new List<USER_initial.Backpack>(user.backpack);
        var data = new List<Article_inventory.Commodity>(article_inventory.commodity);
        #endregion
        #region 文字更新
        if (user.Skill[x])
        {
            text[x].text = "狀態 : " + (user.Skill_op[x] ? "開啟" : "關閉");
            #region 動畫
            this.anim[x] = anim.FindIndex(d => d.skill == (User.Skill_)x + 1);//尋找anim ID
            if (this.anim[x] != -1)
            {
                i = Animation.FindIndex(d => d.ID == user.Anim[this.anim[x]].ID);
                this.text[x].text += "\n技能 : ";
                this.text[x].text += user.Anim[this.anim[x]].Name == "" ? article_inventory.animation[i].Name : user.Anim[this.anim[x]].Name;
            }
            else
            {

                text[x].text += "\n無法使用技能";
            }
            #endregion
            #region 物件
            #region 左手
            text[x].text += "\n左手武器 : ";
            propL[x] = prop.FindIndex(d => d.skill == (User.Skill_)x + 6);
            if (propL[x] != -1)
            {
                i = data.FindIndex(d => d.ID == user.backpack[propL[x]].ID);
                this.text[x].text += user.backpack[propL[x]].Name == "" ? article_inventory.commodity[i].Name : user.backpack[propL[x]].Name;
            }
            else
            {
                text[x].text += "空";
            }
            #endregion
            #region 右手
            this.text[x].text += "\n右手武器 : ";
            propR[x] = prop.FindIndex(d => d.skill == (User.Skill_)x + 1);//左手道具欄後的編號
            if (propR[x] != -1)
            {
                i = data.FindIndex(d => d.ID == user.backpack[propR[x]].ID);
                this.text[x].text += user.backpack[propR[x]].Name == "" ? article_inventory.commodity[i].Name : user.backpack[propR[x]].Name;
            }
            else
            {
                this.text[x].text += "空";
            }
            #endregion
            #endregion
           
        }
        else
        {
            text[x].text = "尚未啟用";
        }
        #endregion
    }
}

