using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_tas : MonoBehaviour
{
    //0=未完成 1=進行中 2=已完成

    public TaskData Td;
    public Text[] haha, text, but;
    

    public void Update()
    {

        switch (Td.UI_number)
        {

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
    void a()
    {
        for (int x = 0; x < 5; x++)
        {



            haha[x].text = Td.BT[x].Name;
            text[x].text = Td.BT[x].Description;

            switch (Td.BT[x].Schedule)
            {
                case 0:
                    but[x].text = "未完成";
                    break;
                case 1:
                    but[x].text = "進行中";
                    break;
                case 2:
                    but[x].text = "已完成";
                    break;
            }

        }
    }
    void b()
    {

        for (int x = 0; x < 5; x++)
        {

            haha[x].text = Td.VT[x].Name;
            text[x].text = Td.VT[x].Description;

            switch (Td.VT[x].Schedule)
            {
                case 0:
                    but[x].text = "未完成";
                    break;
                case 1:
                    but[x].text = "進行中";
                    break;
                case 2:
                    but[x].text = "已完成";
                    break;
            }

        }
    }
    void c()
    {
        for (int x = 0; x < 5; x++)
        {

            haha[x].text = Td.AT[x].Name;
            text[x].text = Td.AT[x].Description;

            switch (Td.AT[x].Schedule)
            {
                case 0:
                    but[x].text = "未完成";
                    break;
                case 1:
                    but[x].text = "進行中";
                    break;
                case 2:
                    but[x].text = "已完成";
                    break;
            }

        }
    }
    //

}
