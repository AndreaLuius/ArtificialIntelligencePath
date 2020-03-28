using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;
        

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(executionPath());
    }
    
    private IEnumerator executionPath()
    {
        foreach(var index in path)
        {
            transform.position = index.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
