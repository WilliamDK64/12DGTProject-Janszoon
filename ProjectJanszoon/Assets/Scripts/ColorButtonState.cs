using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonState : MonoBehaviour
{
     
    public bool IsSelected = false;
    public string Colour;

    public void ChangeActivation(GameObject ring)
    {
        
        IsSelected = !IsSelected;

        ring.SetActive(IsSelected);
    }

}
