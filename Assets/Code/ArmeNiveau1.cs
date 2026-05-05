using UnityEngine;

public class ArmeNiveau1 : MonoBehaviour
{
    public string nomArme;
    public float degats;
    public float cooldown = 1f;
    public Color couleur = Color.white;

    private bool _ramassee = false;

    void Start()
    {
        // Applique la couleur au cube
        GetComponent<Renderer>().material.color = couleur;

        // Fait tourner l'arme sur elle-même pour attirer l'attention
        // (on le fait dans Update)
    }

    void Update()
    {
        if (!_ramassee)
        {
            // Rotation pour l'effet visuel
            transform.Rotate(0, 90 * Time.deltaTime, 0);

            // Flotte légèrement
            float y = Mathf.Sin(Time.time * 2f) * 0.1f;
            transform.position += new Vector3(0, y * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_ramassee) return;

        // Vérifie que c'est le joueur
        if (other.GetComponentInParent<VieJoueur>() != null)
        {
            _ramassee = true;
            Debug.Log("Arme ramassée : " + nomArme + " | Dégâts : " + degats);
            ChatLog.Log("Arme ramassée : " + nomArme + " | Dégâts : " + degats);

            // Donne l'arme au joueur
            AttaqueJoueur attaque = other.GetComponentInParent<AttaqueJoueur>();
            if (attaque != null)
                attaque.EquiperArme(nomArme, degats, cooldown);

            // L'arme disparaît
            Destroy(gameObject);
        }
    }
}