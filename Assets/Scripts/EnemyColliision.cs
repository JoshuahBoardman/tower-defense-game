using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliision : MonoBehaviour
{

	[SerializeField] int hits = 10;


	// Use this for initialization
	void Start()
	{
		AddNonTriggerBoxCollider();
	}

	private void AddNonTriggerBoxCollider()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        // todo consider hit FX
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
