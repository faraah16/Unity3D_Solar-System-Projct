using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadPlanetDetail : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string sceneToOpen = "EarthDetail";
    private void StopAllAudioHard()
    {
        // Stoppe toutes les AudioSources
        foreach (var src in FindObjectsOfType<AudioSource>(true))
            src.Stop();



        // Met en pause globale (sécurité pendant le chargement)
        AudioListener.pause = true;
    }

    // PC/Editor : clic souris direct sur le collider
    private void OnMouseDown()
    {
        OpenDetail();
    }

    // Appel commun (servira aussi en VR plus tard)
    public void OpenDetail()
    {
        StopAllAudioHard();                 // <<< coupe tout ici
        if (!string.IsNullOrEmpty(sceneToOpen))
            SceneManager.LoadScene(sceneToOpen);
    }

    // Utile si tu ajoutes un Physics Raycaster/UI (facultatif)
    public void OnPointerClick(PointerEventData eventData)
    {
        OpenDetail();
    }
}
