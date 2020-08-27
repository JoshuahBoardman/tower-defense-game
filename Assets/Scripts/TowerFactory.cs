using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
	{
		if (towerQueue.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }
  
    private void InstantiateNewTower(WayPoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isBlocked = true;
        newTower.transform.parent = towerParentTransform;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isBlocked = true;

        towerQueue.Enqueue(newTower);
    }
    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isBlocked = false; // free up the block
        newBaseWaypoint.isBlocked = true;
        oldTower.baseWaypoint = newBaseWaypoint;
        towerQueue.Enqueue(oldTower);
        oldTower.transform.position = newBaseWaypoint.transform.position;
        Debug.Log("To many towers have been places");
    }
}