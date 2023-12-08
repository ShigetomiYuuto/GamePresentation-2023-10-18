using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleSelector : MonoBehaviour
{
    [SerializeField] Image[] _images = new Image[5];
    [SerializeField] Color[] _SelectColor = new Color[5];
    [SerializeField] int _Selectorindex = 0;
    [SerializeField] int _colorindex = 0;
    public static bool _enemy = false;
    void Start()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = Color.white;
        }

        _images[_Selectorindex].color = _SelectColor[2];
    }

    //void Update()
    //{
    //    var input = Keyboard.current;
    //    if (input == null) return;

    //    var left = input.leftArrowKey;
    //    var right = input.rightArrowKey;
    //    var up = input.upArrowKey;
    //    var down = input.downArrowKey;

    //    if (up.wasPressedThisFrame && index == 3)
    //    {
    //        colorindex++;
    //        if(colorindex >= SelectColor.Length) 
    //        {
    //            colorindex = 0;
    //        }
    //        images[3].color = SelectColor[colorindex];
    //    }

    //    if (down.wasPressedThisFrame  && images[3])
    //    {
    //        colorindex--;
    //        if (colorindex < 0)
    //        {
    //            colorindex = 4;
    //        }
    //        images[3].color = SelectColor[colorindex];
    //    }

    //    if (left.wasPressedThisFrame)
    //    {
    //        Debug.Log(index);
    //        images[index].color = Color.white;
    //        if(index == 0)
    //        {
    //            index = 6;
    //        }
    //        else
    //        {
    //            index--;
    //        }
    //        images[index].color = SelectColor[2];
    //    }

    //    if (right.wasPressedThisFrame)
    //    {
    //        Debug.Log(index);
    //        images[index].color = Color.white;
    //        if(index == 6)
    //        {
    //            index = 0;
    //        }
    //        else
    //        {
    //            index++;
    //        }

    //        images[index].color = SelectColor[2];
    //    }
    //}

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (context.ReadValue<float>() == 2)
            {
                if (_Selectorindex != 3)
                {
                   _images[_Selectorindex].color = Color.white;
                }
                Debug.Log(_Selectorindex);
                if (_Selectorindex == 6)
                {
                    _Selectorindex = 0;
                }
                else
                {
                    _Selectorindex++;
                }

                if (_Selectorindex != 3)
                {
                    _images[_Selectorindex].color = _SelectColor[2];
                }
            }

            else if (context.ReadValue<float>() == -2)
            {
                if (_Selectorindex != 3)
                {
                    _images[_Selectorindex].color = Color.white;
                }
                Debug.Log(_Selectorindex);
                if (_Selectorindex == 0)
                {
                    _Selectorindex = 6;
                }
                else
                {
                    _Selectorindex--;
                }
                if (_Selectorindex != 3)
                {
                    _images[_Selectorindex].color = _SelectColor[2];
                }
            }

            else if (context.ReadValue<float>() == 3 && _Selectorindex == 3)
            {
                _colorindex++;
                if (_colorindex >= _SelectColor.Length)
                {
                    _colorindex = 0;
                }
                _images[3].color = _SelectColor[_colorindex];
            }

            else if (context.ReadValue<float>() == -3 && _Selectorindex == 3)
            {
                _colorindex--;
                if (_colorindex < 0)
                {
                    _colorindex = 4;
                }
                _images[3].color = _SelectColor[_colorindex];
            }
        }
    }

    public void OnSerectDecision(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _enemy = true;
        }
    }
}
