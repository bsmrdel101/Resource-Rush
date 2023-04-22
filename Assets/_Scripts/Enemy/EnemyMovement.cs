using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyBehavior {
    AttackResource,
    AttackPlayer
}

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;
    private EnemyBehavior behavior = EnemyBehavior.AttackResource;

    [Header("References")]
    private Transform _playerTransform;


    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (behavior == EnemyBehavior.AttackPlayer)
            MoveToPlayer();
        else
            MoveToNearestResource();
    }

    private void MoveToPlayer()
    {
        Vector3 playerPos = _playerTransform.position;
        float speed = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed);
    }

    private void MoveToNearestResource()
    {
        Vector3 resourcePos = GetNearestResourcePos();
        float speed = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, resourcePos, speed);
    }

    // Return the nearest resource position
    private Vector3 GetNearestResourcePos()
    {
        GameObject[] resourceList = GameObject.FindGameObjectsWithTag("Resource");
        float closestDistance = 99999f;
        GameObject nearestObj = resourceList[0];

        foreach (GameObject resource in resourceList)
        {
            float dist = Vector3.Distance(transform.position, resource.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                nearestObj = resource;
            }
        }
        return nearestObj.transform.position;
    }
}
