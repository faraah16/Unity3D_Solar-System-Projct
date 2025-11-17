using UnityEngine;

public class MercuryDetailBoot : MonoBehaviour
{
    void Awake()
    {
        if (MusicManager.I != null)
            MusicManager.I.StopMusicImmediate();

        var all = UnityEngine.Object.FindObjectsByType<AudioSource>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var src in all)
        {
            src.Stop();
            src.playOnAwake = false;
        }

        AudioListener.pause = false;
    }
}
