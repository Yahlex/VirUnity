using UnityEngine;

public class PasswordPanelMonoBehavior : MonoBehaviour
{
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
                    //Faire afficher panneau de fin de jeu
                }
                else
                {
                    Debug.Log("Accès refusé, clé USB requise");
                }
            }
        }
    }
}