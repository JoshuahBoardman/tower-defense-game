using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

    Queue<Tower> placedTowers = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
	{
		if (placedTowers.Count < towerLimit)
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
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isBlocked = true;
        placedTowers.Enqueue(newTower);
        print(placedTowers.Count);
        // aset tower baseWypoint

    }
    private void MoveExistingTower(WayPoint baseWaypoint)
    {
        var oldTower = placedTowers.Dequeue();
        // todo take bottom tower off queue
        // set the isBlocked = false flags
        // set the baseWaypoint
        // put the old tower on top of the queue
        placedTowers.Enqueue(oldTower);
        Debug.Log("To many towers have been places");
    }
}