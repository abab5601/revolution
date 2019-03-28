using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskData1 : TaskBase {
    public TaskData1(string TaskName, string Description, Task_Condition TaskC) {
        this._TaskName = TaskName;
        this._Description = Description;
        this._TaskC = TaskC;

    }
    public string TaskName
    {
        get;set;
    }

    public string Description
    {
        get; set;
    }

    public Task_Condition TaskC_
    {
        get; set;
    }


}
