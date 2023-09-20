using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMarginPositioner : MonoBehaviour
{
    [SerializeField] private Transform _topBanner;

    private void Update()
    {
        transform.position = new Vector2(_topBanner.position.x, _topBanner.position.y + 800);
    }
}
