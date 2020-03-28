using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeControl : MonoBehaviour
{

    [SerializeField][Range(0,10)] float cubeSize = 0;
    private TextMesh label;

    public void Start()
    {
        label = FindObjectOfType<TextMesh>();
    }

    private void cubeDistanze()
    {
        float xPos = Mathf.Round(transform.position.x / cubeSize) * cubeSize;
        float zPos = Mathf.Round(transform.position.z / cubeSize) * cubeSize;

        label.text = $"{xPos},{zPos}";
        transform.position = new Vector3(xPos, 0f, zPos);
    }
    
    void Update()
    {
       cubeDistanze();
    }
}
