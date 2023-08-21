using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScrolling : MonoBehaviour
{

    [SerializeField] private RectTransform _scrollRect;
    [SerializeField] private RectTransform _contentRect;
    private float _yDifference;

    private void Update()
    {
        _yDifference = _contentRect.sizeDelta.y;
        Debug.Log(_yDifference);
    }
}
