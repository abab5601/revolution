using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public GameObject home;
    public RapidBlurEffect rapidBlurEffect;
    public new GameObject gameObject;
    public Text text;
    public Image image,background;
    public Toggle buttons;
    public Toggle[] button=new Toggle[0];
    public User user;
    public World world;
    public bool CK,textGO;//確定回應
    int T = 0;
    float time = 0;

    // Use this for initialization

    void Start () {
        gameObject.SetActive(false);
        buttons.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update () {
        if (CK && textGO)
        {
            if (T >= user.conversation[0].String.Length)
            {
                textGO = false;
                //生成按鈕
                if (user.conversation[0].Option.Length != 0)
                {
                    button = new Toggle[user.conversation[0].Option.Length];
                    for (int arrty = 0; arrty < user.conversation[0].Option.Length; arrty++)
                    {
                        button[arrty] = Instantiate(buttons, buttons.transform.parent);
                        button[arrty].gameObject.SetActive(true);
                        button[arrty].GetComponentsInChildren<Text>()[0].text = user.conversation[0].Option[arrty];
                    }
                }
            }
            time += Time.deltaTime;
            if (time >= world.delay)
            {
                text.text += user.conversation[0].String[T];
                T++;
                time = 0;
            }
        }
        if (user.conversation.Length != 0&&!CK)
        {
            CK = true;
            rapidBlurEffect.enabled = true;
            gameObject.SetActive(true);
            home.SetActive(false);
            text.color = user.conversation[0].text;
            background.color = user.conversation[0].background;
            if (user.conversation[0].sprite == null)
                image.gameObject.SetActive(false);
            else
            {
                image.gameObject.SetActive(true);
                image.sprite = user.conversation[0].sprite;
            }
            text.text = user.conversation[0].String[0].ToString();
            T = 1;
            time = 0;
            textGO = true;
            //還原 . 將按鈕清空
            if (button.Length != 0) foreach (Toggle AE in button) Destroy(AE.gameObject);
        }
        else if(!CK)
        {
            gameObject.SetActive(false);
            rapidBlurEffect.enabled = false;
        }
        
    }
    private void OnDisable()
    {
        home.SetActive(true);
    }
    public void OUT()
    {
        if (textGO)
        {
            textGO = false;
            text.text = user.conversation[0].String;
            if (user.conversation[0].Option.Length != 0)
            {
                button = new Toggle[user.conversation[0].Option.Length];
                for (int arrty = 0; arrty < user.conversation[0].Option.Length; arrty++)
                {
                    button[arrty] = Instantiate(buttons, buttons.transform.parent);
                    button[arrty].gameObject.SetActive(true);
                    button[arrty].GetComponentsInChildren<Text>()[0].text = user.conversation[0].Option[arrty];
                }
            }
        }
        else
        {
            var DATA = new List<User.Conversation_format>(user.conversation);
            DATA.RemoveAt(0);
            user.conversation = DATA.ToArray();
            CK = false;
        }
    }

    public void CKT()
    {
        for (int X = 0; X < button.Length; X++) if (button[X].isOn)
            {
                Debug.Log(X);
                if (user.conversation[0].GameObject != null)
                    user.conversation[0].GameObject(X);
                var DATA = new List<User.Conversation_format>(user.conversation);
                DATA.RemoveAt(0);
                user.conversation = DATA.ToArray();
                CK = false;
            }
    }
}
