using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuch : MonoBehaviour {

    Animator anim;
    Animation add;
    public BLMFOD_1 test;
    public TaskData task;
    public int HP;
    public bool haha;
    //布魯姆菲爾德 = BLMFOD

    void Start()
    {
            
        anim = GetComponent<Animator>();
        add = GetComponent<Animation>();
        test = GetComponent<BLMFOD_1>();
        HP = 10;
    }

    public void OnCollisionEnter(Collision collision)
    {

        //status: 0=休息1=走2=跑3=受傷4=死亡
        if (collision.gameObject.name == "E_user__")
        {

            if (task.BT[0].Schedule == 2)
            {
                //任務2
                if (task.BT[1].Schedule == 0)
                {
                    test.XLL(0);
                    task.BT[1].Schedule = 1;


                }
                else if (task.BT[1].Conditions[0].Currently >= task.BT[0].Conditions[0].Max)
                {
                    test.XLL(2);
                    task.BT[1].Schedule = 2;
                }
                else if (task.BT[1].Schedule == 1)
                {
                    test.XLL(1);
                    task.BT[1].Schedule = 1;

                }
            }
            else {
                test.dd();
            }
        }



    }


}
