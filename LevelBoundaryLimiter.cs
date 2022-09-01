using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Limit position. Operate with LevelBoundary script only
/// Put on object need limits
/// </summary>
public class LevelBoundaryLimiter : MonoBehaviour
{
    private void Update()
    {
        if (LevelBoundary.Instance == null)
        {
            Debug.Log("LevelBoundary == null");
            return;
        }

        var lb = LevelBoundary.Instance;
        var r = lb.Radius;

        if(transform.position.magnitude > r)
        {
            if(lb.LimitMode == LevelBoundary.Mode.Limit)
            {
                transform.position = transform.position.normalized * r;
            }

            if(lb.LimitMode == LevelBoundary.Mode.Teleport)
            {
                transform.position = -transform.position.normalized * r;
            }
        }
    }
}
