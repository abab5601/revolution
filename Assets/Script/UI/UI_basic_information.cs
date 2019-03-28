using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_basic_information : MonoBehaviour {

    public User user;
    public Text LV;

    public Text NAME;
    public Text surname;
    public Text mod;
    public Text gold, silver, copper;
    public Text map, area, XYZ;
    public Dropdown dropdown;
    public InputField inputField;
    public void Update()
    {
        LV.text = "LV : " + user.user.LV;
        NAME.text = "名字:" + user.user.Name;//名字
        switch (user.user.Surname)
        {
            case USER_initial.USER.surname.NO:
                surname.text = "性別 : 無選擇";
                break;
            case USER_initial.USER.surname.men:
                surname.text = "性別 : 男";
                break;
            case USER_initial.USER.surname.women:
                surname.text = "性別 : 女";
                break;
        }//性別
        switch (user.user.Mod)
        {
            case USER_initial.Career.NO:
                mod.text = "職業:無";
                break;
            case USER_initial.Career.warrior:
                mod.text = "職業:戰士";
                break;
            case USER_initial.Career.Archer:
                mod.text = "職業:弓手";
                break;
            case USER_initial.Career.Mage:
                mod.text = "職業:法師";
                break;
            case USER_initial.Career.assassin:
                mod.text = "職業:刺客";
                break;
            case USER_initial.Career.Gunman:
                mod.text = "職業:槍手";
                break;
        }//模式
        #region 錢
        gold.text = user.Money.gold >= 1000 ? "金幣:" + user.Money.gold / 1000 + "k" : "金幣:" + user.Money.gold + "";
        silver.text = user.Money.silver >= 1000 ? "銀幣:" + user.Money.silver / 1000 + "k" : "銀幣:" + user.Money.silver + "";
        copper.text = user.Money.copper >= 1000 ? "銅幣:" + user.Money.copper / 1000 + "k" : "銅幣:" + user.Money.copper + "";
        #endregion
        switch (user.XY.map)
        {
            case World.map.Account_registration:
                map.text = "地圖:重生的道路";
                break;
            case World.map.Map_1:
                map.text = "地圖:第一章 : 孤軍營地";
                break;
            case World.map.Trainingteam:
                map.text = "地圖:中央城市";
                break;
        }//地圖
        area.text = "";
        XYZ.text = "座標:\n" +
            "X:" + user.XY.X.ToString("f3") + " Y:" + user.XY.Y.ToString("f3") + " Z:" + user.XY.Z.ToString("f3");

    }
    public void Name()
    {
        user.user.Name = inputField.text;
    }
    public void Surname()
    {
        
        switch (dropdown.value)
        {
            case 0:
                user.user.Surname = USER_initial.USER.surname.NO;
                break;
            case 1:
                user.user.Surname = USER_initial.USER.surname.men;
                break;
            case 2:
                user.user.Surname = USER_initial.USER.surname.women;
                break;
        }
        
    }
}

