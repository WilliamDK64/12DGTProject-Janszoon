using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    
    public bool IsSelected = false;

    private Button _button;
    private Color _normalColor;
    private Color _pressedColor;
    private ColorBlock _buttonColorBlock;

    private void Start()
    {
        _button = GetComponent<Button>();

        // YOU CAN USE COLORBLOCK STRUCT HERE - Good idea for code review
        _normalColor = _button.colors.normalColor;
        _pressedColor = _button.colors.pressedColor;
        _buttonColorBlock = _button.colors;
    }

    private void Update()
    {
        // This could once again use ColorBlock to make it better. It works for now though.
        if(IsSelected)
        {
            _buttonColorBlock.normalColor = _pressedColor;
            _button.colors = _buttonColorBlock;

        } else
        {
            _buttonColorBlock.normalColor = _normalColor;
            _button.colors = _buttonColorBlock;
        }
    }

}
