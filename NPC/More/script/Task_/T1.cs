using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour {
    public UnityEngine.Sprite Image;
    public TaskData task;
    public List<Task_Condition> a = new List<Task_Condition>();
    public GameObject a1_most;
    public GameObject b1_most;
    public GameObject c1_most;
    public GameObject d1_most;
    // Use this for initializations
    void Start () {

    }

    public void a1_new_most() {
        Instantiate(a1_most, new Vector3(203, 0, 193), new Quaternion(0, 90, 0, 0));
    }
    public void b1_new_most()
    {

        Instantiate(b1_most, new Vector3(203, 0, 193), new Quaternion(0, 90, 0, 0));

    }
    public void c1_new_most()
    {
        Instantiate(c1_most, new Vector3(203, 0, 193), new Quaternion(0, 90, 0, 0));
    }
    public void d1_new_most()
    {
        Instantiate(d1_most, new Vector3(203, 0, 193), new Quaternion(0, 90, 0, 0));
    }

    public void Initialization_Tike(int x) {
        //x = 第幾項任務修改
        a.Add(new Task_Condition("主線任務1-暖暖身子吧，使者", 0, 10, Image));
        TaskData1 TD1 = new TaskData1("主線任務1-暖暖身子吧，使者", "去村莊外頭，解決掉十隻怪物。回來找康德對話", a[0]);
        //參考格式

        task.BT[x].Name = TD1._TaskName;
        task.BT[x].Description = TD1._Description;
        task.BT[x].Conditions = a;

    }

}

//-1509794 
//