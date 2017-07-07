using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
public class EnemyAI : MonoBehaviour {

    protected GameObject player;
    protected Enemy enemy;
    protected NavMeshAgent agent;
    protected Animator anim;
    protected int movementType;
    protected float attackCooldown;
    public EnemyState state;

	// Use this for initialization
	public void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        state = EnemyState.Watching;
	}

    // Update is called once per frame
    public void Update()
    {
        UpdateAnimations();
    }

    public virtual void UpdateAnimations()
    {
        if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }
    }
    public void TryAttack()
    {


        if (enemy.attackDistance > Vector3.Distance(transform.position,player.transform.position))
        {
            Attack();

        }

    }

    public IEnumerator Attack()
    {
        PlayerHealth ph = GetComponent<PlayerHealth>();
        yield return new WaitForSeconds(1);
        ph.TakeDamage(enemy.damage);


    }
    
}
