
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Task__touch : MonoBehaviour
{

    //0=主線任務 1=支線任務 2=及時任務            //UI參考用
    public TaskData ts;

    public void bt01() {
        ts.UI_number = 0;
    }
    public void bt02()
    {
        ts.UI_number = 1;
    }
    public void bt03()
    {
        ts.UI_number = 2;
    }


}
