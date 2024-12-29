using UnityEngine;
using UnityEngine.Rendering;

public class roomReset : MonoBehaviour
{
    // save the initial position of the enemies
    [SerializeField] private GameObject[] enemies; 
    private Vector3[] initialPositions;

    private void Awake()
    {
        //Save the intial position of the enemies
        initialPositions = new Vector3[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPositions[i] = enemies[i].transform.position;
        }
    }

    public void ActivateRoom(bool _status)
    {
        //Activate/Deactiave the enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                {
                    enemies[i].SetActive(_status);
                    enemies[i].transform.position = initialPositions[i];
                }
        }
    }
}
