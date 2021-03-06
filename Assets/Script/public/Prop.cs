﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(EventTrigger))]
public class Prop : MonoBehaviour
{
    [Header("資料庫引入")]
    public User user;
    public Article_inventory article_Inventory;
    public World world;
    [Header("物件ID")]
    public int ID = -1;
    [Header("讓物件初始化角度")]
    public Vector3 rotation;
    [Header("初始化大小")]
    public Vector3 size;
    [Header("手握位置 \"請手動新增武器手握的位置使用game obj\"")]
    public Transform hand;
    [Header("模型外框 \"請手動新增武器撿起範圍\" ")]
    public Collider Outer_frame;
    private bool/*可否開啟選單*/menu,/*是否可以放入背包*/Attack;
    private GameObject Menu_UI;
    public User.Backpack data;
    private int USE_Rarrty = -1;
   // public int 
    /// <summary>
    /// 資料跟新
    /// </summary>
    private void Start()
    {
        

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        // trigger.triggers.Add(entry);


        if (Outer_frame != null)
            if(Attack)
                Outer_frame.enabled = true;
            else
                Outer_frame.enabled = false;

        transform.localRotation = Quaternion.Euler(rotation);
        transform.localScale = size;
        transform.localPosition = new Vector3(0,0,0);
        if (hand != null)
        {
            Vector3 vector = hand.localPosition - transform.localPosition;
            transform.localPosition = -new Vector3(vector.x * size.x, vector.y * size.y, vector.z * size.z);
        }
        Menu_UI = GameObject.Find("User/canvas/Menu");

    }
    /// <summary>
    /// 撿東西
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerClick(PointerEventData data)
    {
        if (USE_Rarrty == -1)
        {
            menu = true;
            Menu_UI.SetActive(true);
            GetComponent<Menu>().display(this.data, gameObject, Attack);
        }
       
    }
    private void Update()
    {

        if (USE_Rarrty != -1)
        {

            user.backpack[USE_Rarrty] = this.data;
            if (data.Consumption == 0)//耐久=0刪掉
            {
                var x = new List<User.Backpack>(user.backpack);
                x.RemoveAt(USE_Rarrty);
                user.backpack = x.ToArray();
            }
        }

    }
    
    public IEnumerator resat()
    {
        yield return new WaitForSeconds(world.object_time);
        Debug.Log("遊戲物件銷毀腳本OK");
        if (menu) Menu_UI.SetActive(false);
        GameObject.Destroy(gameObject);
    }
    /// <summary>
    /// 開啟時update(背包外)
    /// </summary>
    /// <param name="backpack">DATA</param>
    /// <param name="Attack">可否放入背包</param>
    public void display(User.Backpack backpack,bool Attack)
    {
        data = backpack;
        this.USE_Rarrty = -1;
    }
    /// <summary>
    /// 商店用
    /// </summary>
    /// <param name="Quantity">數量</param>
    /// <param name="Consumption">耐久</param>
    /// <param name="money">前</param>
    /// <param name="Name">名子</param>
    public void display(int Quantity,float Consumption , int money,string Name)
    {

    }
    /// <summary>
    /// 背包內
    /// </summary>
    /// <param name="Array"></param>
    public void display(int Array)
    {
        Attack = false;
        data = user.backpack[Array];
        USE_Rarrty = Array;
    }
}