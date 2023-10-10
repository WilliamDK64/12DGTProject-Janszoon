using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonState : MonoBehaviour
{
     
    public bool IsSelected = false;
    public string BirdColour;

    [SerializeField] private GameObject _searchEngine;
    private SearchingFunction _searchEngineScript;

    private bool _searching;

    private void Start()
    {
        // Find the search engine
        _searchEngineScript = _searchEngine.GetComponent<SearchingFunction>();
    }

    public void ChangeActivation(GameObject ring)
    {
        // Invert button state and show state using ring
        IsSelected = !IsSelected;
        ring.SetActive(IsSelected);

        // Get Search Engine to save color choices to
        SearchingFunction searchScript = GameObject.FindWithTag("SearchEngine").GetComponent<SearchingFunction>();
        // Search for an empty space in the array to save the color
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
        } 
        // If the color was deselected, find it in the array and delete it
        else
        {
            for(int i = 0; i < 8; i++) 
            {
                if(searchScript.Colors[i] == BirdColour)
                {
                    searchScript.Colors[i] = "";
                }
            }
        }

        // Update number of search results
        _searchEngineScript.Search(false);
        
    }

}
