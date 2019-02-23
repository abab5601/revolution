using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
/// <summary>
/// 玩家用 script
/// </summary>
public class player : MonoBehaviour
{
    private Coroutine cououtine;
    //user 動畫
    //public GameObject user_;
    private BiologicaSystem biologicaSystem;
    public Animator anim;
    public TaskData1 task;

    int Mobile_status;

    public User user;//資料庫
    public World world;
    public Article_inventory Article_i;//武器資料庫
    private bool Jump = false;//是否正在跳
    private Rigidbody rigidbody;
    public Vector3 tt;
    void OnCollisionEnter(Collision collision)//碰狀
    {
        Jump = false;//沒有在跳
    }


    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        do
        {
            biologicaSystem = GetComponent<BiologicaSystem>();
            Debug.Log(true);
        } while (biologicaSystem == null);



        biologicaSystem.HP = user.Hp;
        biologicaSystem.MP = user.Mp;
        biologicaSystem.Control = user.Ctrl;
        biologicaSystem.HpUp = user.HpUp;
        biologicaSystem.MpUp = user.MpUp;

    }
    private void Awake()
    {
        gameObject.transform.position = world.Rebirth_point[(int)user.XY.map];//+new Vector3(0,user.ability.jump,0);// new Vector3(user.XY.X, user.XY.Y, user.XY.Z);
        
     
    }


    void Update()
    {

        if (user.user.experience >= (user.user.LV * world.LV_TO_UP) + world.LV_UP)
        {
            user.user.experience -= (user.user.LV * world.LV_TO_UP) + world.LV_UP;
            user.user.LV++;
        }
        user.Hp = biologicaSystem.HP;
        user.Mp = biologicaSystem.MP;
        user.Ctrl = biologicaSystem.Control;
        #region 玩家位置資料庫更新
        user.XY.X = transform.position.x;
        user.XY.Y = transform.position.y;
        user.XY.Z = transform.position.z;
        #endregion
        user.ability.mobile = (((user.talent[0] + world.Career[(int)user.user.Mod].value[0])) + biologicaSystem.ability.mobile) > world.Basic.value[0] ? (world.Ability * (user.talent[0] + world.Career[(int)user.user.Mod].value[0])) + biologicaSystem.ability.mobile : world.Basic.value[0]* world.Ability;/*天賦*/

         user.ability.jump = 
            (
            ((user.talent[1] + world.Career[(int)user.user.Mod].value[1])) + biologicaSystem.ability.jump) > world.Basic.value[1] ? ((world.jump * (user.talent[1] + world.Career[(int)user.user.Mod].value[1])) + biologicaSystem.ability.jump) : (world.jump * world.Basic.value[1]);/*天賦*/
        biologicaSystem.nowability.jump = user.ability.jump;    //                                                                                       10               0                         1                                         0                                                                       
        user.ability.Stun = biologicaSystem.ability.Stun;
        if (transform.position.y <= -1000)
        {
            transform.position = world.Rebirth_point[(int)user.XY.map];
            
        }
        if (biologicaSystem.HP.Hp <= 0)
        {
            if (user.conversation.Count != 0) {
                if (user.conversation[0].String != "系統 : 你已死亡\n將會把你所有錢歸0做懲罰")
                    user.conversation.Insert(0,
     new USER_initial.Conversation_format("系統 : 你已死亡\n將會把你所有錢歸0做懲罰", null, null, null, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255)));

            }
            else
                user.conversation.Add(
     new USER_initial.Conversation_format("系統 : 你已死亡\n將會把你所有錢歸0做懲罰", null, null, null, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255)));
            user.Money = new USER_initial.money(0, 0, 0);
            biologicaSystem.HP.Hp = biologicaSystem.HP.Hpmax;
        }
    }
    public void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) || user.jump)
        {
            if (Jump == false)
            {

                rigidbody.velocity += new Vector3(0, user.ability.jump, 0);
                rigidbody.AddForce(Vector3.up * user.ability.jump);
                Jump = true;

            }
        }
        #region 移動
        float h = SimpleInput.GetAxis("Horizontal");              // 入力デバイスの水平軸をhで定義
        float v = SimpleInput.GetAxis("Vertical");                // 入力デバイスの垂直軸をvで定義

        // 以下、キャラクターの移動処理
        if (h != 0 || v != 0)
        {

            anim.SetBool("Mobile_", true);

            anim.SetFloat("Mobile_H", h);
            anim.SetFloat("Mobile_V", v);
        }
        else
        {
            anim.SetBool("Mobile_", false);
        }
        Vector3 velocity = new Vector3(h, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
                                                        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);
        //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
        velocity *= user.ability.mobile;       // 移動速度を掛ける
        velocity.y = rigidbody.velocity.y;
        // 上下のキー入力でキャラクターを移動させる
        rigidbody.velocity = velocity;
        tt = velocity;

        //        rigidbody.MovePosition(transform.position+( velocity * Time.fixedDeltaTime));


        #endregion
    }





}



