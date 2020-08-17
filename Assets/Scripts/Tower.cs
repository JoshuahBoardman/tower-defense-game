using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : MonoBehaviour 
{

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] GameObject gun;

	[SerializeField] float attackRange = 10f ;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyDetection();
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
		float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
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
