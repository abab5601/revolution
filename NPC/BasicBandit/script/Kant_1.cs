using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kant_1 : MonoBehaviour {
    public User user;
    public Sprite A_, B_, C_;
    public Sprite str = null;
    public TaskData task;
    // Use this for initialization
    
    int A = 0;

    //任務一
    public void a1() {
        
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
    public void a2() {
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
    public void a3()
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
"系統 : 獲得 25000金幣 與 200經驗",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);




    }

    //任務二
    public void b1()
    {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "康德 :糟糕，好像又有一群怪物出現。你能去幫我消滅它們嗎??",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

    }
    public void b2()
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

    }

    //任務三
    public void c1()
    {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "康德 :村莊外頭出現了骷髏海賊BOSS，他很邪惡，注意一點!",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

    }
    public void c2()
    {

        user.conversation.Add(
new USER_initial.Conversation_format(
"康德 :漂亮幹的好!!",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
        new USER_initial.Conversation_format(
        "系統 : 獲得 200000金幣 與 25500經驗",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.user.experience += 25500;
        user.Money.gold += 200000;

    }

    //END
    public void d1()
    {
        user.conversation.Add(
        new USER_initial.Conversation_format(
        "系統：以為你解鎖天賦加點限制，並且生產了更多怪物。",//顯示的字串
        str,//圖片
        XLL,//不理他
        new string[1] { "繼續閱讀" }
        ,//選項  如果沒有選項　設為ｎｕｌｌ
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.user.experience += 299;
        user.Money.gold += 0;

    }

    // 0 = 未完成對話 1 = 進行中 2 = 獎勵時間
    public void XLL(int X)
    {
        switch (X) {
            case 0:
                a1();
                break;
            case 1:

                a2();
                break;
            case 2:
                a3();
                break;

        }

        
    }
    public void XLL2(int X)
    {
        switch (X)
        {
            case 0:
                b1();
                break;
            case 1:

                b2();
                break;

        }


    }

    public void XLL3(int X)
    {
        switch (X)
        {
            case 0:
                c1();
                break;
            case 1:

                c2();
                break;

        }


    }

    public void XLL4(int X)
    {
        switch (X)
        {
            case 0:
                d1();
                break;
            case 1:

                d1();
                break;

        }


    }

}

