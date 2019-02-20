using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killTack : MonoBehaviour {
    public TaskData task;
    public User user;
    public Sprite str = null;
    public void XLL(int X)
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        //status: 0=休息1=走2=跑3=受傷4=死亡
        switch (collision.gameObject.name)
        {
            case "E_user__":
                for (int g = 0; g <= 5; g++) {
                    task.BT[g].Schedule = 0;
                    task.BT[g].Conditions[0].Currently = 0;
                }
                user.conversation.Add(
                new USER_initial.Conversation_format(
                "系統管理員：已初始所有任務",
                str,
                XLL,
                new string[1] { "繼續閱讀" }
                ,//選項  如果沒有選項　設為ｎｕｌｌ
                new Color(0, 0, 0, 255), new Color(143, 143, 2, 255)));

                break;

        }

    }
}
