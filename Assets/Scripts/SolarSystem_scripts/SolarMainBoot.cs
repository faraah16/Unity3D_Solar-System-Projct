using UnityEngine;

public class SolarMainBoot : MonoBehaviour
{
    [SerializeField] private AudioClip solarTheme;
    [SerializeField] private float volume = 1f;

    void Start()
    {
        AudioListener.pause = false; // ensure global audio is on again
        if (MusicManager.I != null && solarTheme != null)
            MusicManager.I.PlayMusic(solarTheme, volume);
    }
}
