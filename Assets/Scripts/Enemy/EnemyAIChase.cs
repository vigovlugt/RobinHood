using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIChase : EnemyAI {

    public bool isChasing = false;
    public Vector3 lastSight;

    public float fov;
    public float maxDistance;
    protected float updatedMaxDistance;

    public float chaseDelay;
    private float chaseCooldown;

    // Use this for initialization
    new void Start () {
        base.Start();
        chaseCooldown = chaseDelay;
    }
	
	// Update is called once per frame
	new void Update () {
        Chase();
        if (movementType == 0)
        {
            agent.speed = enemy.walkSpeed;
        }
        else if (movementType == 1)
        {
            agent.speed = enemy.runSpeed;
        }
    }

    public void Chase()
    {
        if(chaseCooldown <= 0)
        {
            chaseCooldown = chaseDelay;
            return;
        }
        chaseCooldown -= Time.deltaTime;



        Vector3 playerDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, playerDir);

        if (angle < fov)
        {
            updatedMaxDistance = maxDistance * MovementTypes.CalcMovementMultiplier(player.GetComponent<PlayerMovement>().movementType);

            RaycastHit hit;

            if(Physics.Raycast(transform.position, playerDir,out hit, updatedMaxDistance))
            {
                
                if(hit.transform.root.tag != "Player")
                    return;



                Debug.DrawRay(transform.position, playerDir, Color.red);
                isChasing = true;
                state = EnemyState.Chasing;
                movementType = 1;
                lastSight = player.transform.position;
                agent.destination = lastSight;

            }
        }
        if(transform.position == lastSight)
        {
            isChasing = false;
            state = EnemyState.Watching;
            movementType = 0;
        }

    }
    public override void UpdateAnimations()
    {
        if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        else if (movementType == 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
        }
    }

}
