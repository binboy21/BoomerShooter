using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gun : MonoBehaviour
{
    public InputAction shoot;
    public int damage = 20;
    private int maxDistance = 10;
    [SerializeField] private Transform camera;

    public int ammo;
    [SerializeField] private TMP_Text ammoText;

    void Start()
    {
        shoot = GetComponent<PlayerInput>().actions["Shoot"];
        ammo = 20;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot.triggered && ammo > 0)
        {
            ammo--;

            RaycastHit hit;
            Physics.Raycast(camera.position, camera.forward, out hit, maxDistance + 1);

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

        ammoText.text = ammo.ToString();
    }

    public void Upgrade()
    {
        damage += 10;
    }
}
