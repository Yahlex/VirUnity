using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    public float vitesse = 5f;
    public float vitesseSprint = 9f;
    public float forceSaut = 5f;
    public float gravite = -9.81f;
    public float vitesseRotation = 100f;

    private CharacterController _controller;
    private Vector3 _vitesseVerticale;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool auSol = _controller.isGrounded;
        if (auSol && _vitesseVerticale.y < 0)
            _vitesseVerticale.y = -2f;

        // Rotation A (gauche) et E (droite) — positions physiques AZERTY
        if (Input.GetKey(KeyCode.Q)) transform.Rotate(0, -vitesseRotation * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.E)) transform.Rotate(0, vitesseRotation * Time.deltaTime, 0);

        // ZQSD en AZERTY = WASD en physique
        float h = 0f;
        float v = 0f;
        if (Input.GetKey(KeyCode.W)) v = 1f;   // Z sur AZERTY
        if (Input.GetKey(KeyCode.S)) v = -1f;
        if (Input.GetKey(KeyCode.A)) h = -1f;  // Q sur AZERTY
        if (Input.GetKey(KeyCode.D)) h = 1f;

        Vector3 direction = transform.forward * v + transform.right * h;

        float vitesseActuelle = Input.GetKey(KeyCode.LeftShift) ? vitesseSprint : vitesse;
        _controller.Move(direction * vitesseActuelle * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && auSol)
            _vitesseVerticale.y = Mathf.Sqrt(forceSaut * -2f * gravite);

        _vitesseVerticale.y += gravite * Time.deltaTime;
        _controller.Move(_vitesseVerticale * Time.deltaTime);
    }
}