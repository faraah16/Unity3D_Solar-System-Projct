using UnityEngine;

public class SunDetailBoot : MonoBehaviour
{
    void Awake()
    {
        // Stoppe tout ce qui joue encore (musique du système solaire incluse)
        if (MusicManager.I != null) MusicManager.I.StopMusicImmediate();

        var all = UnityEngine.Object.FindObjectsByType<AudioSource>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var src in all) { src.Stop(); src.playOnAwake = false; }

        // Réactive l'écoute globale
        AudioListener.pause = false;
    }
}
