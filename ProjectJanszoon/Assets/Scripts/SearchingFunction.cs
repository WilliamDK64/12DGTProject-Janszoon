using JetBrains.Annotations;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingFunction : MonoBehaviour
{

    // Parameter list
    public bool? IsFlying;
    public string[] Colors = new string[8];


    public GameObject[] Birds;

    [SerializeField] private GameObject _scrollArea;
    [SerializeField] private GameObject _scrollMargin;
    [SerializeField] private GameObject _searchArea;
    [SerializeField] private RectTransform _searchContent;
    [SerializeField] private RectTransform _searchAreaRect;
    [SerializeField] private GameObject _margin;
    [SerializeField] private Transform _resultParent;
    public void Search()
    {
        // Create a list so that Birds array is unchanged
        List<GameObject> birdList = new();
        birdList.AddRange(Birds);

        foreach(GameObject bird in Birds)
        {
            Bird birdScript = bird.GetComponent<Bird>();

            // Flying?
            // If the flying parameter has been set but the bird is not what the parameter is set to, remove the bird.
            if(IsFlying != null && birdScript.IsFlying != IsFlying) 
            {
                birdList.Remove(bird);
            }
            
            // Colors?
            foreach(string c in Colors) 
            {
                // If the color isn't empty and there is no element of that color on the bird, remove the bird.
                if(c != "" && Array.Exists(birdScript.Colors, element => element == c) == false)
                {
                    birdList.Remove(bird);
                }
            }
        }

        // If list isn't empty, show results
        if(birdList.Any() == true) 
        {
            // Switch the UI to the search result page
            _scrollArea.SetActive(false);
            _scrollMargin.SetActive(false);
            _searchArea.SetActive(true);

            // Create top margin
            Instantiate(_margin, new Vector2(0, 0), Quaternion.identity, _resultParent);

            
            // Show all the bird cards remaining
            foreach (GameObject bird in birdList)
            {
                Instantiate(bird, new Vector2(0, 0), Quaternion.identity, _resultParent);
            }

            // Create bottom margin
            Instantiate(_margin, new Vector2(0, 0), Quaternion.identity, _resultParent);

            // Start results from top of content rather than middle
            Canvas.ForceUpdateCanvases();
            Vector3 contentPosition = _searchContent.localPosition;
            contentPosition.y = (_searchContent.sizeDelta.y - _searchAreaRect.sizeDelta.y) * -1;
            _searchContent.localPosition = contentPosition;
        }
    }

    public void CloseSearch()
    {
        // Destroy all search results
        GameObject[] deleteObjects = GameObject.FindGameObjectsWithTag("SearchResult");
        foreach(GameObject card in deleteObjects)
        {
            Destroy(card);
        }

        // Switch the UI to the search choice page
        _scrollArea.SetActive(true);
        _scrollMargin.SetActive(true);
        _searchArea.SetActive(false);
    }

}
