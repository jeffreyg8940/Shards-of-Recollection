using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{   
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject HealthBar;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    
    // private AudioClip gameOverSound;

    private void Awake()
    {
        // just in case im dumb I will deactivate the gamejover screen lol also will activate healthbar too
        HealthBar.SetActive(true);
        gameOverScreen.SetActive(false); 
        pauseScreen.SetActive(false);

    }
    #region Game Over

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
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        HealthBar.SetActive(!status);

        if(status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if the pause screen is already active, make it UNACTIVE!! 
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

        public void pauseRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
