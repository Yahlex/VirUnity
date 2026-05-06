using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rejouer avec la touche R
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Rejouer");
            SceneManager.LoadScene("Scene_2");
        }

        // Quitter le jeu avec la touche Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitter");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void GameOver ()
    {
        SceneManager.LoadScene("Game_over_scene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {

        
    }
}
