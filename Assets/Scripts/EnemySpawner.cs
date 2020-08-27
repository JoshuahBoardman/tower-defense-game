using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[Range(.1f, 120f )][SerializeField] float secondsBetweenSpawns = 2;
	[SerializeField] EnemyMovement enemy;
	[SerializeField] Transform enemyParentTransform;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnEnimies());
	}
	
IEnumerator SpawnEnimies()
	{ 
		while (true)// forever
		{
			var newEnemey = Instantiate(enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
			newEnemey.transform.parent = enemyParentTransform;
		}
    }
}
