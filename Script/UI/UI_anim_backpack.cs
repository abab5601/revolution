using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_anim_backpack : MonoBehaviour {
    public Article_inventory article_Inventory;
    public User user;
    private int ID = -1;
    public Text text,des;
    public Text max, mai;
    public Menu.Display_backpack display_Backpack;
    private void Start()
    {
        if (Int32.Parse(gameObject.name) == 0)
            Reset();

        if (Int32.Parse(gameObject.name) < user.Anim_max - 1)
        {
            GameObject @object = GameObject.Instantiate(gameObject, transform.parent);
            @object.name = (Int32.Parse(gameObject.name) + 1) + "";
            @object.GetComponent<UI_anim_backpack>().Reset();
        }

    }
    void Update ()
    {
        if (Int32.Parse(gameObject.name) < user.Anim.Length)
            if (ID != user.Anim[Int32.Parse(gameObject.name)].ID)
                Reset();//跟新

	}
    private void Reset()
    {
        if (Int32.Parse(gameObject.name)< user.Anim.Length)
        {
            this.ID = user.Anim[Int32.Parse(gameObject.name)].ID;
            var art = new List<Article_inventory.Animation>(article_Inventory.animation);
            int ID = art.FindIndex(s => s.ID == this.ID);
            bool x=false;
            des.text = "動作分類\n";
            foreach (Article_inventory.anim anim in article_Inventory.animation[ID].anims)
            {
                des.text += (x ? "/" : "") +anim;
                x = true;
            }//動作分類
            text.text = user.Anim[int.Parse(gameObject.name)].Name == "" ? article_Inventory.animation[ID].Name : user.Anim[Int32.Parse(gameObject.name)].Name;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            ID = -1;
            des.text = "";
            text.text = "";
            GetComponent<Button>().interactable = false;
        }
        max.text = "背包容量:" + user.Anim.Length + "/" + user.Anim_max;
        mai.text = "剩餘空間:" + (user.Anim_max - user.Anim.Length);
    }
    public void CK()
    {
        display_Backpack.Invoke(Int32.Parse(gameObject.name));
    }
}
