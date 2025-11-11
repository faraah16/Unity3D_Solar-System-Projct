using UnityEngine;

public class EarthDetailBoot : MonoBehaviour
{
    void Awake()
    {
        // Trouve toutes les AudioSources (même cachées) et stoppe tout
        var all = UnityEngine.Object.FindObjectsByType<AudioSource>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (var src in all)
        {
            // on log pour vérifier
            Debug.Log($"[EarthDetailBoot] STOP {src.name} | clip={ (src.clip ? src.clip.name : "none") }");
            src.Stop();
            src.playOnAwake = false;
        }

        // Réactive l’écoute globale (au cas où elle était en pause)
        AudioListener.pause = false;
    }
}
