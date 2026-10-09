using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool close;


    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (close) enemy.GetComponent<CloseEnemy>().target = coll.gameObject;
            else enemy.GetComponent<FarEnemy>().target = coll.gameObject;
        }
    }
}
