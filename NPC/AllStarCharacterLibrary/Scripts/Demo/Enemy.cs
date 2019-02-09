using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = new Vector2(16.0f,16.0f);
	public bool targeted=false;
    
	void OnMouseEnter() 
	{
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		targeted = true;
        //helo
        
    }
    void OnMouseExit() 
	{
        Cursor.SetCursor(null, new Vector2(16.0f,16.0f), cursorMode);
		targeted = false;
    }
	
}
