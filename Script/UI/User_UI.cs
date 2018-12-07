using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User_UI : MonoBehaviour
{
    public Text text;
    public User user;
    public bool big;




    private void Start()
    {
        Chatroom_resat();
    }
    private void Update()
    {
        Chatroom_resat();
    }

    /// <summary>
    /// 文字更新
    /// </summary>
    public void Chatroom_resat()
    {
        var temp = new List<string>(user.chatroom);
        if (user.chatroom.Length >= 100)
        {
            temp.RemoveAt(0);
            user.chatroom = temp.ToArray();
        }
        text.text = "";
        if (big)
        {

            foreach (var text in user.chatroom)
            {
                if (this.text.text.Length == 0)
                {
                    this.text.text = text;
                }
                else
                {
                    this.text.text = this.text.text + "\n" + text;
                }
            }
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight);
        }
        else if (!big)
        {
            int i;
            if (user.chatroom.Length <= 5) { i = 0; }
            else { i = user.chatroom.Length - 5; }

            while (i < user.chatroom.Length)
            {
                i++;
                if (this.text.text.Length == 0)
                {
                    text.text = user.chatroom[i - 1];
                }
                else
                {
                    this.text.text = this.text.text + "\n" + user.chatroom[i - 1];
                }
            }
        }
    }

}
