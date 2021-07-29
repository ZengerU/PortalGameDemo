using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : PhysicsObject
{
    private Transform pointA, pointB;

    private bool goingToA;
    
    public float speed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake ()
    {
        pointA = transform.parent.GetChild(0);//Enemy is 3rd child, first the children are patrol points.
        pointB = transform.parent.GetChild(1);
        spriteRenderer = GetComponent<SpriteRenderer> ();    
        animator = GetComponent<Animator> ();
    }

    /// <summary>
    /// Compute the velocity enemy will be using this update.
    /// </summary>
    protected override void ComputeVelocity()
    {
        float currentSpeed;
        if (goingToA && transform.position.x < pointA.position.x)
        {
            goingToA = !goingToA;
        }
        else if (!goingToA && transform.position.x > pointB.position.x)
        {
            goingToA = !goingToA;
        }
        currentSpeed = goingToA ? -speed : speed;

        spriteRenderer.flipX = Mathf.Abs(currentSpeed) > .1f ? currentSpeed > 0 : spriteRenderer.flipX; // Change flipx if moving with speed bigger than .1f
        
        animator.SetFloat ("Speed", currentSpeed);

        targetVelocity = new Vector2(currentSpeed, 0);
    }
}
