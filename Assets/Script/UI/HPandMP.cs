using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPandMP : MonoBehaviour {

    public User user;
    public Image image;
    public Text text;
    public UI_HP_MP Mod;
    private float max,ing;
    public World world;
    public enum UI_HP_MP
    {
        HP,MP,LV,Time
    }

	// Update is called once per frame
	void Update ()
    {
        if (Mod == UI_HP_MP.HP)
        {
            ing = user.Hp.Hp;
            max = user.Hp.Hpmax;
            text.text = "血量:" + ing.ToString("f2") + "/" + max;
        }
        else if(Mod==UI_HP_MP.MP)
        {
            ing = user.Mp.Mp;
            max = user.Mp.Mpmax;
            text.text = "魔力:" + ing.ToString("f2") + "/" + max;
        }
        else if (Mod == UI_HP_MP.LV)
        {
            ing = user.user.experience;
            max = (user.user.LV * world.LV_TO_UP) + world.LV_UP;
            text.text = "經驗:" + ing.ToString("f2") + "/" + max;
        }
        else if(Mod==UI_HP_MP.Time)
        
            text.text = "時間:" + (world.Time / 60).ToString("f0") + "點:" + (world.Time % 60).ToString("F0") + "分";

        if (!(Mod == UI_HP_MP.Time))
        {
            image.fillAmount = ing / max;

            if (ing / max >= 0.5)
                image.color = Color.Lerp(Color.yellow, Color.green, (ing / max) - 0.5f);
            else image.color = Color.Lerp(Color.red, Color.yellow, (ing / max) + 0.5f);
        }
    }
}
