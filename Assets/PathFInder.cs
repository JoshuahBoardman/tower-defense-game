using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour 
{

	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

	// Use this for initialization
	void Start () 
	{
		LoadBlocks();
	}

    private void LoadBlocks()
    {
		var waypoints = FindObjectsOfType<WayPoint>();
		foreach (WayPoint waypoint in waypoints)
        {
			var gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Skipping overlapping block" + waypoint);
			}
			else
			{
				grid.Add(waypoint.GetGridPos(), waypoint);
			}
        }
		print("Loaded" + grid.Count + "blocks");
    }
}
