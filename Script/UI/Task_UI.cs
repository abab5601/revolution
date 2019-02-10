using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Task_ui : MonoBehaviour {
    //0=未完成 1=進行中 2=已完成

    public TaskData Td;
    public Text[] name, text, but;
    public string e;



    public void Update()
    {

        switch (Td.UI_number) {

            case 0:
                a();
                break;
            case 1:
                b();
                break;
            case 2:
                c();
                break;



        }


    }
    void a() {
        for (int i = 0; i <= 10; i++)
        {

            name[i].text = Td.BT[i].Name;
            text[i].text = Td.BT[i].Description;

            switch (Td.BT[i].Schedule)
            {
                case 0:
                    but[i].text = "未完成";
                    break;
                case 1:
                    but[i].text = "進行中";
                    break;
                case 2:
                    but[i].text = "已完成";
                    break;
            }

        }
    }
    void b() {
        for (int i = 0; i <= 10; i++)
        {

            name[i].text = Td.VT[i].Name;
            text[i].text = Td.VT[i].Description;

            switch (Td.VT[i].Schedule)
            {
                case 0:
                    but[i].text = "未完成";
                    break;
                case 1:
                    but[i].text = "進行中";
                    break;
                case 2:
                    but[i].text = "已完成";
                    break;
            }

        }
    }
    void c() {
        for (int i = 0; i <= 10; i++)
        {

            name[i].text = Td.AT[i].Name;
            text[i].text = Td.AT[i].Description;

            switch (Td.AT[i].Schedule)
            {
                case 0:
                    but[i].text = "未完成";
                    break;
                case 1:
                    but[i].text = "進行中";
                    break;
                case 2:
                    but[i].text = "已完成";
                    break;
            }

        }
    }
    //

}
