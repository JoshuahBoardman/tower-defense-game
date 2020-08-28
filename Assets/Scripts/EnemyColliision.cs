using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliision : MonoBehaviour
{

	[SerializeField] int hits = 10;
    [SerializeField] int enemyValue = 25;
    [SerializeField] ParticleSystem hit;
    [SerializeField] ParticleSystem death;

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
            AwardPoints();
        }
    }

    private void ProcessHit()
    {
        hits = hits - 1;
        hit.Play();
    }

     private void KillEnemy()
    {
        var vfx = Instantiate(death, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    private void AwardPoints()
    {
        FindObjectOfType<PlayerAttributes>().UpdatePoints(enemyValue);
    }
}
