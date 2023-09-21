using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMarginPositioner : MonoBehaviour
{
    [SerializeField] private Transform _topBanner;

    private void Update()
    {
        // Move a cyan banner to the top of the search screen so the user can't see white while scrolling down
        transform.position = new Vector2(_topBanner.position.x, _topBanner.position.y + 800);
    }
}
