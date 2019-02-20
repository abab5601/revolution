using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour {
    public UnityEngine.Sprite Image;
    public TaskData task;
    public List<Task_Condition> a = new List<Task_Condition>();
    public GameObject a1_most;
    public GameObject b1_most;
    // Use this for initializations
    void Start () {

    }

    public void a1_new_most() {
        a.Add(new Task_Condition("主線任務1-暖暖身子吧，使者", 0, 10, Image));
        TaskData1 TD1 = new TaskData1("主線任務1-暖暖身子吧，使者", "去村莊外頭，解決掉十隻怪物。回來找康德對話", a[0]);
        task.BT[0].Name = TD1._TaskName;
        task.BT[0].Description = TD1._Description;
        task.BT[0].Conditions = a;

        Instantiate(a1_most, new Vector3(203, 0, 193), new Quaternion(0, 90, 0, 0));

    }



}

//-1509794 
//