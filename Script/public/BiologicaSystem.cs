using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiologicaSystem : MonoBehaviour {

    //請先設定MAX HP 
    //腳本在初始化時 生物 HP = 腳本內的MAX HP
    public User user;
    public World world;
    public Article_inventory article_Inventory;
    public User.USER USER_DATA;
    [Header("腳色大小")]
    public Vector3 size;
    public User.HP HP;
    public User.MP MP;
    public User.money money;
    public List<User.control> Control;
    public List<User.Backpack> Backpacks;
    public List<User.anim> Anim;
    public BoxCollider Collider;
    public bool Invincible = false;//無敵//血量&&死亡都不會
    public bool NotControl = false;//控制效果//免控期間免除所有負面效果但還是會接收所有效果//免控結束會回復正常在免控其所承受的效果,時效未過會復發
    public int resurrection = 0;//復活//復活後value -= 1 // HP && MP = MAX, 控制效果會完全移除(包誇正向)
    public float ResurrectionTime ;//復活倒數時間//預設為DATA裡的值
    public Transform L_T, R_T, L_B, R_B;//左右手,左右腿
    [Header("附近物件")]
    public List<Transform> nearby_obj;
    void Start () {
        GameObject obj = new GameObject("collider");
        obj.transform.parent = transform;
        obj.transform.localPosition= new Vector3(0, 0, 0);
        Collider = obj.AddComponent<BoxCollider>();
        Collider.size = new Vector3(world.range + size.x, size.y, world.range + size.z);
        Collider.isTrigger = true;
        obj.AddComponent<BoxColliderSystem>().BiologicaSystem = gameObject.GetComponent<BiologicaSystem>();
	}
    private void OnEnable()
    {
        ResurrectionTime = world.ResurrectionTime;//倒計時初始化
    }
    private void Update()
    {
        if(HP.Hp<HP.Hpmax)
        {
            if (HP.Hp <= 0 && tag != "Player"/*玩家*/&& tag != "Invincible"/*無敵*/&& !Invincible)//死亡判斷
                if (resurrection > 0)
                {
                    GameObject NEW = new GameObject(name);
                    DeathTreatment X = NEW.AddComponent<DeathTreatment>();
                    X.time = ResurrectionTime;
                    X.BiologicaSystem = GetComponent<BiologicaSystem>();
                    resurrection--;//命-1
                    gameObject.SetActive(false);
                }
                else//缺死亡判斷
                {
                    world.DeathNotebook.Add(gameObject.GetInstanceID());
                    Destroy(gameObject);//HP沒了死亡
                }
        }
    }


    //開發者使用 API 以下為 Function 
    /// <summary>
    /// 變動血量
    /// </summary>
    /// <param name="HP">變動血量數值</param>
    public void hp(int HP)
    {
        if ((!Invincible && HP < 0) || HP > 0)
            this.HP.Hp += HP;
    }
    /// <summary>
    /// 變動魔力
    /// </summary>
    /// <param name="HP">變動魔力數值</param>
    public void mp(int MP)
    {
        this.MP.Mp += MP;
    }
    /// <summary>
    /// 控制
    /// </summary>
    /// <param name="control">控制資料</param>
    /// /// <param name="OUT">增加 = true 減少 = false </param>
    public void control(List<User.control> control,bool OUT)
    {
        if (OUT)
            this.Control.AddRange(control);
        else
            foreach (User.control dl in control)
                this.Control.Remove(dl);
    }
    /// <summary>
    /// 撿起/丟掉 物品
    /// </summary>
    /// <param name="backpack">物品DATA</param>
    /// <param name="OUT">增加 = true 減少 = false </param>
    public void backpack(List<User.Backpack> backpack, bool OUT)
    {
        if (OUT)
            this.Backpacks.AddRange(backpack);
        else
            foreach (User.Backpack dl in backpack)
                this.Backpacks.Remove(dl);
    }
    /// <summary>
    /// 學習/遺忘 動作
    /// </summary>
    /// <param name="anim">動作</param>
    /// <param name="OUT">增加 = true 減少 = false </param>
    public void anim(List<User.anim> anim, bool OUT)
    {
        if (OUT)
            this.Anim.AddRange(anim);
        else
            foreach (User.anim dl in anim)
                this.Anim.Remove(dl);
    }
    /// <summary>
    /// 錢
    /// </summary>
    /// <param name="money">金額</param>
    public void Money(User.money money)
    {
        this.money.copper += money.copper;
        this.money.gold += money.gold;
        this.money.silver += money.silver;
    }
}
