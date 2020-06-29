using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroling : MonoBehaviour
{

    [SerializeField]
    float accuracyWaypoint = 1f;
    [SerializeField]
    int numberOfWaypoints = 10;
    [SerializeField]
    int patrolingRadius = 5;

    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolingRoute();
    }

    private void InitializePatrolingRoute()
    {
        int i = numberOfWaypoints;
        while (i > 0)
        {
            float randX = Random.Range(transform.position.x - patrolingRadius, transform.position.x + patrolingRadius);
            float randZ = Random.Range(transform.position.z - patrolingRadius, transform.position.z + patrolingRadius);
            float yValue = transform.localPosition.y;
            if(Terrain.activeTerrain != null)
            {
                yValue = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));
            }
            Vector3 waypoint = new Vector3(randX, yValue, randZ);
            waypoints.Add(waypoint);
            i--;
        }
    }

    public void Patrole(float speed, float rotationSpeed)
    {
        if(waypoints.Count == 0)
        {
            return;
        }

        if (Vector3.Distance(waypoints[currentWaypoint], transform.position) < accuracyWaypoint)
        {
            currentWaypoint = Random.Range(0, waypoints.Count);
        }
        Vector3 direction = waypoints[currentWaypoint] - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
