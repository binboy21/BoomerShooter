using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool locked;
    [SerializeField] private Material green;
    private bool opening = false;
    private float total = 0f;
    
    void Update()
    {
        if (opening)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            total += 0.05f;
            if (total >= 4) opening = false;
        }
    }

    public void Open()
    {
        if (!locked)
        {
            opening = true;
        }
    }

    public void Unlock()
    {
        locked = false;
        GetComponent<Renderer>().material = green;
    }
}
