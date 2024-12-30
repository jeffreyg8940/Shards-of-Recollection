using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainUI : MonoBehaviour
{   
    [Header("MainMenu Params")]
    [SerializeField] private GameObject MainMenu;

    // private AudioClip gameOverSound;

    private void Awake()
    {
        // just in case im dumb I will deactivate the gamejover screen lol also will activate healthbar too
        MainMenu.SetActive(true); 

    }
    #region Main Menu
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void closeAppDude()
    {
        Application.Quit();
    }
    #endregion
}
