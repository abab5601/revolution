using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region 引入
    [System.Serializable]
    public class Display_backpack : UnityEvent<int> { }
    [System.Serializable]
    public class Display : UnityEvent<int, string, float, GameObject> { }

    public User user;//資料庫
    public Article_inventory article_Inventory;
    public World world;
    public GridLayoutGroup LayoutGroup;//選單
    public Text NAME, NAME2, Description, bounce_text, Throw;//名字大,名字小,說明,彈跳介面(說明文字),丟掉
    public Image image;//圖片
    public RawImage rawImage;
    public Scrollbar Bounce_Scrollbar;//彈跳介面
    public Toggle[] toggle;//0資料,1攻擊力 消耗,2故事背景,3取得處,4放入背包,5使用道具,6丟掉,7道具效果,8 null,9道具說明,10防具說明 ,11放入道具欄
    public Toggle[] skill_button=new Toggle[14];//更新啟用狀態*控制剩餘8的啟用狀態
    public GameObject UI, Bounce, Bounce_cancel, Bounce_determine, My_Camera, skill, lr_Windows;//背包,彈跳介面(0放入背包,1使用道具,2丟掉),彈跳介面(取消),彈跳介面(確定),攝影機,技能放置視窗,選擇左右手彈跳視窗
    private GameObject Object;//實體物件
    private int Array, backpack_ID = -1, Bounce_int = -1;//陣列位置,背包內Array,彈跳視窗狀態(0放入背包{可重疊},1放入背包{不可重疊},2放入背包{不放入背包})
    private User.Backpack Data;
    private User.anim Anim_Data;
    private string GameObject_name;//物品名字
    private bool UI_bool;//背包內物品
    public bool anim = false;//模式切換//道具模式=true//動畫模式=false;

    #endregion
    /// <summary>
    /// 背包內
    /// </summary>
    /// <param name="Array">背包內陣列位置</param>
    public void display(int Array)
    {
        anim = true;
        this.backpack_ID = Array;//背包內陣列位置
        var data = new List<Article_inventory.Commodity>(article_Inventory.commodity);
        this.Array = data.FindIndex(x => x.ID == user.backpack[Array].ID);
        UI_bool = true;//在背包內
        NAME.text = user.backpack[Array].Name == "" ? article_Inventory.commodity[this.Array].Name : user.backpack[Array].Name;//物品名字
        NAME2.text = user.backpack[Array].Name == "" ? "" : article_Inventory.commodity[Array].Name;
        Data = user.backpack[Array];
        image.sprite = article_Inventory.commodity[this.Array].image;
        OnEnable();
        Reset();
        Toggle_ckicl(0);
    }//OK
    /// <summary>
    /// 背包外
    /// </summary>
    /// <param name="Array">物品Array</param>
    /// <param name="name">物品名字</param>
    /// <param name="Consumption">剩餘耐久度</param>    
    /// <param name="Quantity"></param>
    /// <param name="gameObject">遊戲物件</param>
    public void display(User.Backpack Data, GameObject gameObject)
    {
        anim = true;
        this.Data = Data;//物品Array
        var data = new List<Article_inventory.Commodity>(article_Inventory.commodity);
        this.Array = data.FindIndex(x => x.ID == Data.ID);
        NAME.text = this.Data.Name == "" ? article_Inventory.commodity[Array].Name : this.Data.Name;//物品名字
        NAME2.text = this.Data.Name == "" ? "" : article_Inventory.commodity[Array].Name;
        Object = gameObject;//遊戲物件
        image.sprite = article_Inventory.commodity[this.Array].image;
        UI_bool = false;
        Reset();
        Toggle_ckicl(0);
    }//OK
    /// <summary>
    /// 背包內
    /// </summary>
    /// <param name="Array"></param>
    public void Anim(int Array)
    {
        anim = false;
        this.backpack_ID = Array;
        var data = new List<Article_inventory.Animation>(article_Inventory.animation);
        this.Array = data.FindIndex(x => x.ID == user.Anim[Array].ID);
        NAME.text = user.Anim[Array].Name == "" ? article_Inventory.animation[Array].Name : Data.Name;//物品名字
        NAME2.text = user.Anim[Array].Name == "" ? "" : article_Inventory.animation[Array].Name;
        UI_bool = true;//在背包內
        Anim_Data = user.Anim[Array];
        Reset();
        Toggle_ckicl(0);
    }//OK
    /// <summary>
    /// 背包外
    /// </summary>
    /// <param name="Array"></param>
    public void Anim(User.anim Data, GameObject gameObject)
    {
        anim = false;
        this.backpack_ID = Array;
        var data = new List<Article_inventory.Animation>(article_Inventory.animation);
        this.Array = data.FindIndex(x => x.ID == Data.ID);
        UI_bool = true;//在背包內
        Anim_Data = Data;
        Reset();
        Toggle_ckicl(0);
    }//OK
    /// <summary>
    /// 復位
    /// </summary>
    private void OnEnable()
    {
        toggle[0].isOn = true;
        skill.SetActive(false);
    }//OK
    /// <summary>
    /// 初始化
    /// </summary>
    private void Reset()
    {
        if (anim)
        {
            image.gameObject.SetActive(true);
            rawImage.gameObject.SetActive(false);
            Bounce.SetActive(false);
            toggle[0].gameObject.SetActive(true);//0資料
            toggle[1].gameObject.SetActive(
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.dagger ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.claw ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.bow ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.gun ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.Staff ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.sword
                );//1攻擊力 消耗
            toggle[2].gameObject.SetActive(true);//2故事背景
            toggle[3].gameObject.SetActive(true);//3取得處
            toggle[4].gameObject.SetActive(!UI_bool && article_Inventory.commodity[Array].place.backpack);//4放入背包
            toggle[5].gameObject.SetActive(article_Inventory.commodity[Array].classification == Article_inventory.Classification.Prop ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.food);//5使用道具
            toggle[6].gameObject.SetActive(UI_bool && article_Inventory.commodity[Array].place.Throw);//6丟掉
            Throw.text = "丟掉";
            toggle[7].gameObject.SetActive(article_Inventory.commodity[Array].classification == Article_inventory.Classification.Prop ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.food);//7道具效果
            toggle[9].gameObject.SetActive(article_Inventory.commodity[Array].classification == Article_inventory.Classification.Prop ||
            article_Inventory.commodity[Array].classification == Article_inventory.Classification.food);//9道具說明
            toggle[10].gameObject.SetActive(article_Inventory.commodity[Array].classification == Article_inventory.Classification.head ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.body ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.leg ||
                article_Inventory.commodity[Array].classification == Article_inventory.Classification.foot);//10防具說明
            toggle[11].gameObject.SetActive(UI_bool &&
                (
                article_Inventory.commodity[Array].place.right ||/*右手*/
                article_Inventory.commodity[Array].place.left ||/*左手*/
                article_Inventory.commodity[Array].place.head ||/*頭*/
                article_Inventory.commodity[Array].place.body ||/*身體*/
                article_Inventory.commodity[Array].place.leg ||/*腿*/
                article_Inventory.commodity[Array].place.foot ||/*腳*/
               article_Inventory.commodity[Array].place.Ring ||/*戒指*/
               article_Inventory.commodity[Array].place.necklace ||/*項鍊*/
               article_Inventory.commodity[Array].place.gloves ||/*手套*/
               article_Inventory.commodity[Array].place.Special_props/*特殊道具*/
                )
                );//11放入道具欄
         
        }//道具
        else
        {
            image.gameObject.SetActive(false);
            rawImage.gameObject.SetActive(true);
            toggle[0].gameObject.SetActive(true);//0資料
            toggle[1].gameObject.SetActive(false);
            toggle[2].gameObject.SetActive(true);//2故事背景
            toggle[3].gameObject.SetActive(true);//3取得處
            toggle[4].gameObject.SetActive(!UI_bool && (article_Inventory.animation[Array].place.prop || article_Inventory.animation[Array].place.Special_props));//4放入背包
            toggle[5].gameObject.SetActive(false);
            toggle[6].gameObject.SetActive(UI_bool && article_Inventory.animation[Array].place.Throw);//5忘記
            Throw.text = "忘記";
            toggle[7].gameObject.SetActive(false);
            toggle[8].gameObject.SetActive(false);
            toggle[9].gameObject.SetActive(false);
            toggle[10].gameObject.SetActive(false);
            toggle[11].gameObject.SetActive(UI_bool && article_Inventory.animation[Array].place.prop);//11放入道具欄
            
        }//動畫
    }//OK
    /// <summary>
    /// 選項陣列ID
    /// </summary>
    /// <param name="Array"></param>
    public void Toggle_ckicl(int ID)
    {
        if (anim)
        {
            if (toggle[ID].isOn)
                switch (ID)
                {
                    #region 0 基本資料
                    case 0:
                        Description.text =
                            "道具分類 : " + article_Inventory.Classification_Zh[(int)article_Inventory.commodity[this.Array].classification] +
                            "\n耐久 : " + (article_Inventory.commodity[this.Array].durable != -1 ? Data.Consumption.ToString() + "/" + article_Inventory.commodity[this.Array].durable.ToString() : "∞") +
                            "\n冷卻時間 : " + article_Inventory.commodity[this.Array].time +
                            "\n等級需求 : " + (article_Inventory.commodity[this.Array].LV ? article_Inventory.commodity[this.Array].Level_limit.ToString() : "無") +
                            "\n力量需求 : " + (article_Inventory.commodity[this.Array].power ? article_Inventory.commodity[this.Array].power_limit.ToString() : "無") +
                            "\n敏捷需求 : " + (article_Inventory.commodity[this.Array].agile ? article_Inventory.commodity[this.Array].agile_limit.ToString() : "無") +
                            "\n智慧需求 : " + (article_Inventory.commodity[this.Array].wisdom ? article_Inventory.commodity[this.Array].wisdom_limit.ToString() : "無") +
                            "\n稀有度 : " + article_Inventory.commodity[this.Array].rare +
                            "\n" + (article_Inventory.commodity[this.Array].place.backpack ?
                            "\n可使用部位 :" +
                            "\n" +
                            (article_Inventory.commodity[this.Array].place.right || article_Inventory.commodity[this.Array].place.left ? "\n" : "") +
                            (article_Inventory.commodity[this.Array].place.right ? "\r右手   " : "") +
                            (article_Inventory.commodity[this.Array].place.left ? "\r左手   " : "") +
                            (article_Inventory.commodity[this.Array].place.head || article_Inventory.commodity[this.Array].place.body || article_Inventory.commodity[this.Array].place.leg || article_Inventory.commodity[this.Array].place.foot ? "\n" : "") +
                            (article_Inventory.commodity[this.Array].place.head ? "\r頭飾  " : "") +
                            (article_Inventory.commodity[this.Array].place.body ? "\r衣服  " : "") +
                            (article_Inventory.commodity[this.Array].place.leg ? "\r褲子  " : "") +
                            (article_Inventory.commodity[this.Array].place.foot ? "\r鞋子  " : "") +
                             (article_Inventory.commodity[Array].place.Ring ? "\n \r戒指 " : "") +
           (article_Inventory.commodity[this.Array].place.necklace ? " \r項鍊 " : "") +
            (article_Inventory.commodity[this.Array].place.gloves ? " \r手套 " : "") +
            (article_Inventory.commodity[this.Array].place.Special_props ? " \r特殊道具 " : "")
                            :
                            "此物品不可放入背包") +
                            ((article_Inventory.commodity[this.Array].place.box ? "\n可放入物品箱" : "物品不可放入箱子") +
                            ((article_Inventory.commodity[this.Array].place.Throw ? "" : "物品不可丟掉")));
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion//OK
                    #region 1 攻擊力 消耗
                    case 1:
                        Description.text =
                            "主動攻擊 : \n" +
                            article_Inventory.commodity[this.Array].initiative_Attack_method +
                            "\n\n被動攻擊 : " +
                            article_Inventory.commodity[this.Array].passive_Attack_method;



                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 2 背景故事
                    case 2:
                        Description.text = "道具背景故事 :\n" + article_Inventory.commodity[this.Array].story;
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperCenter;
                        break;
                    #endregion
                    #region 3 取得處
                    case 3:
                        Description.text = "取得處:";
                        if (article_Inventory.commodity[this.Array].origin.Length <= 0)
                            Description.text += "GM太懶沒有寫";
                        else
                            foreach (string I in article_Inventory.commodity[this.Array].origin)
                                Description.text += I + "\n";
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 4 放入背包
                    case 4:
                        backpack_ID = -1;
                        int i = 0;
                        Bounce.SetActive(true);
                        Bounce_Scrollbar.gameObject.SetActive(false);
                        foreach (User.Backpack obj in user.backpack)
                        {

                            if (obj.ID == this.Data.ID)//找到物品
                                if (obj.Quantity < world.Cumulative_quantity/*加疊數量上限*/&& article_Inventory.commodity[obj.ID].overlapping/*可否重疊*/&& (article_Inventory.commodity[obj.ID].durable != -1 ? obj.Consumption == article_Inventory.commodity[obj.ID].durable : true)/*耐久*/&& obj.Name == NAME2.text/*名字一樣*/)
                                {
                                    backpack_ID = i;
                                    break;
                                }

                            i++;
                        }//檢查加疊
                        if (backpack_ID != -1)
                        {
                            bounce_text.text = "物品 : " + (NAME2.text == "" ? article_Inventory.commodity[this.Array].Name : NAME2.text) + "放入背包\n此物品可以加疊";
                            Bounce_cancel.SetActive(true);
                            Bounce_determine.SetActive(true);
                            Bounce_Scrollbar.gameObject.SetActive(false);
                            Bounce_int = 0;
                        }//會有加疊多出意外
                        else if (user.backpack.Length < user.backpackMax)
                        {
                            bounce_text.text = "物品 : " + (NAME2.text == "" ? article_Inventory.commodity[this.Array].Name : NAME2.text) + "放入背包\n此物品不可以加疊,或以到加疊數量上限";
                            Bounce_cancel.SetActive(true);
                            Bounce_determine.SetActive(true);
                            Bounce_int = 1;
                        }
                        else if (user.backpack.Length >= user.backpackMax)
                        {
                            bounce_text.text = "無法放入背包\n背包已滿,請空出空間在試";
                            Bounce_determine.SetActive(true);
                            Bounce_cancel.SetActive(false);
                            Bounce_int = 2;
                        }
                        break;
                    #endregion
                    #region 5 使用道具
                    case 5:
                        Bounce.SetActive(true);
                        Bounce_Scrollbar.gameObject.SetActive(Data.Quantity != 1);
                        Bounce_Scrollbar.value = 0;
                        Bounce_cancel.SetActive(true);
                        Bounce_determine.SetActive(true);
                        bounce_text.text = "確定要使用?\n物品 : " + (NAME2.text == "" ? NAME.text : NAME2.text) + "\n" + (Data.Quantity != 1 ? "數量: 0" : "");
                        break;
                    #endregion
                    #region 6 丟掉
                    case 6:
                        Bounce.SetActive(true);
                        Bounce_Scrollbar.gameObject.SetActive(Data.Quantity != 1);
                        Bounce_Scrollbar.value = 0;
                        Bounce_cancel.SetActive(true);
                        Bounce_determine.SetActive(true);
                        bounce_text.text = "確定要丟掉?\n物品 : " + (NAME2.text == "" ? NAME.text : NAME2.text) + "\n" + (Data.Quantity != 1 ? "數量: 0" : "");
                        break;
                    #endregion
                    #region 7 道具效果
                    case 7:
                        Description.text = "道具效果 :\n" + article_Inventory.commodity[Array].initiative_Attack_method;
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 8 null

                    #endregion
                    #region 9 道具說明
                    case 9:
                        Description.text = "道具使用方式 :\n" + article_Inventory.commodity[Array].passive_Attack_method;
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 10 防具說明
                    case 10:
                        Description.text = "護甲簡介 :\n" + article_Inventory.commodity[Array].passive_Attack_method;
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 11 放入道具欄
                    case 11:
                        skill.SetActive(true);
                        Description.transform.parent.gameObject.SetActive(false);
                        skill_button[1].interactable = article_Inventory.commodity[Array].place.left;
                        skill_button[2].interactable = article_Inventory.commodity[Array].place.left;
                        skill_button[3].interactable = article_Inventory.commodity[Array].place.left;
                        skill_button[4].interactable = article_Inventory.commodity[Array].place.right;
                        skill_button[5].interactable = article_Inventory.commodity[Array].place.right;
                        skill_button[6].interactable = article_Inventory.commodity[Array].place.head;
                        skill_button[7].interactable = article_Inventory.commodity[Array].place.body;
                        skill_button[8].interactable = article_Inventory.commodity[Array].place.leg;
                        skill_button[9].interactable = article_Inventory.commodity[Array].place.foot;
                        skill_button[10].interactable = article_Inventory.commodity[Array].place.Ring;
                        skill_button[11].interactable = article_Inventory.commodity[Array].place.necklace;
                        skill_button[12].interactable = article_Inventory.commodity[Array].place.gloves;
                        skill_button[13].interactable = article_Inventory.commodity[Array].place.Special_props;
                        skill_button[(int)user.backpack[backpack_ID].skill>=5? (int)user.backpack[backpack_ID].skill-5: (int)user.backpack[backpack_ID].skill].isOn = true;
                        lr_Windows.SetActive(false);
                        break;
                        #endregion

                }
            if (!toggle[11].isOn)
            {
                skill.SetActive(false);
                Description.transform.parent.gameObject.SetActive(true);
            }
            My_Camera.SetActive(false);

        }
        else
        {
            if (toggle[ID].isOn)
                switch (ID)
                {
                    #region 0 基本資料
                    case 0:
                        Description.text = "動作分類 : ";
                        bool d = false;
                        foreach (Article_inventory.anim x in article_Inventory.animation[Array].anims)
                        {
                            Description.text += (d ? "/" : "") + x.ToString();
                            d = true;
                        }
                        Description.text +=
                            "\n冷卻時間 : " + article_Inventory.animation[this.Array].time +
                            "\n攻擊速度 : " + article_Inventory.animation[this.Array].time_play +
                            "\n等級需求 : " + (article_Inventory.animation[this.Array].LV ? article_Inventory.animation[this.Array].Level_limit.ToString() : "無") +
                            "\n力量需求 : " + (article_Inventory.animation[this.Array].power_limit != -1 ? article_Inventory.animation[this.Array].power_limit.ToString() : "無") +
                            "\n敏捷需求 : " + (article_Inventory.animation[this.Array].agile_limit != -1 ? article_Inventory.animation[this.Array].agile_limit.ToString() : "無") +
                            "\n智慧需求 : " + (article_Inventory.animation[this.Array].wisdom_limit != -1 ? article_Inventory.animation[this.Array].wisdom_limit.ToString() : "無") +
                            "\n可使用部位 :" +
                            (article_Inventory.animation[this.Array].place.prop ?
                            "道具欄"
                             :
                            "此物品不可使用") +
            (article_Inventory.animation[this.Array].place.Special_props ? " \r特殊道具 " : "") +

                            ((article_Inventory.animation[this.Array].place.Throw ? "" : "物品不可遺忘"));
                        Description.rectTransform.sizeDelta = new Vector2(Description.rectTransform.sizeDelta.x, Description.preferredHeight);
                        Description.transform.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
                        Description.alignment = TextAnchor.UpperLeft;
                        break;
                    #endregion
                    #region 2 故事背景
                    case 2:
                        Description.text = "故事背景 : " + (article_Inventory.animation[Array].story == "" ? "只有付款才能看到" : article_Inventory.animation[Array].story);
                        break;
                    #endregion
                    #region 3 取得處
                    case 3:
                        Description.text = "取得處";
                        foreach (string x in article_Inventory.animation[Array].origin)
                            Description.text += x;
                        if (article_Inventory.animation[Array].origin.Length == 0) Description.text += "GM太懶沒有寫";
                        break;
                    #endregion
                    #region 4 放入背包
                    case 4:
                        Bounce.SetActive(true);
                        Bounce_Scrollbar.gameObject.SetActive(false);
                        if (user.Anim_max < user.Anim.Length)
                        {
                            bounce_text.text = "動作 : " + (NAME2.text == "" ? article_Inventory.animation[this.Array].Name : NAME2.text) + "\n是否要學習?";
                            Bounce_cancel.SetActive(true);
                            Bounce_determine.SetActive(true);
                            Bounce_int = 1;
                        }
                        else
                        {
                            bounce_text.text = "無法學習\n技能學習已達上限,請選擇遺忘一個動作以學習新的技能";
                            Bounce_determine.SetActive(true);
                            Bounce_cancel.SetActive(false);
                            Bounce_int = 2;
                        }

                        break;
                    #endregion
                    #region 6 遺忘技能
                    case 6:
                        Bounce.SetActive(true);
                        Bounce_Scrollbar.gameObject.SetActive(false);
                        Bounce_cancel.SetActive(true);
                        Bounce_determine.SetActive(true);
                        bounce_text.text = "確定要遺忘?\n技能 : " + (NAME2.text == "" ? NAME.text : NAME2.text) + "?";

                        break;

                    #endregion
                    #region 11 放入道具欄
                    case 11:
                        skill.SetActive(true);
                        Description.transform.parent.gameObject.SetActive(false);
                        skill_button[1].interactable = article_Inventory.animation[Array].place.prop;
                        skill_button[2].interactable = article_Inventory.animation[Array].place.prop;
                        skill_button[3].interactable = article_Inventory.animation[Array].place.prop;
                        skill_button[4].interactable = article_Inventory.animation[Array].place.prop;
                        skill_button[5].interactable = article_Inventory.animation[Array].place.prop;
                        skill_button[6].interactable = false;
                        skill_button[7].interactable = false;
                        skill_button[8].interactable = false;
                        skill_button[9].interactable = false;
                        skill_button[10].interactable = false;
                        skill_button[11].interactable = false;
                        skill_button[12].interactable = false;
                        skill_button[13].interactable = false;
                        break;
                        #endregion

                }
            if (!toggle[11].isOn)
            {
                skill.SetActive(false);
                Description.transform.parent.gameObject.SetActive(true);
            }
            My_Camera.SetActive(true);


        }
        Bounce_Scrollbar.value = 0;
    }
    /// <summary>
    /// 背包位置更改
    /// </summary>
    /// <param name="Array"></param>
    public void skill_ck(int ID)
    {
        if (anim)
        {
            var data = new List<User.Backpack>(user.backpack);
            if (ID == -2)//右手
            {
                int d = data.FindIndex(a => a.skill == (User.Skill_)user.skill_edit);
                if (d != -1)
                    user.backpack[d].skill = 0;
                user.backpack[backpack_ID].skill = (User.Skill_)user.skill_edit;
            }
            else if (ID == -3)//左手
            {
                int d = data.FindIndex(a => a.skill == (User.Skill_)user.skill_edit + 5);
                if (d != -1)
                    user.backpack[d].skill = 0;
                user.backpack[backpack_ID].skill = (User.Skill_)user.skill_edit + 5;
            }
            else if (skill_button[ID].isOn)
            {

                int d = data.FindIndex(a => a.skill == (User.Skill_)ID);
                if (d != -1)
                    user.backpack[d].skill = 0;
                if (anim) user.backpack[backpack_ID].skill = (User.Skill_)ID;
                else user.Anim[backpack_ID].skill = (User.Skill_)ID;
            }
        }//物件
        else//動畫
        {
            var data = new List<User.anim>(user.Anim);
            if (skill_button[ID].isOn)
            {
                int d = data.FindIndex(a => a.skill == (User.Skill_)ID);
                if (d != -1)
                    user.Anim[d].skill = 0;
                if (anim) user.Anim[backpack_ID].skill = (User.Skill_)ID;
                else user.Anim[backpack_ID].skill = (User.Skill_)ID;
            }
        }
        lr_Windows.SetActive(false);
    }
    /// <summary>
    /// 彈跳介面呼叫
    /// </summary>
    public void bounce_button()
    {
        if (anim)
        {
            if (toggle[4].isOn)//4放入背包
                switch (Bounce_int)
                {
                    case 0://可加疊
                        user.backpack[backpack_ID].Quantity += Data.Quantity;
                        Destroy(Object);
                        gameObject.SetActive(false);
                        break;
                    case 1://不可加疊
                        var data = new List<User.Backpack>(user.backpack);
                        data.Add
                            (
                            new User.Backpack((NAME2.text == "" ? "" : NAME.text), this.Array, Data.Consumption, Data.Quantity, User.Skill_.No)
                            );
                        user.backpack = data.ToArray();
                        Destroy(Object);
                        gameObject.SetActive(false);
                        break;
                    case 2://不可放入背包
                        Bounce.SetActive(false);
                        break;
                }
            else if (toggle[6].isOn)
            {
                user.backpack[backpack_ID].Quantity -= (Data.Quantity != 1 ? (int)(Data.Quantity * Bounce_Scrollbar.value) : 1);
                if (user.backpack[backpack_ID].Quantity <= 0)
                {
                    var x = new List<User.Backpack>(user.backpack);
                    x.RemoveAt(backpack_ID);
                    user.backpack = x.ToArray();
                }
                GameObject game = GameObject.Instantiate(article_Inventory.commodity[Array].gameObject, new Vector3(user.XY.X, user.XY.Y, user.XY.Z + world.object_distance), new Quaternion(0, 0, 0, 0));
                game.GetComponent<Prop>().display(new User.Backpack((NAME2.text == "" ? "" : NAME2.text), Array, Data.Consumption, (int)(Data.Quantity != 1 ? Data.Quantity * Bounce_Scrollbar.value : 1), USER_initial.Skill_.No));//儲存細項
                gameObject.SetActive(false);
            }//6丟掉
        }
        else
        {
            if (toggle[4].isOn)
                switch (Bounce_int)
                {
                    case 1:
                        var data = new List<User.anim>(user.Anim);
                        data.Add
                            (
                            new User.anim(this.Anim_Data.Name, this.Anim_Data.ID, User.Skill_.No)
                            );
                        user.Anim = data.ToArray();
                        Destroy(Object);
                        gameObject.SetActive(false);
                        break;
                    case 2:
                        gameObject.SetActive(false);
                        break;

                }
            else if (toggle[6].isOn)
            {

                var x = new List<User.anim>(user.Anim);
                x.RemoveAt(backpack_ID);
                user.Anim = x.ToArray();
                Debug.LogError("動畫卷軸");
                gameObject.SetActive(false);
            }//6丟掉

        }
    }//OK
    /// <summary>
    /// 丟掉物品文字更新
    /// </summary>
    public void bounce_value()
    {
        if (anim)
        {
            if (toggle[6].isOn)
                bounce_text.text = "確定要丟掉?\n物品 : " + (NAME2.text == "" ? NAME.text : NAME2.text) + "\n" + (Data.Quantity != 1 ? "數量: " + (int)(Data.Quantity * Bounce_Scrollbar.value) : "數量 : 1");
        }

    }
    /// <summary>
    /// 關閉
    /// </summary>
    public void OnDisable()
    {
        if (UI_bool)
            UI.SetActive(true);
        My_Camera.gameObject.SetActive(false);
    }
    public void open(int ID)
    {
        if (anim) lr_Windows.SetActive(true);
        else skill_ck(ID);
    }

}