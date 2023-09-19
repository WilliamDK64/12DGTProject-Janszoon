using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingFunction : MonoBehaviour
{

    // Parameter list
    public bool? IsFlying;
    public string[] Colors = new string[8];


    public GameObject[] Birds;
    [SerializeField] private Transform _canvas;
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
        
        foreach(GameObject bird in birdList)
        {
            Instantiate(bird, new Vector2(0, 0), Quaternion.identity, _canvas);
        }
    }

}
