using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathControl : MonoBehaviour
{
    #region Fields
    [SerializeField] WayPoint startWaypoint, endWayPoint;
    private Dictionary<Vector2Int, WayPoint> mapPath =
        new Dictionary<Vector2Int, WayPoint>();
    private Queue<WayPoint> queue = new Queue<WayPoint>();
    private WayPoint[] wayPoints;
    private WayPoint searchElement;
    private bool isRunning = true;
    private Vector2Int[] directions =
    {
        Vector2Int.up,Vector2Int.down,
        Vector2Int.right,Vector2Int.left
    };
    private List<WayPoint> wayPointList = new List<WayPoint>();
    #endregion

    public void Awake()
    {
        wayPoints = FindObjectsOfType<WayPoint>();
    }

    #region Methods
    public void createPath()
    {
        wayPointList.Add(endWayPoint);
        var previous = endWayPoint.exploredFrom;
        while (previous != startWaypoint)
        {
            wayPointList.Add(previous);
            previous = previous.exploredFrom;
        }
        wayPointList.Add(startWaypoint);
        wayPointList.Reverse();
    }

    private void breadhAlgorithm()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchElement = queue.Dequeue();
            searchElement.isExplored = true;
            checkEnd();
            positionAI();
        }
    }

    private void checkEnd()
    {
        if(searchElement == endWayPoint)
        {
            endWayPoint.transform.Find("top")
                .GetComponent<MeshRenderer>().material.color = Color.red;
            isRunning = false;
        }
    }

    private void positionAI()
    {
        if (!isRunning) return;

        foreach(var index in directions)
        {
            try
            {
                Vector2Int explorer = searchElement.cubeSizer() + index;
                mapPath[explorer].transform.Find("top")
                .GetComponent<MeshRenderer>().material.color = Color.green;
                enqueingPathPosition(explorer);
            }catch (Exception ex)
            {
                print($"{ex.StackTrace}");
            }
        }
    }

    private void enqueingPathPosition(Vector2Int explorer)
    {
        var neighbour = mapPath[explorer];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchElement;
        }
            
    }

    private void mapData()
    {
        print("map data called");
        var obj = wayPoints[wayPoints.Length - 1].GetComponent<MeshRenderer>();
        obj.material.color = Color.red;

        foreach (var way in wayPoints)
        {
            mapPath.Add(way.cubeSizer(), way);
        }
    }

    public List<WayPoint> loadBreadth()
    {
        mapData();
        breadhAlgorithm();
        createPath();
        return wayPointList;
    }
    #endregion
}
