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
	bool isRunning = true;
	WayPoint searchCenter; // the current searchCenter
	List <WayPoint> path = new List <WayPoint>(); // todo make private


	Vector2Int[] directions =
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	public List<WayPoint> GetPath()
    {
		LoadBlocks();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
    }

    private void CreatePath()
    {
		path.Add(endWaypoint);
		WayPoint previous = endWaypoint.exploredFrom;
		while (previous != startWaypoint)
        {
			path.Add(previous);
			previous = previous.exploredFrom;
        }
		path.Add(startWaypoint);
		path.Reverse();
    }

    private void BreadthFirstSearch()
    {
		queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
            HaltIfEndFound();
			ExploreNeighbours();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
			isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
		if (!isRunning) { return; }
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighbourCourdinates = searchCenter.GetGridPos() + direction;
			if (grid.ContainsKey(neighbourCourdinates))
            {
                QueueNewNeighbours(neighbourCourdinates);
            }
		}
    }

    private void QueueNewNeighbours(Vector2Int neighbourCourdinates)
    {
        WayPoint neighbour = grid[neighbourCourdinates];
		if (neighbour.isExplored || queue.Contains(neighbour))
		{
			// nothing
		}
		else
		{ 
			queue.Enqueue(neighbour);
			neighbour.exploredFrom = searchCenter;
		}
    }

    private void ColorStartAndEnd()
    {
		// todo consider moving out
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

			}
			else
			{
				grid.Add(waypoint.GetGridPos(), waypoint);
			}
        }
    }
}
