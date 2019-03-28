using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
    public User user;
    public Article_inventory article_Inventory;
    public Image image;
    public Image image2;//耐久
    public Text text;
    public Text skill;
    public Toggle toggle;
    public GameObject out_put_ID;
    public GameObject menu_ID;
    [Header("目前欄位")]
    public User.Skill_ Skill;
    private int ID = -2,arrty=-1;
    
    void Update()
    {
        if (reset())
            if (ID == -1)
            {
                image.enabled = false;//沒東西把圖片影藏
                image2.enabled = false;
                toggle.interactable = false;
                arrty = -1;
            }
            else
            {
                var data = new List<Article_inventory.Commodity>(article_Inventory.commodity);
                arrty = data.FindIndex(i => i.ID == user.backpack[ID].ID);
                image.enabled = true;
                image.sprite = article_Inventory.commodity[arrty].image;
                if (article_Inventory.commodity[arrty].durable!=-1) image2.enabled = true;
                else image2.enabled = false;
                toggle.interactable = true;

            }
        if (image2.enabled)
        {
            image2.fillAmount =
                user.backpack[ID].Consumption
                /
                article_Inventory.commodity[arrty].durable;
            if (user.backpack[ID].Consumption / article_Inventory.commodity[arrty].durable >= 0.5)
                image2.color =
                    Color.Lerp
                    (Color.yellow, 
                    Color.green, 
                    (user.backpack[ID].Consumption / article_Inventory.commodity[arrty].durable) - 0.5f);
            else image2.color
                    = Color.Lerp
                    (Color.red, 
                    Color.yellow, 
                    (user.backpack[ID].Consumption / article_Inventory.commodity[arrty].durable) + 0.5f);

        }


    }
    private bool reset()//跟新?
    {
        int i = 0;

        while (i <= user.backpack.Length - 1 && user.backpack.Length != 0)
        {

            if (user.backpack[i].skill == this.Skill)
            {


                if (ID != i)
                {
                    ID = i;
                    return true;
                }
                else
                    return false;
            }
            i++;
        }
        if (ID != -1)
        {
            ID = -1;
            return true;
        }
        else
            return false;
    }
    /// <summary>
    /// 跟新文字
    /// </summary>
    /// <param name="Bool"></param>
    public void Description(bool Bool)
    {
        if (Bool)
        {
            out_put_ID.name = ID + "";
            if (user.backpack[ID].Name != "")
            {
                text.text = "道具名子:" + user.backpack[ID].Name;
            }
            else
            {
                text.text = "道具名字" + article_Inventory.commodity[arrty].Name;
            }
            switch (Skill) {
                case USER_initial.Skill_.right_1:
                    skill.text = "部位 : 右手道具欄1";
                    break;
                case USER_initial.Skill_.right_2:
                    skill.text = "部位 : 右手道具欄2";
                    break;
                case USER_initial.Skill_.right_3:
                    skill.text = "部位 : 右手道具欄3";
                    break;
                case USER_initial.Skill_.left_1:
                    skill.text = "部位 : 左手道具欄1";
                    break;
                case USER_initial.Skill_.left_2:
                    skill.text = "部位 : 左手道具欄2";
                    break;
                case USER_initial.Skill_.left_3:
                    skill.text = "部位 : 左手道具欄3";
                    break;
                case USER_initial.Skill_.head:
                    skill.text = "部位 : 頭";
                    break;
                case USER_initial.Skill_.body:
                    skill.text = "部位 : 身體";
                    break;
                case USER_initial.Skill_.foot:
                    skill.text = "部位 : 腳";
                    break;
                case USER_initial.Skill_.leg:
                    skill.text = "部位 : 腿";
                    break;
                case USER_initial.Skill_.Ring:
                    skill.text = "部位 : 戒指";
                    break;
                case USER_initial.Skill_.necklace:
                    skill.text = "部位 : 項鍊";
                    break;
                case USER_initial.Skill_.gloves:
                    skill.text = "部位 : 手套";
                    break;
                case USER_initial.Skill_.Special_props:
                    skill.text = "部位 : 特殊道具";
                    break;

            }
        }
    }
    public void skill_donw()
    {
        user.backpack[System.Int32.Parse(out_put_ID.name)].skill = User.Skill_.No;
    }
    /// <summary>
    ///開啟菜單 
    /// </summary>
    public void menu()
    {
        menu_ID.GetComponent<Menu>().display(int.Parse( out_put_ID.name));
    }
}
