using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlanetUIPanel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlanetData data;

    [Header("Scene/Audio refs")]
    [SerializeField] private AudioSource planetAudio;      
    [SerializeField] private TMP_Text playButtonLabel;     

    [Header("Info Panel refs")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;

    private const string SolarSystemSceneName = "Solar System"; 

    private void Awake()
    {
        // 🔇 1. Couper le son d'ambiance du système solaire
        if (MusicManager.I != null)
            MusicManager.I.StopMusicImmediate();

        // 🔕 2. Cacher le panneau info et désactiver lecture auto
        if (infoPanel != null) infoPanel.SetActive(false);
        if (planetAudio != null) planetAudio.playOnAwake = false;
    }

    private void Start()
    {
        ApplyData();
        UpdatePlayLabel();
    }

    // --- Bouton Retour ---
    public void GoBack()
    {
        SceneManager.LoadScene(SolarSystemSceneName);
    }

    // --- Bouton Earth Sound ---
    public void ToggleSound()
    {
        if (!planetAudio) { Debug.LogWarning("PlanetUIPanel: planetAudio manquant."); return; }

        // s’assurer qu’on est bien en audio actif
        AudioListener.pause = false;

        // garantir que l’ambiance globale est coupée
        if (MusicManager.I != null) MusicManager.I.StopMusicImmediate();

        // charger le bon clip si nécessaire
        if ((!planetAudio.clip || planetAudio.clip == null) && data && data.audioClip)
            planetAudio.clip = data.audioClip;

        // sécurités
        planetAudio.mute = false;
        planetAudio.volume = Mathf.Max(0.001f, planetAudio.volume);
        planetAudio.spatialBlend = 0f; // 2D pour tester

        if (planetAudio.clip == null)
        {
            Debug.LogWarning("PlanetUIPanel: aucun clip assigné (ni via PlanetData, ni sur l'AudioSource).");
            return;
        }

        if (planetAudio.isPlaying) planetAudio.Pause();
        else                      planetAudio.Play();

        UpdatePlayLabel();
    }


    // --- Boutons Infos ---
    public void ShowInfo() { if (infoPanel) infoPanel.SetActive(true); }
    public void HideInfo() { if (infoPanel) infoPanel.SetActive(false); }

    // --- Helpers ---
    private void ApplyData()
    {
        if (!data) return;

        if (titleText) titleText.text = string.IsNullOrEmpty(data.displayName) ? "Planet" : data.displayName;
        if (bodyText) bodyText.text = string.IsNullOrEmpty(data.description) ? "no description." : data.description;

        if (planetAudio)
        {
            planetAudio.Stop();
            if (data.audioClip) planetAudio.clip = data.audioClip;
        }
    }

    private void UpdatePlayLabel()
    {
        if (!playButtonLabel) return;
        playButtonLabel.text = (planetAudio && planetAudio.isPlaying) ? "Pause" : "Écouter le son";
    }
}
