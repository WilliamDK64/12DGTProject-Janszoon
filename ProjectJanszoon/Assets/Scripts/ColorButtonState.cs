using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonState : MonoBehaviour
{
     
    public bool IsSelected = false;
    public string BirdColour;

    private bool _searching;

    public void ChangeActivation(GameObject ring)
    {
        
        IsSelected = !IsSelected;
        ring.SetActive(IsSelected);

        SearchingFunction searchScript = GameObject.FindWithTag("SearchEngine").GetComponent<SearchingFunction>();

        if(IsSelected)
        {
            _searching = true;
            for(int i = 0; i < 8; i++) 
            {
                if(_searching == true && searchScript.Colors[i] == "") 
                {
                    searchScript.Colors[i] = BirdColour;
                    _searching = false;
                } 
            }
        } else
        {
            for(int i = 0; i < 8; i++) 
            {
                if(searchScript.Colors[i] == BirdColour)
                {
                    searchScript.Colors[i] = "";
                }
            }
        }
        
    }

}
