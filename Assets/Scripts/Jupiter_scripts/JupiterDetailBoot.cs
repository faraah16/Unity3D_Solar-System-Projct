using UnityEngine;

public class JupiterDetailBoot : MonoBehaviour
{
    void Awake()
    {
        // 1) Stoppe toute musique venant du système solaire
        if (MusicManager.I != null)
            MusicManager.I.StopMusicImmediate();

        // 2) Stoppe toutes les AudioSources restantes
        var all = UnityEngine.Object.FindObjectsByType<AudioSource>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var src in all)
        {
            src.Stop();
            src.playOnAwake = false;
        }

        // 3) S'assurer que l'audio global est bien activé pour le son local
        AudioListener.pause = false;
    }
}
