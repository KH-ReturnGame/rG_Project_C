using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip musicClip;

    void Start()
    {
        Invoke("PlayMusic", 1f);
    }
    void PlayMusic()
    {
        audioSource.clip = musicClip;
        audioSource.Play(); 
    }
}