using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    // private AudioClip gameOverSound;

    private void Awake()
    {
        // just in case im dumb I will deactivate the gamejover screen lol
        gameOverScreen.SetActive(false); 

    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true); 
        // SoundManager.instance.PlaySound(gameOverSound);
    }
}
