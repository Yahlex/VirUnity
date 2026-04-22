using UnityEngine;

public class CameraVisionMonoBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game over");
        }
    }
}
