using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingFunction : MonoBehaviour
{

    // Parameter list
    public bool? IsFlying;
    public string[] Colors = new string[8];


    public GameObject[] Birds;
    public void Search()
    {

        foreach(GameObject bird in Birds)
        {
            Bird birdScript = bird.GetComponent<Bird>();
            Debug.Log(birdScript.Name);
        }
    }

}
