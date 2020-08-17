using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[Range(.1f, 120f )][SerializeField] float secondsBetweenSpawns = 2;
	[SerializeField] EnemyMovement enemy;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnEnimies());
	}
	
IEnumerator SpawnEnimies()
	{ 
		while (true)// forever
		{
			Instantiate(enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
    }
}
