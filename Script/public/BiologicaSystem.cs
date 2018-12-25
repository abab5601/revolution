using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiologicaSystem : MonoBehaviour {
    public User user;
    public World world;
    public Article_inventory article_Inventory;
    public User.USER USER_DATA;
    public User.HP HP;
    public User.MP MP;
    public User.money money;
    public User.control[] Control;
    public User.Backpack[] Backpacks;
    public User.anim[] Anim;
	void Start () {
		  
	}
    void Update () {
		
	}
    /// <summary>
    /// 變動血量
    /// </summary>
    /// <param name="Attack_Type">攻擊模式</param>
    /// <param name="HP">變動血量數值</param>
    public void hp(Article_inventory.Attack_attribute Attack_Type, int HP)
    {

    }
    /// <summary>
    /// 變動魔力
    /// </summary>
    /// <param name="HP">變動魔力數值</param>
    public void mp(int MP)
    {

    }
    /// <summary>
    /// 控制
    /// </summary>
    /// <param name="control">控制資料</param>
    /// /// <param name="OUT">增加 = true 減少 = false </param>
    public void control(User.control[] control,bool OUT)
    {

    }
    /// <summary>
    /// 撿起物品
    /// </summary>
    /// <param name="backpack">物品DATA</param>
    /// <param name="OUT">增加 = true 減少 = false </param>
    public void backpack(User.Backpack[] backpack, bool OUT)
    {

    }
    /// <summary>
    /// 學習動作
    /// </summary>
    /// <param name="anim">動作</param>
    /// <param name="OUT">增加 = true 減少 = false </param>
    public void anim(User.anim[] anim, bool OUT)
    {

    }
    /// <summary>
    /// 錢
    /// </summary>
    /// <param name="money">金額</param>
    public void Money(User.money money)
    {

    }
}
