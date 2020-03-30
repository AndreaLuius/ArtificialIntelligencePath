using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const int cubeSize = 1;
    public bool isExplored = false;
    public WayPoint exploredFrom;

    public Vector2Int cubeSizer()
    {
        return new Vector2Int(
                (int)Mathf.Round(transform.position.x / cubeSize) * cubeSize,
                (int)Mathf.Round(transform.position.z / cubeSize) * cubeSize);
    }
}
