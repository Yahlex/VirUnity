using UnityEngine;

public class BossProxy : MonoBehaviour
{
    [Header("Vie du boss")]
    public float vieMax = 200f;
    public float vieActuelle;

    [Header("Attaques")]
    public float degatsDeBase = 5f;
    public float intervalleAttaque = 2f;
    public float distanceAttaque = 15f;

    [Header("Déplacement")]
    public float vitessePatrouille = 2f;
    public float vitessePoursuite = 4f;
    public float distanceDetection = 20f;

    [Header("Escalade des dégâts")]
    public float tempsEscalade = 20f;
    public int palierActuel = 0;
    public int palierMax = 3;

    private Transform _joueur;
    private VieJoueur _vieJoueur;
    private float _timerAttaque;
    private float _timerEscalade;

    // Patrouille
    private Vector3 _pointCible;
    private float _timerNouvelleDestination = 0f;

    // États du boss
    private enum Etat { Patrouille, Poursuite }
    private Etat _etat = Etat.Patrouille;

    void Start()
    {
        vieActuelle = vieMax;
        _joueur = GameObject.Find("Player1").transform;
        _vieJoueur = _joueur.GetComponent<VieJoueur>();
        _timerAttaque = intervalleAttaque;
        _timerEscalade = tempsEscalade;
        ChoisirNouvelleDestination();
    }

    void Update()
    {
        if (_joueur == null) return;

        float distanceJoueur = Vector3.Distance(transform.position, _joueur.position);

        // Changement d'état selon distance
        if (distanceJoueur <= distanceDetection)
        {
            _etat = Etat.Poursuite;
        }
        else if (distanceJoueur > distanceDetection * 1.5f)
        {
            _etat = Etat.Patrouille;
        }

        // Comportement selon l'état
        if (_etat == Etat.Patrouille)
            Patrouiller();
        else
            Poursuivre();

        // Attaque si assez proche
        _timerAttaque -= Time.deltaTime;
        if (_timerAttaque <= 0)
        {
            if (distanceJoueur <= distanceAttaque)
                Attaquer();
            _timerAttaque = intervalleAttaque;
        }

        // Escalade dégâts
        _timerEscalade -= Time.deltaTime;
        if (_timerEscalade <= 0 && palierActuel < palierMax)
        {
            palierActuel++;
            Debug.Log("Palier dégâts : " + palierActuel);
            _timerEscalade = tempsEscalade;
        }
    }

    void Patrouiller()
    {
        // Nouveau point aléatoire toutes les 3 secondes
        _timerNouvelleDestination -= Time.deltaTime;
        if (_timerNouvelleDestination <= 0)
            ChoisirNouvelleDestination();

        // Se déplace vers le point cible
        transform.LookAt(_pointCible);
        transform.position = Vector3.MoveTowards(
            transform.position,
            _pointCible,
            vitessePatrouille * Time.deltaTime
        );
    }

    void ChoisirNouvelleDestination()
    {
        // Point aléatoire autour de la position actuelle
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        _pointCible = new Vector3(
            transform.position.x + x,
            transform.position.y,
            transform.position.z + z
        );
        _timerNouvelleDestination = 3f;
    }

    void Poursuivre()
    {
        // Regarde et fonce vers le joueur
        transform.LookAt(_joueur);
        transform.position = Vector3.MoveTowards(
            transform.position,
            _joueur.position,
            vitessePoursuite * Time.deltaTime
        );
    }

    void Attaquer()
    {
        float degats = degatsDeBase * (1 + palierActuel);
        _vieJoueur.PrendreDegats(degats);
        Debug.Log("Proxy attaque ! Dégâts : " + degats + " | Palier : " + palierActuel);
    }

    public void PrendreDegats(float degats)
    {
        vieActuelle -= degats;
        Debug.Log("Proxy vie : " + vieActuelle);
        if (vieActuelle <= 0)
            Mourir();
    }

    void Mourir()
    {
        Debug.Log("Proxy vaincu ! Niveau terminé !");
        Destroy(gameObject);
    }
}