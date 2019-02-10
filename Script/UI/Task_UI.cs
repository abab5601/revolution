using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_UI : MonoBehaviour {
    #region
    [System.Serializable]
    public struct UI
    {
        public Text Name;
        public Text Description;
        public box[] boxs;
        public Button button;
    }
    [System.Serializable]
    public struct box
    {
        public Image image;
        public Text text;
    }
    #endregion
    public TaskData taskData;
    public GameObject not, objs;
    public List<GameObject> gameObjects;
    // Use this for initialization
    public int X, Y;
	// Update is called once per frame
    /// <summary>
    /// 任務種類
    /// </summary>
    /// <param name="X">主線任務,之線任務,即時任務</param>
    public void x(int X) { this.X = X; }
    /// <summary>
    /// 任務狀態
    /// </summary>
    /// <param name="Y">未接收,進行中,已完成</param>
    public void y(int Y) { this.Y = Y; }
    private int arrty;
    void Update () {
		
	}
}
