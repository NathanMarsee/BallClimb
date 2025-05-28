using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private float speed;
    private Transform playerParent;
    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;
    private float timeToWayPoint;
    private float elapsedTime;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetWaypointIndex = 0;
        previousWaypoint = waypoints[targetWaypointIndex];
        targetWaypoint = waypoints[targetWaypointIndex];
        transform.parent.position = waypoints[targetWaypointIndex].position;
        transform.parent.rotation = waypoints[targetWaypointIndex].rotation;
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float progress = elapsedTime / timeToWayPoint;
        progress = Mathf.SmoothStep(0, 1, progress);
        rb.MovePosition(Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, progress));
        rb.MoveRotation(Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, progress));

        if(progress >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = targetWaypoint;
        if (targetWaypointIndex == waypoints.Count -1)
            targetWaypointIndex = 0;
        else
            targetWaypointIndex++;
        targetWaypoint = waypoints[targetWaypointIndex];

        elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWayPoint = distanceToWaypoint / speed;
        //print(targetWaypointIndex + " " + previousWaypoint.position + " " + targetWaypoint.position + " " + timeToWayPoint);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerParent = collision.gameObject.transform.parent;
            collision.gameObject.transform.SetParent(transform.parent, true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(playerParent, true);
        }
    }*/
}
