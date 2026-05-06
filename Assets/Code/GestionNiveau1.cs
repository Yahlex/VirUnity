using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionNiveau1 : MonoBehaviour
{
    [Header("Panneaux UI")]
    public GameObject panelVictoire;
    public GameObject panelDefaite;
    public GameObject panelIntro;

    private bool _niveauTermine = false;

    void Start()
    {
        // Cache tout au départ
        panelVictoire.SetActive(false);
        panelDefaite.SetActive(false);
        panelIntro.SetActive(true);

        // Pause le jeu pour l'intro
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (_niveauTermine) return;

        // Fermer l'intro avec Espace
        if (panelIntro.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            panelIntro.SetActive(false);
            Time.timeScale = 1f;
        }

        // Vérifie si le proxy est mort
        BossProxy proxy = FindFirstObjectByType<BossProxy>();
        if (proxy == null && !panelIntro.activeSelf)
        {
            Victoire();
        }
    }

    public void Defaite()
    {
        _niveauTermine = true;
        panelDefaite.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Victoire()
    {
        _niveauTermine = true;
        panelVictoire.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Recommencer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NiveauSuivant()
    {
        Time.timeScale = 1f;
        // Charge la scène suivante (niveau 2 de Lola)
        SceneManager.LoadScene("Intro_scene_2");
    }
}