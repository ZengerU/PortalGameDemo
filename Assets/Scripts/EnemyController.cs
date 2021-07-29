using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool goingA;

    private Transform pointA, pointB;

    public LevelController levelController;
    public float speed = 5f;

    private void Awake()
    {
        pointA = transform.parent.GetChild(0);
        pointB = transform.parent.GetChild(1);
    }

    private void FixedUpdate() //Moves enemy from point a to point b in a loop.
    {
        Vector3 target = goingA ? pointA.position : pointB.position;
        if (Vector3.Distance(target, transform.position) < 1)
        {
            goingA = !goingA;
            return;
        }

        Vector3 dir = (target - transform.position).normalized;
        transform.position += dir * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.GameOver();
        }
    }
}
