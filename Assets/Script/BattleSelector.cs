using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleSelector : MonoBehaviour
{
    [SerializeField] Image[] _images = new Image[5];
    [SerializeField] Color[] _SelectColor = new Color[5];
    [SerializeField] int _selectorIndex = 0;
    [SerializeField] int _colorindex = 0;
    public static int _bSenemy = default;
    void Start()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = Color.white;
        }

        _images[_selectorIndex].color = _SelectColor[2];
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (context.ReadValue<float>() == 2)
            {
                if (_selectorIndex != 3)
                {
                   _images[_selectorIndex].color = Color.white;
                }
                Debug.Log(_selectorIndex);
                if (_selectorIndex == 6)
                {
                    _selectorIndex = 0;
                }
                else
                {
                    _selectorIndex++;
                }

                if (_selectorIndex != 3)
                {
                    _images[_selectorIndex].color = _SelectColor[2];
                }
                _bSenemy = _selectorIndex;
            }

            else if (context.ReadValue<float>() == -2)
            {
                if (_selectorIndex != 3)
                {
                    _images[_selectorIndex].color = Color.white;
                }
                Debug.Log(_selectorIndex);
                if (_selectorIndex == 0)
                {
                    _selectorIndex = 6;
                }
                else
                {
                    _selectorIndex--;
                }
                if (_selectorIndex != 3)
                {
                    _images[_selectorIndex].color = _SelectColor[2];
                }
                _bSenemy = _selectorIndex;
            }

            else if (context.ReadValue<float>() == 3 && _selectorIndex == 3)
            {
                _colorindex++;
                if (_colorindex >= _SelectColor.Length)
                {
                    _colorindex = 0;
                }
                _images[3].color = _SelectColor[_colorindex];
            }

            else if (context.ReadValue<float>() == -3 && _selectorIndex == 3)
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

    }
}
