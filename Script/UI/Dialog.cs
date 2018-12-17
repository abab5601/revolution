using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public GameObject home;
    public new GameObject gameObject;
    public Text text;
    public Image image,background;
    public Button buttons;
    private Button[] button;
    public User user;
    // Use this for initialization

    void Start () {
        gameObject.SetActive(false);
        buttons.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (user.conversation.Length != 0)
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
