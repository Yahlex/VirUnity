using UnityEngine;

public class Flash : MonoBehaviour
{
    public string itemName = "Flash";
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a touché la clé USB");
            
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                inventory.AddItem(itemName);
                Debug.Log("Clé USB ajoutée à l'inventaire");
            }

            Destroy(gameObject);
        }
    }
}

    
