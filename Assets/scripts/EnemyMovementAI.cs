using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    void Start()
    {
        PathControl controlPath = FindObjectOfType<PathControl>();
        StartCoroutine(executionPath(controlPath.loadBreadth()));
    }
    
    private IEnumerator executionPath(List<WayPoint> list)
    {
        foreach(var index in list)
        {
            transform.position = index.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
