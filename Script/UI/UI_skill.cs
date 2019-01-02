using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_skill : MonoBehaviour {

    #region 宣告
    public User user;
    public Article_inventory article_inventory;
    public Toggle toggle;
    private int prop_IDL, prop_IDR, anim_ID;//背包位置
    private int prop_IDL_, prop_IDR_, anim_ID_;//資料庫位置
    public Text text;//道具欄名
    public Text anim;//動畫名
    public Text propL, propR;
    public RawImage anim_img;
    public Image prop_imgL,prop_imgR;
    public Menu Menu;
    public Button anim_A, prop_AL, prop_AR;
    public Button anim_B, prop_BL, prop_BR;
    public Text UP_text, UP_text_s;
    public Button UP_Button;
    public GameObject Object;
    /*menus順序*/
    private string[] zh = { "技能欄1", "技能欄2", "技能欄3", "技能欄4", "技能欄5"};
    #endregion
    /// <summary>
    /// 跟新
    /// </summary>
    private void resat()
    {
        #region 引入資料
        var anim = new List<User.anim>(user.Anim);
        var Animation = new List<Article_inventory.Animation>(article_inventory.animation);
        var prop = new List<USER_initial.Backpack>(user.backpack);
        var data = new List<Article_inventory.Commodity>(article_inventory.commodity);
        #endregion
        toggle.isOn = user.Skill_op[user.skill_edit];//啟用更新
        text.text = zh[user.skill_edit];//道具欄名更新
        #region 動畫
        anim_ID = anim.FindIndex(d => d.skill == (User.Skill_)user.skill_edit+1);//尋找anim ID
        if (anim_ID != -1)
        {
            this.anim_A.interactable = true;
            this.anim_B.interactable = true;
            anim_ID_ = Animation.FindIndex(d => d.ID == user.Anim[anim_ID].ID);
            this.anim.text = user.Anim[anim_ID].Name == "" ? article_inventory.animation[anim_ID_].Name : user.Anim[anim_ID].Name;
            this.user.AnimPlay = anim_ID_;
            user.propL = -1;
            user.propR = -1;
        }
        else
        {
            this.anim.text = "無放置";
            this.anim_A.interactable = false;
            this.anim_B.interactable = false;
            //動畫控制器輸出暫著
        }
        #endregion
        #region 物件
        #region 左手
        prop_IDL = prop.FindIndex(d => d.skill == (User.Skill_)user.skill_edit+1);
        if (prop_IDL != -1)
        {
            prop_AL.interactable = true;
            prop_BL.interactable = true;
            prop_IDL_ = data.FindIndex(d => d.ID == user.backpack[prop_IDL].ID);
            this.propL.text = user.backpack[prop_IDL].Name == "" ? article_inventory.commodity[prop_IDL_].Name : user.backpack[prop_IDL].Name;
            this.prop_imgL.sprite = article_inventory.commodity[prop_IDL].image;
        }
        else
        {
            this.propL.text = "無放置";
            this.prop_imgL.sprite = null;
            this.prop_AL.interactable = false;
            this.prop_BL.interactable = false;
        }
        #endregion
        #region 右手
        prop_IDR = prop.FindIndex(d => d.skill == (User.Skill_)user.skill_edit + 6);//左手道具欄後的編號
        if (prop_IDR != -1)
        {
            prop_AR.interactable = true;
            prop_BR.interactable = true;
            prop_IDR_ = data.FindIndex(d => d.ID == user.backpack[prop_IDR].ID);
            this.propR.text = user.backpack[prop_IDR].Name == "" ? article_inventory.commodity[prop_IDR].Name : user.backpack[prop_IDR].Name;
            this.prop_imgR.sprite = article_inventory.commodity[prop_IDR].image;
        }
        else
        {
            this.propR.text = "無放置";
            this.prop_imgR.sprite = null;
            this.prop_AR.interactable = false;
            this.prop_BR.interactable = false;
        }
        #endregion
        #endregion
        UP_Button.interactable = anim_B.interactable;//預覽
        #region 記憶體清除
        anim.Clear();
        Animation.Clear();
        prop.Clear();
        data.Clear();
        anim = null;
        Animation = null;
        prop = null;
        data = null;
        GC.Collect();
        #endregion
    }//OK
    /// <summary>
    ///道具啟用 
    /// </summary>
    /// <param name="x"></param>
    public void Enable()
    {
        user.Skill_op[user.skill_edit] = toggle.isOn;
    }//OK
    /// <summary>
    /// 檢查
    /// </summary>
    public void Update()
    {
        //動畫檢查
        if (anim_ID != -1)
            if (user.Anim[anim_ID].ID != article_inventory.animation[anim_ID_].ID || user.Anim[anim_ID].skill != (User.Skill_)user.skill_edit+1)
                resat();//物件檢查
        if (prop_IDL != -1)
            if (user.backpack[prop_IDL].ID != article_inventory.commodity[prop_IDL_].ID || user.backpack[prop_IDL].skill != (User.Skill_)user.skill_edit+1)
                resat();
        if (prop_IDR != -1)
            if (user.backpack[prop_IDR].ID != article_inventory.commodity[prop_IDR_].ID || user.backpack[prop_IDR].skill != (User.Skill_)user.skill_edit + 6)
                resat();
        if (anim_ID == -1 && prop_IDL == -1 && prop_IDR == -1)
            gameObject.SetActive(false);
    }//OK
    private void OnDisable()
    {
        Object.SetActive(true);
    }
    /// <summary>
    /// 動畫
    /// </summary>
    /// <param name="x"></param>
    public void Anim()
    {
        Menu.Anim(anim_ID);
    }//OK
    /// <summary>
    /// 啟用更新
    /// </summary>
    public void OnEnable()
    {
        resat();
    }//OK
    /// <summary>
    /// 動畫卸下
    /// </summary>
    public void Anim_down()
    {
        Debug.Log(anim_ID);
        user.Anim[anim_ID].skill = USER_initial.Skill_.No;
        resat();
    }//OK
    /// <summary>
    /// 物件
    /// </summary>
    public void Prop(bool LR)//L=true,R=false
    {
        if(LR)
            Menu.display(prop_IDL);
        else
            Menu.display(prop_IDR);
    }//OK
    /// <summary>
    /// 物件卸下
    /// </summary>
    public void Prop_down(bool LR)//L=true,R=false
    {
        if (LR)
        {
            user.backpack[prop_IDL].skill = User.Skill_.No;
            resat();
        }
        else
        {

            user.backpack[prop_IDR].skill = User.Skill_.No;
            resat();
        }
    }//OK
    /// <summary>
    /// 彈跳視窗更新
    /// </summary>
    public void UP()
    {
        user.AnimPlay = anim_ID_;
        user.propL = prop_IDL_;
        user.propR = prop_IDR_;
        UP_text.text =
            "左手道具名稱 : " + this.propL.text +
            "\n右手道具名稱 : " + this.propR.text +
            "\n動畫名稱 : " + this.anim.text +
            "\n攻擊速度 : " + (article_inventory.animation[anim_ID_].time_play == -1f ? "目前無資料" : "" + article_inventory.animation[anim_ID_].time_play) +
            "\n冷卻時間 : " + (article_inventory.commodity[prop_IDL_].time + article_inventory.animation[anim_ID_].time+ article_inventory.commodity[prop_IDR_].time);
        UP_text.rectTransform.sizeDelta = new Vector2(UP_text.rectTransform.sizeDelta.x, UP_text.preferredHeight);
        UP_text_s.text = 
            "\n(" +
            "動作冷卻時間 : " + article_inventory.animation[anim_ID_].time + 
            "+左手武器冷卻時間 : " + article_inventory.commodity[prop_IDL_].time+
            "+右手武器冷卻時間 : " + article_inventory.commodity[prop_IDR_].time + 
            ")\n";
        UP_text_s.rectTransform.sizeDelta = new Vector2(UP_text_s.rectTransform.sizeDelta.x, UP_text_s.preferredHeight);
    }//OK
}