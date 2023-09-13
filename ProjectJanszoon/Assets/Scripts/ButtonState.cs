using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{

    public bool IsClicked;
    public string Thingy;

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

        _button.onClick.AddListener(() => { ChangeActivation(true, Thingy); }); // add a was clicked thingy here, luv u future william <3

    }

    public void ChangeActivation(bool IsClicked, string Thingy)
    {

        IsSelected = !IsSelected;

        Type type = // Use types, this.GetType().GetField("myVar").GetValue(this);, set it or smth. Idk. This should be really easy and might 
                    // be overcomplicated. Have a great weekend future william!

        if (IsSelected)
        {
            // Make the button look active.
            _button.colors = _activeColor;

            // Only deactivate the other button if this was the clicked button.
            if(IsClicked)
            {
                // Swap between different buttons.
                // This may need to be changed for the colours.
                foreach (GameObject selectable in _deactivate)
                {
                    if(selectable.GetComponent<ButtonState>().IsSelected == true)
                    {
                        selectable.GetComponent<ButtonState>().ChangeActivation(false, "idk");
                    }  
                }
            }         

        }
        else
        {
            _button.colors = _inactiveColor;
        }

    }

}
