using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {
    private Animator anim;//動畫控制器
    public User user;
    public Article_inventory article_Inventory;
    public Transform L, R;//手位置
    private GameObject L_G, R_G;//生成遊戲物件
    private int L_A, R_A;//陣列位置
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void OnEnable()
    {
        anim.SetInteger("Anim_ID", user.AnimPlay);
        if(L_A!=user.propL)
        {
            if (L_G != null)
                Destroy(L_G);
            L_A = user.propL;
            if (L_A!=-1)
            {
                L_G = Instantiate(article_Inventory.commodity[L_A].gameObject, L, true);
                L_G.GetComponent<Prop>().display(new User.Backpack("", article_Inventory.commodity[L_A].ID, 1, 1, User.Skill_.No), false);
            }
        }
        if (R_A != user.propL)
        {
            if (R_G != null)
                Destroy(R_G);
            R_A = user.propR;
            if (R_A != -1)
            {
                R_G = Instantiate(article_Inventory.commodity[R_A].gameObject, R, true);
                R_G.GetComponent<Prop>().display(new User.Backpack("", article_Inventory.commodity[R_A].ID, 1, 1, User.Skill_.No), false);
            }

        }

    }
}
