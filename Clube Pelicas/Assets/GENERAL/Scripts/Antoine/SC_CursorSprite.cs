using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_CursorSprite : MonoBehaviour
{
    private Vector2 CursorPosition;

    private bool IsVisible;

    private RectTransform MyRT;
    private Image MyImage;

    void Start()
    {

        MyRT = GetComponent<RectTransform>();
        MyImage = GetComponent<Image>();
        
    }

    void Update()
    {

        CursorPosition = (Input.mousePosition);
        CursorPosition.x = CursorPosition.x + 60;
        CursorPosition.y = CursorPosition.y + -50;

        MyRT.anchoredPosition = CursorPosition;

        IsVisible = Cursor.visible;

        if(IsVisible == true)
        {
          MyImage.color = new Color32(255, 255, 255, 255);
        }

        else
        {
            MyImage.color = new Color32(255, 255, 255, 0);

        }

        //Debug.Log(CursorPosition);

    }
}
