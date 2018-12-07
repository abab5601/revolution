using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_status : MonoBehaviour
{
    public User user;
    public Article_inventory article_Inventory;

    public bool menu;//父物件
    public bool Description;//說明?
    public GameObject ameObject;//沒有狀態顯示
    public Image image;//圖
    public Image image2;//倒數
    public Text Name;//名字
    public Text Description_text;//說明文字
    public Text value;//值文字
    public Text time;
    public Sprite[] sprites = new Sprite[9];//倒數圖片

    private int ing=0;
    public GameObject yameObject;
    // Update is called once per frame
    private void Awake()
    {
        while(menu && user.Ctrl.Length > ing && user.Ctrl.Length != 0)
            {
                GameObject new_gameObject;
                new_gameObject = GameObject.Instantiate(ameObject, ameObject.transform.parent, false);
                new_gameObject.SetActive(true);
                new_gameObject.name = ing + "";
                //new_gameObject.transform.SetParent(ameObject.transform.parent, false);
                ing++;
            }
      
    }
    void Update()
    {
        if (!menu && System.Int32.Parse(gameObject.name) >= user.Ctrl.Length) GameObject.Destroy(gameObject);//如果超過陣列將自己刪掉
        else
        {
            if (menu && user.Ctrl.Length <= ing) ing = user.Ctrl.Length;
            if (menu && user.Ctrl.Length != 0 && Description) yameObject.SetActive(false);
            if (menu && user.Ctrl.Length > ing && user.Ctrl.Length != 0)
            {
                GameObject new_gameObject;
                new_gameObject = GameObject.Instantiate(ameObject, ameObject.transform.parent, false);
                new_gameObject.SetActive(true);
                new_gameObject.name = ing + "";
                //new_gameObject.transform.SetParent(ameObject.transform.parent, false);
                ing++;
            }
            else if (menu && user.Ctrl.Length == 0 && Description)
                yameObject.SetActive(true);
            if (!menu)
            {
                if (user.Ctrl[System.Int32.Parse(gameObject.name)].ID == 0)
                {
                    var data = new List<Article_inventory.Commodity>(article_Inventory.commodity);
                    int arrty = data.FindIndex(a => a.ID == user.Ctrl[System.Int32.Parse(gameObject.name)].ID);
                    image.sprite = article_Inventory.commodity[arrty].image;
                }
                else
                    switch (user.Ctrl[System.Int32.Parse(gameObject.name)].mod)
                    {
                        case User.MOD.mobile:

                            if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                            {
                                image.sprite = sprites[0];
                                image2.sprite = sprites[0];
                                image.color = Color.white;
                                image2.color = Color.white;
                            }
                            else
                            {
                                image.sprite = sprites[1];
                                image2.sprite = sprites[1];
                                image.color = Color.Lerp(Color.white, Color.red, 0.7f);
                                image2.color = Color.Lerp(Color.white, Color.red, 0.7f);
                            }
                            break;
                        case User.MOD.jump:

                            if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                            {
                                image.sprite = sprites[2];
                                image2.sprite = sprites[2];
                                image.color = Color.white;
                                image2.color = Color.white;
                            }
                            else
                            {
                                image.sprite = sprites[3];
                                image2.sprite = sprites[3];
                                image.color = Color.Lerp(Color.white, Color.red, 0.7f);
                                image2.color = Color.Lerp(Color.white, Color.red, 0.7f);
                            }
                            break;
                        case User.MOD.Stun:
                            {
                                image.sprite = sprites[4];
                                image2.sprite = sprites[4];
                                image.color = Color.white;
                                image2.color = Color.white;
                            }
                            break;
                        case User.MOD.HP:
                            if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                            {
                                image.sprite = sprites[5];
                                image2.sprite = sprites[5];
                                image.color = Color.white;
                                image2.color = Color.white;
                            }
                            else
                            {
                                image.sprite = sprites[6];
                                image2.sprite = sprites[6];
                                image.color = Color.Lerp(Color.white, Color.red, 0.7f);
                                image2.color = Color.Lerp(Color.white, Color.red, 0.7f);
                            }
                            break;
                        case User.MOD.MP:
                            if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                            {
                                image.sprite = sprites[7];
                                image2.sprite = sprites[7];
                                image.color = Color.white;
                                image2.color = Color.white;
                            }
                            else
                            {
                                image.sprite = sprites[8];
                                image2.sprite = sprites[8];
                                image.color = Color.Lerp(Color.white, Color.red, 0.7f);
                                image2.color = Color.Lerp(Color.white, Color.red, 0.7f);
                            }
                            break;
                    }

                image2.fillAmount =
                    user.Ctrl[System.Int32.Parse(gameObject.name)].time
                    /
                    user.Ctrl[System.Int32.Parse(gameObject.name)].max;
                TimeSpan ts = new TimeSpan(0, 0, (int)Math.Round(user.Ctrl[System.Int32.Parse(gameObject.name)].time));
                if (ts.Hours != 0) time.text = ts.Hours + "h\n" + ts.Minutes + "m";
                else if (ts.Minutes != 0) time.text = ts.Minutes + "m\n" + ts.Seconds + "s";
                else time.text = Math.Round(user.Ctrl[System.Int32.Parse(gameObject.name)].time, 1).ToString("f1") + "s";
                if (Description)
                    Description_text.rectTransform.sizeDelta = new Vector2(Description_text.rectTransform.sizeDelta.x, Description_text.preferredHeight);

            }
        }


    }
    public void Text(bool Bool)
    {
        if (Bool)
        {
            Name.text = "名稱 :" + user.Ctrl[System.Int32.Parse(gameObject.name)].name;
            switch (user.Ctrl[System.Int32.Parse(gameObject.name)].mod)
            {
                case User.MOD.mobile:

                    if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                        value.text = "移動加速 :" + user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    else
                        value.text = "移動減速 :" + -user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    break;
                case User.MOD.jump:

                    if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0)
                        value.text = "跳躍增加 :" + user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    else
                        value.text = "跳躍減少 :" + -user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    break;
                case User.MOD.Stun:
                    value.text = "暈眩";
                    break;
                case User.MOD.HP:
                    if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0) value.text = "血量回復 :" + user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    else
                        value.text = "扣血 :" + -user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    break;
                case User.MOD.MP:
                    if (user.Ctrl[System.Int32.Parse(gameObject.name)].value > 0) value.text = "魔力回復 :" + user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    else
                        value.text = "魔力流失 :" + -user.Ctrl[System.Int32.Parse(gameObject.name)].value;
                    break;
            }

            if (Description)
            {
                Description_text.text = "說明:\n" + user.Ctrl[System.Int32.Parse(gameObject.name)].Description;
            }
        }
        
    }
}
