using UnityEngine;
using UnityEngine.SceneManagement;

public class Audios : MonoBehaviour
{
    public static Audios instance;
    private AudioSource audioSource;
    private bool isMuted = false;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void ToggleMute()
    {
        if (audioSource != null)
        {
            isMuted = !isMuted;
            audioSource.mute = isMuted;
        }
        else
        {
            Debug.LogWarning("AudioSource component not found.");
        }
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}