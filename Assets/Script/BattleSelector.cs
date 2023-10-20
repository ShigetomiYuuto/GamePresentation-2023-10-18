using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleSelector : MonoBehaviour
{
    [SerializeField] Image[] images = new Image[5];
    [SerializeField] Color[] SelectColor = new Color[5];
    [SerializeField] int index = 0;
    [SerializeField] int colorindex = 0;
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }

        images[index].color = SelectColor[2];
    }

    void Update()
    {
        var input = Keyboard.current;
        if (input == null) return;

        var left = input.leftArrowKey;
        var right = input.rightArrowKey;
        var up = input.upArrowKey;
        var down = input.downArrowKey;

        if (up.wasPressedThisFrame && images[3])
        {
            colorindex++;
            if(colorindex >= SelectColor.Length) 
            {
                colorindex = 0;
            }
            images[3].color = SelectColor[colorindex];
        }

        if (down.wasPressedThisFrame  && images[3])
        {
            colorindex--;
            if (colorindex < 0)
            {
                colorindex = 4;
            }
            images[3].color = SelectColor[colorindex];
        }

        if (left.wasPressedThisFrame)
        {
            Debug.Log(index);
            images[index].color = Color.white;
            if(index == 0)
            {
                index = 6;
            }
            else
            {
                index--;
            }
            images[index].color = SelectColor[2];
        }

        if (right.wasPressedThisFrame)
        {
            Debug.Log(index);
            images[index].color = Color.white;
            if(index == 6)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            images[index].color = SelectColor[2];
        }
    }

    public void OnSerector(InputAction.CallbackContext context)
    {

    }
}
