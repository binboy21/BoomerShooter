using UnityEngine;

public class Pickups : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("HealthPickup")) { GetComponent<Health>().GainHealth(20); Destroy(coll.gameObject); }
        if (coll.gameObject.CompareTag("AmmoPickup")) { GetComponent<Gun>().ammo += 10; Destroy(coll.gameObject); Debug.Log("hiiii"); }
        if (coll.gameObject.CompareTag("GunPickup")) {GetComponent<Gun>().damage += 10; Destroy(coll.gameObject); }
    }
}
