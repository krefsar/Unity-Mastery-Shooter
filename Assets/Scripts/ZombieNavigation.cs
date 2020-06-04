using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshPath path;
    private GameObject cube;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        Vector3 targetPos = playerTransform.position;

        bool foundPath = NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);
        if (foundPath)
        {
            Vector3 nextDestination = path.corners[1];
            cube.transform.position = nextDestination;

            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = new Vector3(directionToTarget.x, 0, directionToTarget.z);
            directionToTarget = flatDirection.normalized;

            var desiredRotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);

            transform.rotation = finalRotation;
        }
    }
}
