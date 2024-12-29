using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source; 

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

        //Do not destroy this when we go to a new level
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        //Destroy Duplicate Object
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
