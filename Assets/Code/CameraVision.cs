using UnityEngine;

public class CameraVision : MonoBehaviour
{
    GameManager gameManager = FindFirstObjectByType<GameManager>();
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game over");
            gameManager.GameOver();
        }
    }
}
