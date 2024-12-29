using UnityEditor.Search;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // setting variables 
    // [SerializeField] private AudioClip checkpointsound;
    public Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uIManager;

    private void Awake()
    {
        uIManager = FindFirstObjectByType<UIManager>();
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        Debug.Log("Respawn triggered");
        // move player to the checkpoint once respanwed, as long as the checkpoint is actually triggered
        if(currentCheckpoint != null)
        {
            transform.position = currentCheckpoint.position;
            playerHealth.Respawn();

            //Move Cam to the respawn point
            Camera.main.GetComponent<CameraController>().moveToNewRoom(currentCheckpoint.parent);
        }
        else
        {
            uIManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the player has collided with the checkpoint
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; // store the current checkpoint
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
