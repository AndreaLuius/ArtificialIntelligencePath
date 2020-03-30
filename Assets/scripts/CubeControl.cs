using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeControl : MonoBehaviour
{
    private TextMesh label;
    private WayPoint waypoint;  

    public void Start()
    {
        waypoint = GetComponent<WayPoint>();
        label = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
       cubeDistanze();
    }


    private void cubeDistanze()
    {
        string text = $"{waypoint.cubeSizer().x},{waypoint.cubeSizer().y}";
        label.text = text;
        gameObject.name = text;
        transform.position =
            new Vector3(waypoint.cubeSizer().x, 0f, waypoint.cubeSizer().y);
    }
}
