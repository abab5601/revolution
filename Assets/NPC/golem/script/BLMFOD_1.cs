using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLMFOD_1 : MonoBehaviour {

    public User user;
    public Sprite A_, B_, C_;
    public TaskData task;
    // Use this for initialization
    public Sprite str = null;
    int A = 0;
    public void XLL(int X)
    {


        //布魯姆菲爾德
        user.conversation.Add(
    new USER_initial.Conversation_format(
   "????:你是如何來到這裡的",//顯示的字串
   str,//圖片
   XLL,//不理他
   new string[1] { "繼續閱讀" }
   ,//選項  如果沒有選項　設為ｎｕｌｌ
   new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);


        user.conversation.Add(
new USER_initial.Conversation_format(
"????:快遠離這裡吧,這裡不是你該來的地方",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"????:你說康德?",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"????:原來是康德叫你來的",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        user.conversation.Add(
new USER_initial.Conversation_format(
"布魯姆菲爾德:哈哈哈，原來是這樣啊。抱歉，我有些事情要先走了。晚點回頭和你說明!",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);
        task.BT[1].Conditions[0].Currently = 2;
    }

    public void dd(){
        user.conversation.Add(
new USER_initial.Conversation_format(
"????:我現在正在忙....",//顯示的字串
str,//圖片
XLL,//不理他
new string[1] { "繼續閱讀" }
,//選項  如果沒有選項　設為ｎｕｌｌ
new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);
    }
    }
