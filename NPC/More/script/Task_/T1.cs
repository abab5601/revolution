using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour {
    public UnityEngine.Sprite Image;
    public TaskData task;
    public List<Task_Condition> a = new List<Task_Condition>();
    // Use this for initialization
    void Start () {
        a.Add(new Task_Condition("打禮包送草包", 0, 10, Image));
    }
    public void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.name)
        {

            case "E_user__":

                TaskData1 TD1 = new TaskData1("打禮包送草包", "去農田打十個草包回來", a[0]);
                task.BT[0].Name = TD1._TaskName;
                task.BT[0].Description = TD1._Description;
                task.BT[0].Conditions = a;


                break;
        }

    }

}
