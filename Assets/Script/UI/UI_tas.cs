using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_tas : MonoBehaviour
{
    //0=未完成 1=進行中 2=已完成

    public TaskData Td;
    public Text[] Name, text, but;
    public string e;



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
        for (int s = 0; s < Td.BT.Length; s++)
        {

            Name[s].text = Td.BT[s].Name;
            text[s].text = Td.BT[s].Description;

            switch (Td.BT[s].Schedule)
            {
                case 0:
                    but[s].text = "未完成";
                    break;
                case 1:
                    but[s].text = "進行中";
                    break;
                case 2:
                    but[s].text = "已完成";
                    break;
            }

        }
    }
    void b()
    {
        for (int s = 0; s < Td.VT.Length; s++)
        {

            Name[s].text = Td.VT[s].Name;
            text[s].text = Td.VT[s].Description;

            switch (Td.VT[s].Schedule)
            {
                case 0:
                    but[s].text = "未完成";
                    break;
                case 1:
                    but[s].text = "進行中";
                    break;
                case 2:
                    but[s].text = "已完成";
                    break;
            }

        }
    }
    void c()
    {
        for (int s = 0; s < Td.AT.Length; s++)
        {

            Name[s].text = Td.AT[s].Name;
            text[s].text = Td.AT[s].Description;

            switch (Td.AT[s].Schedule)
            {
                case 0:
                    but[s].text = "未完成";
                    break;
                case 1:
                    but[s].text = "進行中";
                    break;
                case 2:
                    but[s].text = "已完成";
                    break;
            }

        }
    }
    //

}
