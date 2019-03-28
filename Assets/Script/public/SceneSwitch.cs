using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{


    public Text loadingText;
    public Slider sliderBar;
    public Image image;
    public World world;
    public User user;
    public Text prompt;
    //data up

    #region 切換場璟 Scene_switching<場景編號>
    public void Scene_play()
    {
        //code in dow :D
        image.sprite = world.Screen;
        loadingText.text = "loading...";


        //code in UP :D
        if (world.prompt.Length != 0)
            prompt.text = "小提示 : " + world.prompt[Random.Range(0, world.prompt.Length - 1)];
        else
            prompt.text = "小提示 : 遊戲開始中";
        StartCoroutine(LoadNewScene((int)user.XY.map));

    }
    /// <summary>
    /// 切換場璟
    /// </summary>
    /// <param name="scenes_name">場景編號</param>
    public void switching(int scenes_name)
    {
        //code in dow :D
        image.sprite = world.Screen;
        loadingText.text = "loading...";
        user.XY.map = (World.map)scenes_name;
        if (world.prompt.Length != 0)
            prompt.text = "小提示 : " + world.prompt[Random.Range(0, world.prompt.Length - 1)];
        else
            prompt.text = "小提示 : 遊戲開始中";
        StartCoroutine(LoadNewScene((int)user.XY.map));

    }
    #endregion



    ///0218
    IEnumerator LoadNewScene(int sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.6f);
            sliderBar.value = progress;
            if (progress == 1)
                loadingText.text = "載入完成 - 地圖開啟中";
            else
                loadingText.text = "載入中 - " + progress * 100f + " %";
            yield return null;

        }
    }
}
