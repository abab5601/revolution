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
    public Task task;

    int Mobile_status;

    public User User;//資料庫
    public World world;
    public Article_inventory Article_i;//武器資料庫
    private bool Jump = false;//是否正在跳

    void OnCollisionEnter(Collision collision)//碰狀
    {
        Jump = false;//沒有在跳
    }


        void Start()
    {
        anim = this.GetComponent<Animator>();
        biologicaSystem = GetComponent<BiologicaSystem>();
    }
    private void Awake()
    {
        // gameObject.transform.position = transfom.position;//+new Vector3(0,User.ability.jump,0);// new Vector3(User.XY.X, User.XY.Y, User.XY.Z);
    }


    void Update()
    {
        User.Hp = biologicaSystem.HP;
        User.Mp = biologicaSystem.MP;
        #region 玩家位置資料庫更新
        User.XY.X = transform.position.x;
        User.XY.Y = transform.position.y;
        User.XY.Z = transform.position.z;
        #endregion
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
        else {
            anim.SetBool("Mobile_", false);
        }
        Vector3 velocity = new Vector3(h, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
                                                // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);
        //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
        velocity *= User.ability.mobile;       // 移動速度を掛ける
        // 上下のキー入力でキャラクターを移動させる
        transform.localPosition += velocity * Time.fixedDeltaTime;

        #endregion
        User.ability.mobile = ((world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + biologicaSystem.ability.mobile) > world.Basic.value[0] ? (world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + biologicaSystem.ability.mobile : world.Basic.value[0];/*天賦*/
          User.ability.jump = ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + biologicaSystem.ability.jump) > world.Basic.value[1] ? ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + biologicaSystem.ability.jump) : (world.jump * User.talent[1] + biologicaSystem.ability.jump);/*天賦*/
        User.ability.Stun = biologicaSystem.ability.Stun;
    }
    public void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) || User.jump)
        {
            if (Jump == false)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0, User.ability.jump, 0);
                GetComponent<Rigidbody>().AddForce(Vector3.up * User.ability.jump);
                Jump = true;

            }
        }

    }


    public void ctrl(User.control[] control)
    {
        var temp = new List<User.control>(User.Ctrl);
        foreach (User.control I in control)
            temp.Add(I);
        User.Ctrl = temp.ToArray();

    }//控制增加



   
}



