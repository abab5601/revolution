using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_talent_display : MonoBehaviour
{
    public User user;
    public World world;
    public Image Original_image;
    private Image[] image;
    public Text text;
    private string Text;
    public World.Ability_menu ability_Menu;
    public Button button;

    private void Start()
    {
        int i = 0;
        image = new Image[world.Upper_limit];
        foreach (Image image in image)
        {
            this.image[i] = GameObject.Instantiate(Original_image, gameObject.transform, false);
            this.image[i].gameObject.SetActive(true);
            i++;
        }
        Text = text.text;
    }
    int i = 0;
    void Update()
    {
        #region 天賦點顏色處裡
        if (i <= world.Career[(int)user.user.Mod].value[(int)ability_Menu] - 1)
            image[i].color = Color.yellow;
        else if (i - world.Career[(int)user.user.Mod].value[(int)ability_Menu] <= user.talent[(int)ability_Menu] - 1)
            image[i].color = Color.green;
        else
            image[i].color = Color.white;
        i++;
        if (i >= image.Length)
            i = 0;
        #endregion
        text.text = Text + world.Career[(int)user.user.Mod].value[(int)ability_Menu] + "(職業加成)+" + user.talent[(int)ability_Menu];
        button.interactable = (user.talent[0] + user.talent[1] + user.talent[2] + user.talent[3] + user.talent[4]) < user.user.LV && user.talent[(int)ability_Menu] + world.Career[(int)user.user.Mod].value[(int)ability_Menu] < world.Upper_limit;//判斷等級增加天賦

    }
    /// <summary>
    /// 增加天賦
    /// </summary>
    public void Talent_up()
    {
        if ((user.talent[0] + user.talent[1] + user.talent[2] + user.talent[3] + user.talent[4]) < user.user.LV && user.talent[(int)ability_Menu] + world.Career[(int)user.user.Mod].value[(int)ability_Menu] < world.Upper_limit)//保障bug重複新增
            user.talent[(int)ability_Menu]++;
        i = user.talent[(int)ability_Menu];
    }
}