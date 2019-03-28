
using UnityEngine;
using UnityEngine.UI;

public class HomeUpdate : MonoBehaviour
{
    public User user;
    public Shadow shadow;
    public Text text;
    public Text ext;

    float i = 0;

    private void Awake()
    {
        ext.text = "版本編號:" + Application.version;

        text.text = "名字:" + user.user.Name + "\n職業:";
        switch (user.user.Mod)
        {
            case USER_initial.Career.NO: text.text += "沒職業"; break;
            case USER_initial.Career.Archer: text.text += "弓手"; break;
            case USER_initial.Career.warrior: text.text += "戰士"; break;
            case USER_initial.Career.Mage: text.text += "法師"; break;
            case USER_initial.Career.assassin: text.text += "刺客"; break;
            case USER_initial.Career.Gunman: text.text += "槍手"; break;
        }
        text.text += "\n等級:" + user.user.LV;
    }
    private void Update()
    {
        i += 0.005f;
        if (i >= 1) i = 0;
        shadow.effectColor = Color.HSVToRGB(i, 1, 1);
    }
}
