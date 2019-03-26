using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        //call this when hitting a pickup
        if (other.tag == "Player")
            PickUp();
    }

    void PickUp()
    {
        
    }
}
