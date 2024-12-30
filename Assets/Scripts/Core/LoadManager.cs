using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class LoadManager : MonoBehaviour
{
    private BoxCollider2D boxcollider; 

    private void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
