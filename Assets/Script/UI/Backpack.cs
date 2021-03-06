﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Backpack : MonoBehaviour {

    #region 生成物件用
    public User user;
    public Article_inventory article_Inventory;
    public Text text;
    public Text textmax;
    private GameObject new_gameObject;
    public Transform Parent_object;
    public RectTransform Parent_object_2D;
    private int arrty;
    private int X;/*行數*/

    #endregion
    #region 刷新
    public Image myImage;
    public Image image;
    public Text mytext;
    private bool playtime;
    public Button button;
    public Menu.Display_backpack display_Backpack;
    public int u;
    #endregion
    private void Start()
    {
            if (u+"" == "0")
                res(0);

    }
    public void res(int a)
    {
        u = a;
        name = a+"";
        #region 生成物件用
        X = user.backpackMax / 7;
        if (user.backpackMax % 7 > 0) X += 1;
        Parent_object_2D.sizeDelta = new Vector2(Parent_object_2D.sizeDelta.x, 185 * X);
        user.UI = u;



        if (user.backpackMax > u + 1)
        {

            new_gameObject = GameObject.Instantiate(gameObject, Parent_object);
            new_gameObject.GetComponent<Backpack>().res(u + 1);
        }
        #endregion
    }
    private void OnEnable()
    {
        textmax.text = "背包:" + user.backpack.Length + "/" + user.backpackMax;
        text.text = "剩餘空間:" + (user.backpackMax - user.backpack.Length);
        if (playtime)
        {
            if (user.UI == u && user.backpackMax > u + 1)
                res(u);
        }
        else playtime = true;
    }
    public void Reset()
    {
        if (u < user.backpack.Length)
        {
            var data = new List<Article_inventory.Commodity>(article_Inventory.commodity);
            arrty = data.FindIndex(i => i.ID == user.backpack[u].ID);
            if (article_Inventory.commodity[arrty].image != null)
            {
                myImage.enabled = true;
                myImage.sprite = article_Inventory.commodity[arrty].image;
            }
            if (user.backpack[u].Name != "") mytext.text = user.backpack[u].Name;
            else mytext.text = article_Inventory.commodity[arrty].Name;
            button.interactable = true;
            if (article_Inventory.commodity[arrty].durable!=-1) image.enabled = true;
            else image.enabled = false;
            if (image.enabled)
            {
                image.fillAmount =
                    user.backpack[u].Consumption
                    /
                    article_Inventory.commodity[arrty].durable;
                if (user.backpack[u].Consumption / article_Inventory.commodity[arrty].durable >= 0.5)
                    image.color =
                        Color.Lerp
                        (Color.yellow,
                        Color.green,
                        (user.backpack[u].Consumption / article_Inventory.commodity[arrty].durable) - 0.5f);
                else image.color
                        = Color.Lerp
                        (Color.red,
                        Color.yellow,
                        (user.backpack[u].Consumption / article_Inventory.commodity[arrty].durable) + 0.5f);

            }
        }
        else
        {
            Debug.Log(true);
            myImage.enabled = false;
            mytext.text = "";
            button.interactable = false;
            image.enabled = false;

        }
        
        

    }
    void Update ()
    {
       Reset();
        if (user.backpack.Length-1 >= u)
        {
            if (user.backpack[u].Consumption <= 0 && article_Inventory.commodity[arrty].
                durable!=-1)
            {
                var temp = new List<User.Backpack>(user.backpack);
                temp.RemoveAt(u);
                user.backpack = temp.ToArray();
            }
        }


    }
    public void click()
    {
        display_Backpack.Invoke(u);
    }
}
