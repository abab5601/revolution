using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour {
    public Task task;
    public User user;

	// Use this for initialization
	void Start () {
        if (task == null || user == null)
            Debug.LogError("任務系統未放入資料庫");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
