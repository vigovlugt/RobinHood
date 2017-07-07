using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour {

    private NavMeshAgent agent;
    private Animator anim;

    public float walkSpeed;
    public float runSpeed;
    public float sneakSpeed;
    public string[] movementTypes;
    public int movementType;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

            }
            
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(movementType == movementTypes.Length - 1)
            {
                movementType = 0;
            }
            else
            {
                movementType++;
            }

            
            if (movementTypes[movementType] == "isWalking")
            {
                agent.speed = walkSpeed;
            }
            else if (movementTypes[movementType] == "isRunning")
            {
                agent.speed = runSpeed;
            }
            else if (movementTypes[movementType] == "isSneaking")
            {
                agent.speed = sneakSpeed;
            }
        }

        //Animations
        if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("isIdle", true);
            for (int i = 0; i < movementTypes.Length; i++)
            {
                anim.SetBool(movementTypes[i], false);
            }

        }
        else
        {
            anim.SetBool("isIdle", false);
            for (int i = 0; i < movementTypes.Length; i++)
            {
                if (movementTypes[i] == movementTypes[movementType])
                {
                    anim.SetBool(movementTypes[i], true);
                }
                else
                {
                    anim.SetBool(movementTypes[i], false);
                }

            }

        }

    }
}


