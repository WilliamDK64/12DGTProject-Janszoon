using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    
    public bool IsSelected = false;
    [SerializeField] private GameObject[] _deactivate;

    private Button _button;

    public ColorBlock InactiveColor = ColorBlock.defaultColorBlock;
    public ColorBlock ActiveColor = ColorBlock.defaultColorBlock;

    private void Start()
    {

        ActiveColor.normalColor = InactiveColor.pressedColor;
        ActiveColor.selectedColor = InactiveColor.pressedColor;
        ActiveColor.highlightedColor = new Color32(210, 210, 210, 255);

        _button = GetComponent<Button>();

    }

    private void Update()
    {
        if(IsSelected)
        {
            _button.colors = ActiveColor;

        } else
        {
            _button.colors = InactiveColor;
        }
    }

}
