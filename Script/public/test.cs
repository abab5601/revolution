using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public BiologicaSystem hello;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void Awake()
    {
        hello = GetComponent<BiologicaSystem>();
        hello.HP.Hpmax = 100;
        Debug.Log(hello.user.XY.X);
        hello.hp(-10);
            
    }

}
