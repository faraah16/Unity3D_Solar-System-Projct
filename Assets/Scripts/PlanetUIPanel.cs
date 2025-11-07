using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlanetUIPanel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlanetData data;

    [Header("Scene/Audio refs")]
    [SerializeField] private AudioSource planetAudio;    // AudioSource sur la planète
    [SerializeField] private TMP_Text playButtonLabel;   // Texte du bouton Play/Pause

    [Header("Info Panel refs")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;

    private const string SolarSystemSceneName = "SolarSystem"; // ⚠️ pas "Solar System"

    // --- Désactive l'info panel avant tout ---
    private void Awake()
    {
        if (infoPanel != null) infoPanel.SetActive(false);
    }

    private void Start()
    {
        AudioListener.pause = false;        // <<< on réactive l'écoute
        if (planetAudio) planetAudio.playOnAwake = false;

        ApplyData();
        UpdatePlayLabel();
    }


    // ---------- API réutilisable ----------
    public void SetData(PlanetData newData)
    {
        data = newData;
        ApplyData();
    }

    public void SetPlanetAudio(AudioSource newAudio)
    {
        planetAudio = newAudio;
        if (data != null && data.audioClip && planetAudio)
            planetAudio.clip = data.audioClip;
        UpdatePlayLabel();
    }

    // --- Bouton: Retour ---
    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Solar System");    
    }

    // --- Bouton: Son ---
    public void ToggleSound()
    {
        if (!planetAudio) { Debug.LogWarning("PlanetUIPanel: planetAudio manquant."); return; }
        if (planetAudio.isPlaying) planetAudio.Pause();
        else planetAudio.Play();
        UpdatePlayLabel();
    }

    // --- Boutons: Infos ---
    public void ShowInfo()
    {
        if (infoPanel) infoPanel.SetActive(true);
        else Debug.LogWarning("PlanetUIPanel: infoPanel non assigné.");
    }

    public void HideInfo()
    {
        if (infoPanel) infoPanel.SetActive(false);
    }

    // ---------- Helpers ----------
    private void ApplyData()
    {
        
        if (data == null) return;

        if (titleText) titleText.text = string.IsNullOrEmpty(data.displayName) ? "Planet" : data.displayName;
        if (bodyText)  bodyText.text  = string.IsNullOrEmpty(data.description) ? "no description." : data.description;

        if (planetAudio && data.audioClip){
            planetAudio.Stop();  
            planetAudio.clip = data.audioClip;}
    }

    private void UpdatePlayLabel()
    {
        if (!playButtonLabel) return;
        playButtonLabel.text = (planetAudio && planetAudio.isPlaying) ? "Pause" : "Écouter le son";
    }
}
