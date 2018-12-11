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

    public Animator anim;

    int Mobile_status;

    public User User;//資料庫
    public World world;
    public Article_inventory Article_i;//武器資料庫
    private bool Jump = false;//是否正在跳


    private float high, high_up;//高


    void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    private void Awake()
    {
        // gameObject.transform.position = transfom.position;//+new Vector3(0,User.ability.jump,0);// new Vector3(User.XY.X, User.XY.Y, User.XY.Z);
    }


    void Update()
    {
        #region 玩家跳躍高度檢查
        if (transform.position.y > high_up)
            high_up = transform.position.y;
        else if (transform.position.y < high)
            high = transform.position.y;

        #endregion
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
        float mobile, jump, mobile_, jump_;
        bool Stun;
        mobile = 0f;
        jump = 0f;
        mobile_ = 0f;
        jump_ = 0f;
        Stun = false;
        for (int i = 0; i < User.Ctrl.Length; i++)
        {
            User.Ctrl[i].time -= Time.deltaTime;
            if (User.Ctrl[i].time <= 0)
            {
                var temp = new List<User.control>(User.Ctrl);
                temp.RemoveAt(i);
                User.Ctrl = temp.ToArray();
                continue;
            }
            switch (User.Ctrl[i].mod)
            {
                case User.MOD.mobile:

                    if (User.Ctrl[i].value > 0 && User.Ctrl[i].value >= mobile) mobile = User.Ctrl[i].value;
                    else if (User.Ctrl[i].value <= mobile_) mobile_ = User.Ctrl[i].value;
                    // if (User.Ctrl[i].time < 3) User.Ctrl[i].value = User.Ctrl[i].value = User.Ctrl[i].value *( User.Ctrl[i].time/10);想做線性緩速不要瞬間時間剩3秒時慢慢把值-至0

                    break;
                case User.MOD.jump:

                    if (User.Ctrl[i].value > 0 && User.Ctrl[i].value >= jump) jump = User.Ctrl[i].value;
                    else if (User.Ctrl[i].value <= mobile_) jump_ = User.Ctrl[i].value;

                    break;
                case User.MOD.Stun:
                    Stun = true;
                    break;
                case User.MOD.HP:
                    if ((User.Hp.Hp + User.Ctrl[i].value) > 0) User.Hp.Hp += User.Ctrl[i].value;
                    else User.Hp.Hp = 0;
                    break;
                case User.MOD.MP:
                    if ((User.Mp.Mp + User.Ctrl[i].value) > 0) User.Mp.Mp += User.Ctrl[i].value;
                    else User.Mp.Mp = 0;
                    break;
            }
        }
        if ((mobile_ * -1) > mobile) mobile = 0f;
        else mobile = mobile - mobile_;
        if ((jump_ * -1) > jump) jump = 0f;
        else jump = jump - jump_;
        User.ability.mobile = ((world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + mobile) > world.Basic.value[0] ? (world.Ability * (User.talent[0] + world.Career[(int)User.user.Mod].value[0])) + mobile : world.Basic.value[0];/*天賦*/
          User.ability.jump = ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + jump) > world.Basic.value[1] ? ((world.jump * (User.talent[1] + world.Career[(int)User.user.Mod].value[1])) + jump) : (world.jump * User.talent[1] + jump);/*天賦*/
        User.ability.Stun = Stun;
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
    void OnCollisionEnter(Collision collision)//碰狀
    {
        Jump = false;//沒有在跳
        if (high_up - high >= world.high && high_up - high >= User.ability.jump)
        {

            Debug.Log(high_up - high);
            HP(-(((high_up - high - world.high) / world.high_up)) * world.high_hp);

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        #region 高度計算
        high = transform.position.y;
        high_up = transform.position.y;
        #endregion
    }


    public void HP(float HP)
    {
        User.Hp.Hp += HP;
    }//HP變更
    public void MP(float MP)
    {
        User.Mp.Mp += MP;
    }//MP變更
    public void ctrl(User.control[] control)
    {
        var temp = new List<User.control>(User.Ctrl);
        foreach (User.control I in control)
            temp.Add(I);
        User.Ctrl = temp.ToArray();

    }//控制增加



   
}



