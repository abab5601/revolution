using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLMFOD_1 : MonoBehaviour
{

    public User user;
    // Use this for initialization
    public Sprite str = null;
    int A = 0;
    public void XLL(int X)
    {


        //布魯姆菲爾德
        user.conversation.Add(
    new USER_initial.Conversation_format(
   "????:這裡不能通行哦",//顯示的字串
   str,//圖片
   XLL,//不理他
   new string[1] { "繼續閱讀" }
   ,//選項  如果沒有選項　設為ｎｕｌｌ
   new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);



    }
}
