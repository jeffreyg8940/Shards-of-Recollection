using UnityEngine;
using UnityEngine.SceneManagement;


public class CutScene : MonoBehaviour
{
    public float changeTime;
    void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        Application.Quit();
    }
}
