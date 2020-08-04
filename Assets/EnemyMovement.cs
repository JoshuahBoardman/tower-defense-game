using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{

	[SerializeField] List<WayPoint> path;

	// Use this for initialization
	void Start () 
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    IEnumerator FollowPath()
    {
        print("Starting partol");
        foreach (WayPoint waypoint in path)
        {
            print("Visiting block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
