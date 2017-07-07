using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrol : EnemyAIChase {

    public Transform[] patrolPoints;
    private int curPatrolPointIndex = 0;
    public float waitTime = 5;
    private float curWaitTime;
	// Use this for initialization
	new void Start () {
        base.Start();
        curWaitTime = waitTime;
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        Chase();
        if (!isChasing)
        {
            Patrol();
        }

    }

    void Patrol()
    {
        
        if(agent.velocity == Vector3.zero)
        {
            if (curWaitTime <= 0)
            {
                state = EnemyState.Watching;
                curWaitTime = waitTime;
                
                if (curPatrolPointIndex == patrolPoints.Length - 1)
                {
                    curPatrolPointIndex = 0;
                }
                else
                {
                    curPatrolPointIndex++;
                }
                agent.destination = patrolPoints[curPatrolPointIndex].position;
            }
            else
            {
                state = EnemyState.Patrolling;
                //transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, patrolPoints[curPatrolPointIndex].eulerAngles.y, Time.deltaTime * agent.angularSpeed), 0);
            }

            curWaitTime -= Time.deltaTime;
        }
    }
}
