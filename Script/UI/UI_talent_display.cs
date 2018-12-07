using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_talent_display : MonoBehaviour {
    public User user;
    public World world;
    public Image Original_image;
    private Image[] image;
    public Text text;
    private string Text;
    public World.Ability_menu ability_Menu;
    

    private void Start()
    {
        int i=0;
        image = new Image[world.Upper_limit];
        foreach(Image image  in image)
        {
            this.image[i]= GameObject.Instantiate(Original_image, gameObject.transform , false);
            this.image[i].gameObject.SetActive(true);
            i++;
        }
        Text = text.text;
    }
    void Update ()
    {
        int i = 0;
		foreach(Image image in image)
        {
            if (i <= world.Career[(int)user.user.Mod].value[(int)ability_Menu]-1)
                image.color = Color.yellow;
            else if (i- world.Career[(int)user.user.Mod].value[(int)ability_Menu] <= user.talent[(int)ability_Menu]-1)
                image.color = Color.green;
            else
                image.color = Color.white;
           i++;
        }
        text.text = Text + world.Career[(int)user.user.Mod].value[(int)ability_Menu] + "(職業加成)+" + user.talent[(int)ability_Menu];


    }
}
