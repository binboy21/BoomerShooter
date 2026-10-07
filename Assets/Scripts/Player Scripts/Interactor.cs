using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public InputAction interact;
    [SerializeField] private Transform camera;
    private float maxDistance = 4;
    
    void Start()
    {
        interact = GetComponent<PlayerInput>().actions["Interact"];
    }

    
    void Update()
    {
        if (interact.IsPressed())
        {
            RaycastHit hit;
            Physics.Raycast(camera.position, camera.forward, out hit, maxDistance + 1);

            if (hit.transform != null)
            {
                if (hit.collider.gameObject.CompareTag("Door")) hit.collider.gameObject.GetComponent<Door>().Open();

                if (hit.collider.gameObject.CompareTag("DoorButton")) hit.collider.gameObject.GetComponent<DoorButton>().Pressed();
            }
        }
    }
}
