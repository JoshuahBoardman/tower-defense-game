using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[Range(.1f, 120f )][SerializeField] float secondsBetweenSpawns = 2;
	[SerializeField] EnemyMovement enemy;
	[SerializeField] Transform enemyParentTransform;
	[SerializeField] AudioClip spawnedEnemySFX;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnEnimies());
	}
	
	IEnumerator SpawnEnimies()
	{ 
		while (true)// forever
		{
			GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
			var newEnemey = Instantiate(enemy, enemyParentTransform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
			newEnemey.transform.parent = enemyParentTransform;
		}
    }
}
