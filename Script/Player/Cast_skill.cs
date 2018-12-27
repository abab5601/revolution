using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast_skill : MonoBehaviour {
    //引入玩家資料庫。
    public User user;
    //引入武器資料庫。
    public Article_inventory article_inventory;
    //玩家 "動畫" 
    public Animator anim;

    //玩家 "物件" 抓 左 右手位置
    public Transform L_position, R_position;
    public GameObject body;
    //玩家 "參數"   
    private GameObject Arms_L, Arms_R;     //"武器"
    private float time=0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //如果要放計能時執行
        if (user.skill_play != -1 && user.too)
        {
            
            user.too = false;
            int ID = -1, Array = -1;
            var anim = new List<User.anim>(user.Anim);
            var Animation = new List<Article_inventory.Animation>(article_inventory.animation);
            var prop = new List<USER_initial.Backpack>(user.backpack);
            var data = new List<Article_inventory.Commodity>(article_inventory.commodity);
            //左手
            Array = prop.FindIndex(a => a.skill == (User.Skill_)user.skill_play + 5);
            if (Array != -1)//有武器
            {
                ID = data.FindIndex(a => a.ID == user.backpack[Array].ID);
                Arms_L = Instantiate(article_inventory.commodity[ID].gameObject, L_position,true);
                Arms_L.GetComponent<Prop>().display(Array);
            }
            //右手
            Array = prop.FindIndex(a => a.skill == (User.Skill_)user.skill_play);
            if (Array != -1)//有武器
            {
                ID = data.FindIndex(a => a.ID == user.backpack[Array].ID);
                Arms_R = Instantiate(article_inventory.commodity[ID].gameObject, R_position, true);
                Arms_R.GetComponent<Prop>().display(Array);
            }
            //動畫
            ID = anim.FindIndex(a => a.skill == (User.Skill_)user.skill_play);
            this.anim.SetInteger("Anim_ID", user.Anim[ID].ID);//動畫控制
            ID = Animation.FindIndex(a => a.ID == user.Anim[ID].ID);
            time = article_inventory.animation[ID].time_play;
            Destroy(Arms_L, time + 0.5f);
            Destroy(Arms_R, time + 0.5f);
            body.SetActive(true);
            body.transform.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(user.direction.x, user.direction.y) * Mathf.Rad2Deg, 0));

        }
        else if (time <= 0)
        {
            anim.SetInteger("Anim_ID", 0);
            user.skill_play = -1;
            body.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
            time -= Time.deltaTime;
        
    }
}