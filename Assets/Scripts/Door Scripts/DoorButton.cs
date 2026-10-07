using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Material green;


    public void Pressed()
    {
        door.GetComponent<Door>().Unlock();
        GetComponent<Renderer>().material = green;
    }
}
