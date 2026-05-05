using UnityEngine;

public class AttaqueJoueur : MonoBehaviour
{
    public string armeActuelle = "Aucune";
    public float degatsActuels = 0f;
    public float cooldownActuel = 1f;
    public float porteeAttaque = 10f;

    private float _timerCooldown = 0f;
    private bool _armeEquipee = false;

    void Update()
    {
        _timerCooldown -= Time.deltaTime;

        // Clic gauche pour attaquer
        if (Input.GetMouseButtonDown(0) && _armeEquipee && _timerCooldown <= 0)
        {
            Attaquer();
            _timerCooldown = cooldownActuel;
        }
    }

    public void EquiperArme(string nom, float degats, float cooldown)
    {
        armeActuelle = nom;
        degatsActuels = degats;
        cooldownActuel = cooldown;
        _armeEquipee = true;
        Debug.Log("Arme équipée : " + nom + " | Dégâts : " + degats);
    }

    void Attaquer()
    {
        // Cherche le Proxy dans la portée
        BossProxy proxy = FindFirstObjectByType<BossProxy>();
        if (proxy == null) return;

        float distance = Vector3.Distance(transform.position, proxy.transform.position);
        if (distance <= porteeAttaque)
        {
            proxy.PrendreDegats(degatsActuels);
            Debug.Log("Attaque ! " + armeActuelle + " inflige " + degatsActuels + " dégâts");
        }
        else
        {
            Debug.Log("Trop loin pour attaquer !");
        }
    }
}