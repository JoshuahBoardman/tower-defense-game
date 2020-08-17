using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : MonoBehaviour 
{
	// Paramaters
	[SerializeField] Transform objectToPan;
	[SerializeField] GameObject gun;
	[SerializeField] float attackRange = 10f ;

	//  State 
	Transform targetEnemy;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
    {
		SetTargetEnemy();
        EnemyDetection();
    }

    private void SetTargetEnemy()
    {
		var sceneEnemies = FindObjectsOfType<EnemyColliision>();
		if (sceneEnemies.Length == 0) { return; }

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyColliision testEnemy in sceneEnemies)
        {
			closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
		targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
		var distToA = Vector3.Distance(transformA.position, transform.position);
		var distToB = Vector3.Distance(transformB.position, transform.position);

		if (distToA < distToB)
        {
			return transformA;
        }
		return transformB;
	}

    private void EnemyDetection()
    {
        if (targetEnemy)
        {
            FireInRange();
        }
    }

    public void EnemyTracking(bool inRange)
    {
		if (inRange == true)
		{
			objectToPan.LookAt(targetEnemy);
		}

    }

	private void FireInRange()
    {
		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if (distanceToEnemy < attackRange)
		{
			SetGunsActive(true);
			EnemyTracking(true);
		}
		else
		{
			SetGunsActive(false);
			EnemyTracking(false);
		}
	}

	private void SetGunsActive(bool isActive)
	{
			var emmisionModule = gun.GetComponent<ParticleSystem>().emission;
			emmisionModule.enabled = isActive;
	}
}
