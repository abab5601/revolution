using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getme : MonoBehaviour {
    public int number = 1;//次數
    public TaskData task;
    public User uesr;
    //public MonterData MD = new MonterData(10, "我是任務", 3, 5);
    public UnityEngine.Sprite Image;
    public List<Task_Condition> a = new List<Task_Condition>();

    public void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.gameObject.name)
        {

            case "E_user__":
                Destroy(gameObject);
                //task.BT[0].Name;
                //TaskData1 TD1 = new TaskData1("打禮包送草包", "去農田打十個草包回來", a[0]);

                    //Debug.Log(number);

                task.BT[0].Conditions[0].Currently += number;
                Debug.Log(number);

                if (task.BT[0].Conditions[0].Currently == task.BT[0].Conditions[0].Max)
                {
                    Debug.Log("任務完成~~~~~~~~");
                    task.BT[0].Conditions[0].Currently = 0;
                }

                //Debug.Log(number);
                break;
        }
    }

}
