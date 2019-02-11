using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour {
    public UnityEngine.Sprite Image;
    public TaskData task;
    public List<Task_Condition> a = new List<Task_Condition>();
    public GameObject g;
    // Use this for initialization
    void Start () {

    }

    public void tt1() {
        a.Add(new Task_Condition("主線任務1-暖暖身子吧，使者", 0, 10, Image));
        TaskData1 TD1 = new TaskData1("主線任務1-暖暖身子吧，使者", "去村莊外頭，解決掉十隻怪物。回來找康德對話", a[0]);
        task.BT[0].Name = TD1._TaskName;
        task.BT[0].Description = TD1._Description;
        task.BT[0].Conditions = a;
        Instantiate(g, new Vector3(203, 4, 193), new Quaternion(0, 90, 0, 0));

    }

    public void tt2()
    {
        a.Add(new Task_Condition("主線任務2-遺忘的勇士", 0, 1, Image));
        TaskData1 TD1 = new TaskData1("主線任務1-暖暖身子吧，使者", "前往被冰凍的湖泊，找到\"遺忘的勇士\"與他對話", a[1]);
        task.BT[0].Name = TD1._TaskName;
        task.BT[0].Description = TD1._Description;
        task.BT[0].Conditions = a;
        Instantiate(g, new Vector3(203, 4, 193), new Quaternion(0, 90, 0, 0));

    }

}
