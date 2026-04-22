using UnityEngine;

public class VieJoueur : MonoBehaviour
{
    public float vieMax = 100f;
    public float vieActuelle;

    void Start()
    {
        vieActuelle = vieMax;
    }

    void Update()
    {
        // TEST TEMPORAIRE : T pour se faire des dégâts
        if (Input.GetKeyDown(KeyCode.T))
            PrendreDegats(10f);
    }
    // Appelé quand le joueur reçoit des dégâts
    public void PrendreDegats(float degats)
    {
        vieActuelle -= degats;
        Debug.Log("Vie joueur : " + vieActuelle);

        if (vieActuelle <= 0)
        {
            Mourir();
        }
    }

    void Mourir()
    {
        Debug.Log("Game Over !");
        // Pour l'instant on recharge la scène
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}