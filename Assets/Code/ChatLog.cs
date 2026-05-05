using UnityEngine;
using TMPro;

public class ChatLog : MonoBehaviour
{
    public TextMeshProUGUI textLog;

    private string[] _lignes = new string[4];

    public static ChatLog Instance;

    void Awake()
    {
        Instance = this;
        textLog.text = "";
    }

    public static void Log(string message)
    {
        if (Instance == null) return;
        Instance.AjouterMessage(message);
    }

    void AjouterMessage(string message)
    {
        for (int i = 0; i < 3; i++)
            _lignes[i] = _lignes[i + 1];

        _lignes[3] = "> " + message;

        string resultat = "";
        for (int i = 0; i < 4; i++)
        {
            if (_lignes[i] != null)
                resultat += _lignes[i] + "\n";
        }

        textLog.text = resultat;
    }
}