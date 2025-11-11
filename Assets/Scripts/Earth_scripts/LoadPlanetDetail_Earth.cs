using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadPlanetDetail : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string sceneToOpen = "EarthDetail";
     [SerializeField] AudioSource dronehum;

    private static void StopAllAudioHard()
    {
        // New API (Unity 2023/Unity 6):
        foreach (var src in UnityEngine.Object.FindObjectsByType<AudioSource>(
                     FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            src.Stop();
        }

        // Pause global audio until the next scene unpauses it
        AudioListener.pause = true;
    }

    private void OnMouseDown() => OpenDetail();

    public void OpenDetail()
    {
        StopAllAudioHard();
        if (dronehum) dronehum.Stop(); 
        if (!string.IsNullOrEmpty(sceneToOpen))
            SceneManager.LoadScene(sceneToOpen);
    }

    public void OnPointerClick(PointerEventData eventData) => OpenDetail();
}
