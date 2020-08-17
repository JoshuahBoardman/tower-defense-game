using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[SerializeField] float secondsBetweenSpawns;
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
			print("Spawning!");
			//Instantiate(enemy, enemy.transform, enemyRotaion);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
    }
}
