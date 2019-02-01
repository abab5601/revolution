using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class monster_code : MonoBehaviour {
    //trackAI
    private BiologicaSystem biologicaSystem;
    private Rigidbody con;
    public  Transform hero;
    Animator ani;


    //Judging Distance
    public float followDis = 10f;
    public float attackDis = 2f;

    //Time
    public float thinkTime = 3f;
    public float currentThinkTime = 0f;

    public float walkTime = 5f;
    public float currentWalkTime = 0;

    //Attact Records 
    public bool isAttact = false;



    void Start () {
        biologicaSystem = GetComponent<BiologicaSystem>();
        con = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }



    void Update () {
        if (biologicaSystem.nearby_obj.Count>0)
        {
            hero = biologicaSystem.nearby_obj[0];
        }
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
                ani.SetInteger("Attack", 0 );
                ani.SetInteger("Walk", 1    );
                Vector3 dierction = transform.TransformDirection(Vector3.forward);
                transform.position += (dierction * 1f * Time.deltaTime);
            }
            else//小于攻击距离后开始攻击
            {

                ani.SetInteger("Walk", 0);
                isAttact = true;
                ani.SetInteger("Attack", 1);
            }

        }
    }

    void Think() {

        if (!isAttact)//如果不攻击，就开始走

        {
            ani.SetInteger("Attack", 0);
            currentWalkTime += Time.deltaTime;//开始记录走的时间
            if (currentWalkTime >= walkTime)
            {//当走的时间大于设定的时间时
                ani.SetInteger("Walk", 0);
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
                ani.SetInteger("Walk", 1);
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                transform.position += (direction * 1f * Time.deltaTime);
            }
        }


    }







    // HP method ##



}