using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject HealthBar;
    // private AudioClip gameOverSound;

    private void Awake()
    {
        // just in case im dumb I will deactivate the gamejover screen lol also will activate healthbar too
        HealthBar.SetActive(true);
        gameOverScreen.SetActive(false); 

    }

    public void GameOver()
    {
        HealthBar.SetActive(false);
        gameOverScreen.SetActive(true); 
        // SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quitter()
    {
        SceneManager.LoadScene(0);
    }

    public void closeAppDude()
    {
        Application.Quit();
    }
}
