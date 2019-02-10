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

    public User User;//資料庫
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
    }
    private void Awake()
    {
        biologicaSystem = GetComponent<BiologicaSystem>();
        biologicaSystem.HP = User.Hp;
        biologicaSystem.MP = User.Mp;
        biologicaSystem.Control = User.Ctrl;
        // gameObject.transform.position = transfom.position;//+new Vector3(0,User.ability.jump,0);// new Vector3(User.XY.X, User.XY.Y, User.XY.Z);
    }


    void Update()
    {
        User.Hp = biologicaSystem.HP;
        User.Mp = biologicaSystem.MP;
        User.Ctrl = biologicaSystem.Control;
        #region 玩家位置資料庫更新
        User.XY.X = transform.position.x;
        User.XY.Y = transform.position.y;
        User.XY.Z = transform.position.z;
        #endregion
        
        User.ability.mobile = ((world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + biologicaSystem.ability.mobile) > world.Basic.value[0] ? (world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + biologicaSystem.ability.mobile : world.Basic.value[0];/*天賦*/
          User.ability.jump = ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + biologicaSystem.ability.jump) > world.Basic.value[1] ? ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + biologicaSystem.ability.jump) : (world.jump * User.talent[1] + biologicaSystem.ability.jump);/*天賦*/
        biologicaSystem.nowability.jump = User.ability.jump;
        User.ability.Stun = biologicaSystem.ability.Stun;
        if (biologicaSystem.HP.Hp <= 0)
        {
            User.conversation.Add(
                new USER_initial.Conversation_format("系統 : 你已死亡\n將會把你所有錢歸0做懲罰", null, null, null, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255)));
            biologicaSystem.HP.Hp = biologicaSystem.HP.Hpmax;
        }
    }
    public void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) || User.jump)
        {
            if (Jump == false)
            {
                rigidbody.velocity += new Vector3(0, User.ability.jump, 0);
                rigidbody.AddForce(Vector3.up * User.ability.jump);
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
        velocity *= User.ability.mobile;       // 移動速度を掛ける
        velocity.y = rigidbody.velocity.y;
        // 上下のキー入力でキャラクターを移動させる
        rigidbody.velocity = velocity;

        //        rigidbody.MovePosition(transform.position+( velocity * Time.fixedDeltaTime));


        #endregion
    }





}



