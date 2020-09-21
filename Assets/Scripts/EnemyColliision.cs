using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliision : MonoBehaviour
{

	[SerializeField] int hits = 10;
    [SerializeField] int enemyValue = 25;
    [SerializeField] ParticleSystem hit;
    [SerializeField] ParticleSystem death;
    [SerializeField] AudioClip EnemyDmgSFX;
    [SerializeField] AudioClip EnemyDeathSFX;

    AudioSource myAudioSource;

    // Use this for initialization
    void Start()
	{
        myAudioSource = GetComponent<AudioSource>();
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
        myAudioSource.PlayOneShot(EnemyDmgSFX);
        hits --;
        hit.Play();
    }

     private void KillEnemy()
    {
        var vfx = Instantiate(death, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(EnemyDeathSFX, Camera.main.transform.position, .5f);

    }

    private void AwardPoints()
    {
        FindObjectOfType<PlayerAttributes>().UpdatePoints(enemyValue);
    }
}
