using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Texture2D defaultCursor, clickedCursor;
    
 

   

    private void Start()
    {
        Default();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Default();
        }
    }


    public void Clicked()
    {
        Cursor.SetCursor(clickedCursor, Vector2.zero,CursorMode.Auto);
    }

    public void Default()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
