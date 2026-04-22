using UnityEngine;

public class CameraJoueur : MonoBehaviour
{
    // public Transform joueur;
    public float sensibilite = 3f;

    private float _rotationY;

    void Update()
    {
        // Clic droit maintenu = orienter la caméra
        if (Input.GetMouseButton(1)) // "Fire2" correspond généralement au clic droit
        {
            _rotationY += Input.mousePositionDelta.y * sensibilite;
            transform.rotation = Quaternion.Euler(0, _rotationY, 0);
            Debug.Log("Rotation caméra : " + Input.mousePositionDelta);
            // joueur.rotation = Quaternion.Euler(0, _rotationY, 0);
        }

        // La caméra suit le joueur
        // transform.position = joueur.position;
    }
}