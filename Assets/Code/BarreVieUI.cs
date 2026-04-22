using UnityEngine;
using UnityEngine.UI;

public class BarreVieUI : MonoBehaviour
{
    public Slider slider;
    public VieJoueur vieJoueur;
    private Image _fill;

    void Start()
    {
        // Récupère l'image de remplissage du slider
        _fill = slider.fillRect.GetComponent<Image>();
        slider.maxValue = vieJoueur.vieMax;
    }

    void Update()
    {
        // Met à jour la valeur
        slider.value = vieJoueur.vieActuelle;

        // Couleur verte → orange → rouge selon la vie
        float ratio = vieJoueur.vieActuelle / vieJoueur.vieMax;
        _fill.color = Color.Lerp(Color.red, Color.green, ratio);
    }
}