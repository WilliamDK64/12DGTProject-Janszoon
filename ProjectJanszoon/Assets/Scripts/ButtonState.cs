using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    
    public bool IsSelected = false;
    [SerializeField] private GameObject[] _deactivate;

    private Button _button;

    private ColorBlock _inactiveColor = ColorBlock.defaultColorBlock;
    private ColorBlock _activeColor = ColorBlock.defaultColorBlock;

    private void Start()
    {

        _activeColor.normalColor = _inactiveColor.pressedColor;
        _activeColor.selectedColor = _inactiveColor.pressedColor;
        _activeColor.highlightedColor = new Color32(210, 210, 210, 255);

        _button = GetComponent<Button>();

    }

    public void ChangeActivation()
    {

        IsSelected = !IsSelected;

        if (IsSelected)
        {
            // Make the button look active.
            _button.colors = _activeColor;

            // Swap between different buttons.
            // This may need to be changed for the colours.
            foreach (GameObject selectable in _deactivate)
            {
                selectable.GetComponent<ButtonState>().IsSelected = false;
            }

        }
        else
        {
            _button.colors = _inactiveColor;
        }
    }

}
