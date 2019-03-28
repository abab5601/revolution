using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //trackAI
    Rigidbody con;
    public Transform hero;
    public AnimTouchAPI animapi;
    Animator ani;

    //Judging Distance
    float followDis = 10f;
    float attackDis = 2f;

    //Time
    float thinkTime = 3f;
    float currentThinkTime = 0f;

    float walkTime = 5f;
    float currentWalkTime = 0;

    //Attact Records 
    bool isAttact = false;

    //status: 0=休息1=走2=跑3=受傷4=死亡
    //fighting:0=休息11=攻擊12=攻擊13=攻擊

    void Start()
    {
        AnimTouchAPI animapi = GetComponent<AnimTouchAPI>();
        ani = GetComponent<Animator>();
        con = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Think();//思考
        Attack();//攻击
    }

    void Attack()
    {
        if (hero == null)
        {//如果英雄不存在直接返回
            return;
        }
        if (Vector3.Distance(transform.position, hero.position) <= followDis)//跟随距离
        {
            transform.LookAt(hero);

            if (Vector3.Distance(transform.position, hero.position) > attackDis)
            {

                isAttact = false;//大于攻击距离后不攻击
                animapi.animcon("status", 0);
                animapi.animcon("status", 1);
                Vector3 dierction = transform.TransformDirection(Vector3.forward);
                transform.position += (dierction * 1f * Time.deltaTime);
            }
            else//小于攻击距离后开始攻击
            {

                animapi.animcon("status", 0);
                isAttact = true;
                animapi.animcon("status", 11);
            }

        }
    }
    void Think()
    {

        if (!isAttact)//如果不攻击，就开始走

        {
            animapi.animcon("status", 0);
            currentWalkTime += Time.deltaTime;//开始记录走的时间
            if (currentWalkTime >= walkTime)
            {//当走的时间大于设定的时间时
                animapi.animcon("status", 0);
                currentThinkTime += Time.deltaTime;//记录思考的时间
                if (currentThinkTime >= thinkTime)
                {//当思考时间大于开始设定的时间时
                    currentWalkTime = 0f;
                    currentThinkTime = 0f;
                    float x = Random.Range(-1f, 1f);
                    float y = Random.Range(-1f, 1f);

                    transform.LookAt(transform.position + new Vector3(x, 0, y));//让怪物朝向一个随机的方向
                }

            }
            else
            {
                //当怪物走的时间
                animapi.animcon("status", 1);
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                transform.position += (direction * 1f * Time.deltaTime);
            }
        }
    }

}
