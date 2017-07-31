using UnityEngine;
using System.Collections;

public class PathFollowing : MonoBehaviour {
    public PathScript pathToFollow;
    public int currentWayPointID = 0;
    public float speed;
    private float reachDist = 1;
    public float rotationSpeed = 5;
    public string pathName;
    public float distance;
     Vector2  last_position;
    Vector3 current_position;
	// Use this for initialization
	void Start () {
        pathToFollow = GameObject.Find(pathName).GetComponent<PathScript>();
        last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (pathToFollow != null)
        {

            distance = Vector3.Distance(pathToFollow.path_objs[currentWayPointID].position, transform.position);



            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);
            var rotation = Quaternion.LookRotation(pathToFollow.path_objs[currentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            if (distance <= reachDist)
            {
                currentWayPointID++;
            }
            if (currentWayPointID >= pathToFollow.path_objs.Count)
            {
                currentWayPointID = 0;
            }
        }
	}
}
