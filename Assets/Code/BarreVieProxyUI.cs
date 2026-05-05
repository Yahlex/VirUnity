using UnityEngine;
using UnityEngine.UI;

public class BarreVieProxyUI : MonoBehaviour
{
    public Slider slider;
    public BossProxy proxy;
    private Image _fill;

    void Start()
    {
        _fill = slider.fillRect.GetComponent<Image>();
        slider.maxValue = proxy.vieMax;
        _fill.color = Color.red;
    }

    void Update()
    {
        if (proxy == null)
        {
            gameObject.SetActive(false);
            return;
        }

        slider.value = proxy.vieActuelle;
    }
}