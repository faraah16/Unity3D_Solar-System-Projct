using UnityEngine;

public class AudioProbe : MonoBehaviour
{
    [ContextMenu("Log All AudioSources")]
    void LogAll()
    {
        var all = UnityEngine.Object.FindObjectsByType<AudioSource>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);

        Debug.Log($"[AudioProbe] Found {all.Length} AudioSources:");
        foreach (var src in all)
        {
            string scene = src.gameObject.scene.name; // "DontDestroyOnLoad" si persistant
            string clip  = src.clip ? src.clip.name : "(no clip)";
            Debug.Log($" - [{scene}] {GetPath(src.gameObject)} | clip={clip} | playing={src.isPlaying} | awake={src.playOnAwake}");
        }
    }

    string GetPath(GameObject go)
    {
        string p = go.name;
        var t = go.transform;
        while (t.parent != null) { t = t.parent; p = t.name + "/" + p; }
        return p;
    }

    void Awake()
    {
        // Au moment d'entrer dans EarthDetail, log automatique
        LogAll();
    }
}
