using UnityEngine;
using UnityEngine.AI;

public class CloseEnemy : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    private float attackDistance = 2f;
    private float attackDelay = 2f;
    private float attackTimer;

    private int damage = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attackTimer = 0f;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                agent.isStopped = false;
                agent.destination = target.transform.position;
            }
            else
            {
                agent.isStopped = true;
                if (attackTimer <= 0) Attack();
            }
        }

        if (attackTimer > 0) attackTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        target.GetComponent<Health>().TakeDamage(damage);
        attackTimer = attackDelay;
    }
}
