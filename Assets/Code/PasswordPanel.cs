using UnityEngine;

public class PasswordPanel : MonoBehaviour
{
    public GameManager gameManager;
    public string requiredItem = "Flash";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a touché le panneau de mot de passe");
            
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                if (inventory.HasItem(requiredItem))
                {
                    Debug.Log("Accès autorisé");
                    gameManager.YouWon();
                }
                else
                {
                    Debug.Log("Accès refusé, clé USB requise");
                }
            }
        }
    }
}