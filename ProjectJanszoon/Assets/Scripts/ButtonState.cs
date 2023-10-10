using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{

    public bool IsClicked;
    public string Parameter;
    public string ParameterState;

    public bool IsSelected = false;
    [SerializeField] private GameObject[] _deactivate;
    [SerializeField] private GameObject _searchEngine;
    private SearchingFunction _searchEngineScript;

    private Button _button;

    private ColorBlock _inactiveColor = ColorBlock.defaultColorBlock;
    private ColorBlock _activeColor = ColorBlock.defaultColorBlock;

    private void Start()
    {
        // Find the search engine
        _searchEngineScript = _searchEngine.GetComponent<SearchingFunction>();

        // Set new button colors
        _activeColor.normalColor = _inactiveColor.pressedColor;
        _activeColor.selectedColor = _inactiveColor.pressedColor;
        _activeColor.highlightedColor = new Color32(210, 210, 210, 255);

        // Set up button click event (isClicked is true because it will only run if it has been clicked)
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { ChangeActivation(true, Parameter); });

    }

    public void ChangeActivation(bool IsClicked, string Parameter)
    {

        // Invert button state
        IsSelected = !IsSelected;

        // Get parameter variable from the Search Engine
        SearchingFunction searchScript = GameObject.FindWithTag("SearchEngine").GetComponent<SearchingFunction>();
        var searchField = searchScript.GetType().GetField(Parameter);
        if (searchField != null)
        {
            // If the variable is a boolean (e.g. isFlying) change the string to a boolean
            if(searchScript.GetType().GetField(Parameter).FieldType == typeof(bool?))
            {
                bool BooleanParameterState = bool.Parse(ParameterState);
                // Then set the boolean's value depending on if it the button was clicked
                if (IsClicked && IsSelected == false)
                {
                    searchScript.GetType().GetField(Parameter).SetValue(searchScript, null);
                }
                else
                {
                    searchScript.GetType().GetField(Parameter).SetValue(searchScript, BooleanParameterState);
                }
            } 
            else
            {
                // If it isn't a boolean, simply set the variable to the string parameter state
                if (IsClicked && IsSelected == false)
                {
                    searchScript.GetType().GetField(Parameter).SetValue(searchScript, null);
                }
                else
                {
                    searchScript.GetType().GetField(Parameter).SetValue(searchScript, ParameterState);
                }

            }

            // Update number of search results
            _searchEngineScript.Search(false);
            
        }


        // Change the color of the button to what it should be in that state
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
