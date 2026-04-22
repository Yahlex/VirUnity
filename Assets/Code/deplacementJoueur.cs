using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    public float vitesse = 5f;
    public float vitesseSprint = 9f;
    public float forceSaut = 5f;
    public float gravite = -9.81f;

    private CharacterController _controller;
    private Vector3 _vitesseVerticale;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Sol
        bool auSol = _controller.isGrounded;
        if (auSol && _vitesseVerticale.y < 0)
            _vitesseVerticale.y = -2f;

        // ZQSD + touches directionnelles
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * h + transform.forward * v;

        // Sprint avec Shift
        float vitesseActuelle = Input.GetKey(KeyCode.LeftShift) ? vitesseSprint : vitesse;
        _controller.Move(direction * vitesseActuelle * Time.deltaTime);

        // Saut avec Espace
        if (Input.GetButtonDown("Jump") && auSol)
            _vitesseVerticale.y = Mathf.Sqrt(forceSaut * -2f * gravite);

        // Gravité
        _vitesseVerticale.y += gravite * Time.deltaTime;
        _controller.Move(_vitesseVerticale * Time.deltaTime);
    }
}