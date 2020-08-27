using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
    [SerializeField] float movementspeed;
    [SerializeField] ParticleSystem goalPartical;
    // Use this for initialization
    void Start () 
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
         
    IEnumerator FollowPath(List<WayPoint> path)
    {
        print("Starting partol");
        foreach (WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementspeed);
        }
        selfDestruct();
    }

    private void selfDestruct()
    {
        var vfx = Instantiate(goalPartical, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}