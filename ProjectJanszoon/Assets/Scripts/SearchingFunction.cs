using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingFunction : MonoBehaviour
{

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
