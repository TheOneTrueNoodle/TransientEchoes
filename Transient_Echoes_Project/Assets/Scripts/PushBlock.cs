using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    [HideInInspector] public bool isBeingPushed;
    private Vector2 _destination;
    private float _speed;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _detectionRadius;

    [SerializeField] private LayerMask blockingWalls;

    private void Update()
    {
        if(Vector3.Distance(transform.position, _destination) < Mathf.Epsilon)
        {
            transform.position = _destination;
            isBeingPushed = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
        }
    }

    public void Push(Vector3 direction, float speed)
    {
        Debug.Log("Push is triggered");
        if(CheckDirection(direction))
        {
            _destination = transform.position + direction;
            _speed = speed * _speedMultiplier;
            isBeingPushed = true;
        }
    }

    private bool CheckDirection(Vector3 direction)
    {
        if(Physics2D.Raycast(transform.position, direction, _detectionRadius, blockingWalls))
        {
            return false;
        }

        return true;
    }
}
