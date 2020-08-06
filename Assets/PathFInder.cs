using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour 
{

	[SerializeField] WayPoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
	Queue<WayPoint> queue = new Queue<WayPoint>();
	[SerializeField] bool isRunning = true;

	Vector2Int[] directions =
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};


	// Use this for initialization
	void Start()
	{
		LoadBlocks();
		ColorStartAndEnd();
		Pathfind();
	}

    private void Pathfind()
    {
		queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
            print("Searching from " + searchCenter); // todo remove log
            HaltIfEndFound(searchCenter);
			ExploreNeighbours(searchCenter);
        }
		// todo work out path
		print("Finished pathfinding?");
    }

    private void HaltIfEndFound(WayPoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
			print("Searching from end node, therfore stopping"); // todo remove log
			isRunning = false;
        }
    }

    private void ExploreNeighbours(WayPoint from)
    {
		if (!isRunning) { return; }
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighbourCourdinates = from.GetGridPos() + direction;
			try
            {
                QueueNewNeighbours(neighbourCourdinates);
            }
            catch
            {
				// do nothing
            }
		}
    }

    private void QueueNewNeighbours(Vector2Int neighbourCourdinates)
    {
        WayPoint neighbour = grid[neighbourCourdinates];
		if (neighbour.isExplored)
		{
			// nothing
		}
		else
		{ 
			neighbour.SetTopColor(Color.white);  // todo move later
			queue.Enqueue(neighbour);
			print("Queueing" + neighbour);
		}
    }

    private void ColorStartAndEnd()
    {
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.red);
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
    }
}
