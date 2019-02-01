using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_deloe : MonoBehaviour {


    public User user;
    // Use this for initialization

    void isme(int x)
    {
        Debug.Log(x);

    }
    void Start() {
        /* 
    [Header("對話內容會自動加入對話框")]
    [Header("對話內容")]
    public string String;
    [Header("人物圖片或會話提示圖\n如為null將會隱藏圖片")]
    public Sprite sprite;
    [Header("乙讀呼叫,放入值為函式\n回傳值如果沒有選項回傳-1\n如有回傳選項ID")]
    [Header("如果放入值為null會自動顯示下一行\n如果沒有下一行會自動關閉對話框")]
    [Space(50)]
    public System.Action<int> GameObject;
    [Header("選項,回傳陣列ID")]
    public string[] Option;
    [Header("文字背景顏色")]
    public Color background;
    [Header("文字顏色")]
    public Color text;
    */

        // 第一段

        user.conversation.Add(
            new USER_initial.Conversation_format(
                "大家好,大中天",//顯示的字串
                null,//圖片
                isme,//不理他
                new string[2] { "一樓", "二樓" },//選項
                new Color(0,0,0,255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);

        //第二段
        user.conversation.Add(
    new USER_initial.Conversation_format(
        "大家好,大中天22",//顯示的字串
        null,//圖片
        isme,//不理他
        new string[1] { "繼續" },//選項
        new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));//背景與文字的color(0,0,0,0);




    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
