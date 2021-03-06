using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour 
{

	// public ok as is a data class
	public bool isExplored = false;
	public WayPoint exploredFrom;
	public bool isBlocked = false;

	Vector2Int gridPos;

	const int gridSize = 10;

	public int GetGridSize()
    {
		return gridSize;
    }

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
			 Mathf.RoundToInt(transform.position.x / 10f),
			 Mathf.RoundToInt(transform.position.z / 10f)
		);
	}

	void OnMouseOver()
	{
		if (Input.GetKey(KeyCode.Mouse0) & isBlocked == false ) // left click
		{
			FindObjectOfType<TowerFactory>().AddTower(this);
		}
	} 
}
