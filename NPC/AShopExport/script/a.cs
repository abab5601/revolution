using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a  : MonoBehaviour {
    public User user;
    public Sprite A_, B_, C_;
    // Use this for initialization
    void Start () {
        XLL(0);
    }

    int A = 0;


    void XLL(int X)
    {

        A += X + 1;
        string[] D = new string[0];
        string F = "";
        Sprite str = null;
        switch (A)
        {
            case 0:
                F = "看你跟我曾經一位朋友很像，所以花了點時間救了你。你休息夠了吧，你是不能白吃白喝的 ! 做點事情，去找康德吧，他會告訴你怎做";
                break;
            case 1:
                F = "我必須確定你不是邪惡的門徒，你先為我們掃除周邊的小怪吧";
                D = new string[1] { "繼續", };
                break;
            case 2:
                F = "你選了任務1 \n  謝謝你選了我 \n 請選擇是的按鈕";
                D = new string[1] { "繼續" };
                A += 2;
                str = A_;
                break;
            case 3:
                F = "你選了任務2 \n  幹你選了我 \n 請選擇是的按鈕";
                D = new string[1] { "繼續閱讀", };
                A += 3;
                str = B_;
                break;
            case 4:
                F = "你選了任務3 \n  你選了我.... \n 請選擇是的按鈕";
                D = new string[1] { "繼續" };
                A += 4;
                str = C_;
                break;
            case 5:
                F = "你不接任務...";
                str = A_;
                break;
            case 6:
                F = "感謝你接下任務1 \n任務開始";
                str = A_;
                break;
            case 7:
                F = "幹 \n 選了又不做，機掰人";
                str = B_;
                break;
            case 8:
                F = "好啦讓你做";
                str = B_;
                break;
            case 9:
                F = "不做就快滾\n不要打擾我";
                str = C_;
                break;
            case 10:
                F = "好啦";
                str = C_;
                break;




        }

        XLL(0);
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

    }

    // Update is called once per frame
    void Update () {
		
	}
}
