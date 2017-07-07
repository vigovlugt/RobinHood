using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour {

    public int damage;
    private GameObject target;
    public float distance = 2;
    public GameObject enemyRagdoll;

    private NavMeshAgent agent;
    private Animator anim;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        TakeDown();

	}

    public void TakeDown()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.root.tag != "Enemy")
                    return;

                target = hit.transform.root.gameObject;




            }

        }
        if (target != null)
        {
            if (target.GetComponent<EnemyAIChase>().state == EnemyState.Chasing)
            {
                agent.destination = transform.position;
                target = null;
            }
                


                if (distance >= Vector3.Distance(transform.position, target.transform.position))
                {
                StartCoroutine("TakeDownAndKill");
                    
                }
                else
                {
                    agent.destination = target.transform.position;
                }
        }
    }
    IEnumerator TakeDownAndKill()
    {
        anim.SetTrigger("TakeDown");
        agent.destination = transform.position;
        target.GetComponent<NavMeshAgent>().enabled = false;
        target.GetComponent<EnemyAI>().enabled = false;
        target.GetComponent<Animator>().enabled = false;
        target = null;
        yield return new WaitForSeconds(2);
        Destroy(target);
        Instantiate(enemyRagdoll, target.transform.position, target.transform.rotation);
    }
}
