using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{

    public void SelectParameter(GameObject button)
    {
        if (button.gameObject.GetComponent<ButtonState>() != null)
        {
            var buttonScript = button.gameObject.GetComponent<ButtonState>();

            buttonScript.IsSelected = !buttonScript.IsSelected;
            Debug.Log(buttonScript.IsSelected);
        }

    }

}
