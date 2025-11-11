using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager I { get; private set; }
    [SerializeField] private AudioSource musicSource;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);

        if (!musicSource) musicSource = GetComponent<AudioSource>();
        if (musicSource) musicSource.playOnAwake = false;
    }

    public void PlayMusic(AudioClip clip, float volume = 1f)
    {
        if (!musicSource || !clip) return;
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusicImmediate()
    {
        if (musicSource) musicSource.Stop();
    }
}
