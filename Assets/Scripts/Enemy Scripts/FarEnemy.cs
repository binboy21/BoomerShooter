using UnityEngine;
using UnityEngine.AI;

public class FarEnemy : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    private Vector3 walkPoint;

    private bool ready;

    [SerializeField] private Transform gun;
    private int maxDistance = 10;
    private int damage = 15;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            if (ready)
            {
                Attack();
            }
            else
            {
                agent.destination = walkPoint;
                if (this.transform.position == walkPoint) ready = true;
            }
        }
    }

    private void Attack()
    {
        RaycastHit hit;
        Physics.Raycast(gun.position, gun.forward, out hit, maxDistance + 1);
        if(hit.collider.gameObject.CompareTag("Player"))
        {
            hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        walkPoint = new Vector3(transform.position.x + Random.Range(0, 5), transform.position.y, transform.position.z + Random.Range(0, 5));
        ready = false;
    }
}
