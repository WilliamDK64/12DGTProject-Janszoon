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
    [SerializeField] private Transform _canvas;
    public void Search()
    {
        List<GameObject> birdList = new();
        birdList.AddRange(Birds);

        foreach(GameObject bird in Birds)
        {
            Bird birdScript = bird.GetComponent<Bird>();
            if(birdScript.IsFlying != IsFlying) 
            {
                birdList.Remove(bird);
            }
        }
        
        foreach(GameObject bird in birdList)
        {
            Debug.Log(bird);
            Instantiate(bird, new Vector2(0, 0), Quaternion.identity, _canvas);
        }
    }

}
