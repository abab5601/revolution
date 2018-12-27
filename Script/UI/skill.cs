using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class skill : MonoBehaviour {
   public  User user;
    public Article_inventory article_inventory;
    public User.Skill_ Skill;
    public Image image;
    public Image image2;//遮罩
    public Text text;//說明
    public Text text2;
    public GameObject Joystick, skil_ga,no, cancel, arrow;
    private float time;/*冷卻*/
    private int prop_IDL, prop_IDR, anim_ID;//背包位置
    private int prop_ID_L, prop_ID_R, anim_ID_;//資料庫位置
    public Color color;
    /// <summary>
    /// 攻擊方向
    /// </summary>
    /// <param name="vector2">方向</param>
    public void CK(Vector2 vector2,bool up)
    {
        if (up && Joystick.active)
        {
            arrow.SetActive(false);
            //取消
            if (user.but_no)
            {
                user.but = false;
                Joystick.SetActive(false);
                cancel.SetActive(false);
                user.but_no = false;
            }
            //發射技能
            else if(Joystick.active)
            {
                user.but = false;
                user.skill_play = -1;
                user.skill_play = (int)Skill;
                Joystick.SetActive(false);
                time = (article_inventory.commodity[prop_ID_L].time + article_inventory.commodity[prop_ID_R].time + article_inventory.animation[anim_ID_].time);
                user.too = true;
                cancel.SetActive(false);
                //OK
            }
                user.direction = vector2;
        }
        //還沒發射//輔助系統//腳色頭要轉向
        else if (user.but_no)
        {
            arrow.SetActive(true);
            arrow.transform.localRotation =Quaternion.Euler( new Vector3(0, Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg, 0));
        }
    }
    private void Awake()
    {
        Reset();
        user.but_no = false;
        user.but = false;
        user.too = false;
    }//OK
    /// <summary>
    /// 更新
    /// </summary>
    public void Reset()
    {
        var anim = new List<User.anim>(user.Anim);
        var Animation = new List<Article_inventory.Animation>(article_inventory.animation);
        var prop = new List<USER_initial.Backpack>(user.backpack);
        var data = new List<Article_inventory.Commodity>(article_inventory.commodity);
        #region 動畫
        anim_ID = anim.FindIndex(d => d.skill == Skill);//尋找anim ID
        if (anim_ID != -1)
        {
            anim_ID_ = Animation.FindIndex(d => d.ID == user.Anim[anim_ID].ID);
            skil_ga.SetActive(true);
        }
        else
        {
            skil_ga.SetActive(false);
        }
        #endregion
        #region 物件
        prop_IDR = prop.FindIndex(d => d.skill == Skill);//右手
        if (prop_IDR != -1)
        {
            prop_ID_R = data.FindIndex(d => d.ID == user.backpack[prop_IDR].ID);
            image.sprite = article_inventory.commodity[prop_ID_R].image;
            image2.sprite = article_inventory.commodity[prop_ID_R].image;
            text.text = user.backpack[prop_IDR].Name == "" ? article_inventory.commodity[prop_ID_R].Name : user.backpack[prop_IDR].Name;
        }
        prop_IDL = prop.FindIndex(d => d.skill == Skill+5);//左手
        if (prop_IDL != -1)
        {
            prop_ID_L = data.FindIndex(d => d.ID == user.backpack[prop_IDL].ID);
            if (prop_IDR == -1)
            {
                image.sprite = article_inventory.commodity[prop_ID_L].image;
                image2.sprite = article_inventory.commodity[prop_ID_L].image;
                text.text = user.backpack[prop_IDL].Name == "" ? article_inventory.commodity[prop_ID_L].Name : user.backpack[prop_IDL].Name;
            }
        }
        if(prop_IDR == -1&& prop_IDL == -1&&anim_ID!=-1)
        {
            text.text = user.Anim[anim_ID].Name == "" ? article_inventory.animation[anim_ID_].Name : user.Anim[anim_ID].Name;
        }

        #endregion
    }//OK
    /// <summary>
    /// 檢查
    /// </summary>
    public void Update()
    {
       
        //動畫檢查
        if (user.Skill_op[(int)Skill - 1]&&user.Skill[(int)Skill - 1]) Reset();
        image2.fillAmount = time / (article_inventory.commodity[prop_ID_L].time+ article_inventory.commodity[prop_ID_R].time + article_inventory.animation[anim_ID_].time);
        if (time>= 0) time -= Time.deltaTime;
        if (!Joystick.active && user.but)
           no.SetActive(true);
        else
            no.SetActive(false);

    }//OK
    /// <summary>
    /// 觸碰
    /// </summary>
    public void CK()
    {
        if (time <= 0 &&  !user.but&&!user.too)//冷卻完
        {
            Joystick.SetActive(true);
            user.but = true;
            cancel.SetActive(true);
        }
    }//OK

}
