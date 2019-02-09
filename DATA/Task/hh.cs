using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hh : MonoBehaviour,ITask {


    /// <summary>
    /// 任務名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 任務說明
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 任務達成條件
    /// </summary>
    public List<Task_Condition> Conditions { get; set; }
    /// <summary>
    /// 是否UI開放一鍵引導任務
    /// </summary>
    /// <returns>呼叫Task_Start 權限</returns>
    public bool Task_start_bool() { return true; }
    /// <summary>
    /// 任務開始
    /// </summary>
    public void Task_Start() { }
    /// <summary>
    /// 任務一鍵引導
    /// </summary>
    /// <param name="open">一件引導關閉開啟</param>
    public void Task_Go(bool open) { }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
