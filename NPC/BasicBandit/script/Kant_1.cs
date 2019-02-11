﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kant_1 : MonoBehaviour {
    public User user;
    public Sprite A_, B_, C_;
    public TaskData task;
    // Use this for initialization
    public Sprite str = null;
    int A = 0;

    public void t1() {
        
        user.conversation.Add(
new USER_initial.Conversation_format(
   "康德(Kant) : 我必須確定你不是邪惡的門徒，你先為我們掃除周邊的小怪吧",//顯示的字串
   str,//圖片
   XLL,//不理他
   new string[1] { "繼續閱讀" }
   ,//選項  如果沒有選項　設為ｎｕｌｌ
   new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);


        user.conversation.Add(
   new USER_initial.Conversation_format(
       "康德Kant : 恭喜你從今成為我們的一分子，我們在過去的戰爭失去了能力。所以今後就靠你啦 ! 我們需要你找到足夠的食物。",//顯示的字串
       str,//圖片
       XLL,//不理他
       new string[1] { "繼續閱讀" },//選項  如果沒有選項　設為ｎｕｌｌ
       new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
   new USER_initial.Conversation_format(
       "康德Kant : 仔細看書上，清楚指引這附近有一個塔。但為什麼有一個手的圖案 ? 我不知道，你自己處理吧。我要去忙一下",//顯示的字串
       str,//圖片
       XLL,//不理他
       new string[1] { "繼續閱讀" },//選項  如果沒有選項　設為ｎｕｌｌ
       new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
   new USER_initial.Conversation_format(
       "康德Kant : 剛剛我的斥侯剛才傳來一個令人憤怒的情報。布魯姆菲爾德，一位曾經在對抗巴格達迪的戰爭中最優秀的同志，他的遺體遭到邪惡的靈魂入侵，現在成了安達利(Andalil)的部下。你必須殺了她，讓她尊貴的靈魂重回大地",//顯示的字串
       str,//圖片
       XLL,//不理他
       new string[1] { "繼續閱讀" },//選項  如果沒有選項　設為ｎｕｌｌ
       new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);


        user.conversation.Add(
new USER_initial.Conversation_format(
"康德Kant : 為了訓練你先去幫我打10隻小怪吧",//顯示的字串
str,//圖片
XLL,//不理他
new string[2] { "接受任務", "放棄任務" },//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));





    }
    public void t2() {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "康德(Kant) : 我必須確定你不是邪惡的門徒，你先為我們掃除村莊外面的小怪吧",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);


        //task.BT[0].Schedule = 1;
    }
    public void t3()
    {
        user.conversation.Add(
new USER_initial.Conversation_format(
"康德(Kant) : 看來我很肯定你是一位非常優秀的戰士",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德(Kant) : 這是給你的獎勵",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德(Kant) : 如果你有缺少資源，可以找我一直領取哦",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);
        win();


    }
    public void win()
    {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "系統 : 獲得 25000金幣 與 200經驗",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.user.experience += 200;
        user.Money.gold += 25000;

        user.conversation.Add(
        new USER_initial.Conversation_format(
        "康德 :對了，最近周圍村子的湖都結冰了。你能去幫我調查嗎?",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);





    }

    public void win2()
    {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "系統 : 獲得 45000金幣 與 2543經驗",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.user.experience += 2543;
        user.Money.gold += 45000;

        user.conversation.Add(
        new USER_initial.Conversation_format(
        "康德 :回來了嗎，他說甚麼?...",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德 :原來如此...，看來她最近真的很忙呢",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德 :原來如此...，看來她最近真的很忙呢",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);





    }
    public void win3()
    {

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德 :甚麼事?",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);





    }
    public void XLL(int X)
    {

        if (X == 0)
        {
            t1();
        }
        else if (X == 1)
        {
            t2();
        } if (X == 2) {
            t3();
        }
        
    }




}

