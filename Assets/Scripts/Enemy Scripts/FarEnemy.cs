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

    private float shootDelay = 3f;
    private float shootTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        ready = true;
        shootTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
            transform.LookAt(target.transform);
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            if (ready)
            {
                Attack();
            }
            else
            {
                agent.destination = walkPoint;
                if (this.transform.position == walkPoint || shootTimer <= 0) ready = true;
            }
            shootTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        shootTimer = shootDelay;
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
