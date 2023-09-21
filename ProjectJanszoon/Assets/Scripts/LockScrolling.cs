using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockScrolling : MonoBehaviour
{


    // THIS SCRIPT IS NO LONGER BEING USED IN THE PROJECT, BUT IS BEING KEPT IN CASE IT IS NEEDED



    [SerializeField] private RectTransform _scrollRect;
    [SerializeField] private RectTransform _contentRect;
    private float _yDifference;
    private float _limit;
    private bool _isAfterFirstFrame = false;

    private void Update()
    {   

        // Rects aren't drawn until after the first frame, so wait 1 frame before doing any calculations.
        if (_isAfterFirstFrame)
        {
            
            // Get the difference between the window's height and the content's height.
            _yDifference = _contentRect.sizeDelta.y - _scrollRect.sizeDelta.y;
            // Halve for only the top half and make negative (because it is going back to the top).
            _limit = (_yDifference / 2) * -1;

            Vector3 contentPos = _contentRect.localPosition;
            if (contentPos.y < _limit)
            {
                // Set scroll's velocity to zero so it stops moving and then set its y position to the limit.
                _scrollRect.GetComponent<ScrollRect>().velocity = new Vector2(0f, 0f);
                contentPos.y = _limit;
                _contentRect.localPosition = contentPos;
            }

            
        } else
        {
            // Continue to second frame...
            _isAfterFirstFrame = true;
        }

        

    }

}
