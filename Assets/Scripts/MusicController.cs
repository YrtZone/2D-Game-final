using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    
    public void AlternarMusica()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            Debug.Log("Música Pausada");
        }
        else
        {
            audioSource.UnPause();
            Debug.Log("Música Retomada");
        }
    }

    
    public void PararMusica()
    {
        audioSource.Stop();
    }
}