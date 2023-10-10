using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMarginPositioner : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private RectTransform _selfRect;

    private void Update()
    {
        // Move a cyan banner to the top of the search screen so the user can't see white while scrolling down
        transform.position = new Vector2(_content.position.x, _content.position.y + _selfRect.sizeDelta.y + ((_content.sizeDelta.y - _selfRect.sizeDelta.y) / 2) - 10);
        //Debug.Log(_topBanner.sizeDelta);
    }
}
