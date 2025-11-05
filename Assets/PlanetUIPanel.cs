using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlanetUIPanel : MonoBehaviour
{
    [Header("Data")]
    public PlanetData data;

    [Header("Scene/Audio refs")]
    public AudioSource planetAudio;       // l’AudioSource sur l’objet planète
    public TMP_Text playButtonLabel;      // le texte du bouton Play/Pause

    [Header("Info Panel refs")]
    public GameObject infoPanel;
    public TMP_Text titleText;
    public TMP_Text bodyText;

    void Start()
    {
        if (infoPanel) infoPanel.SetActive(false);
        if (data != null)
        {
            if (titleText) titleText.text = data.displayName;
            if (bodyText)  bodyText.text  = data.description;
            if (planetAudio && data.audioClip) planetAudio.clip = data.audioClip;
        }
        UpdatePlayLabel();
    }

    // --- Bouton Retour ---
    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Solar System");
    }

    // --- Bouton Son ---
    public void ToggleSound()
    {
        if (!planetAudio) return;
        if (planetAudio.isPlaying) planetAudio.Pause();
        else planetAudio.Play();
        UpdatePlayLabel();
    }

    // --- Boutons Infos ---
    public void ShowInfo() { if (infoPanel) infoPanel.SetActive(true); }
    public void HideInfo() { if (infoPanel) infoPanel.SetActive(false); }

    void UpdatePlayLabel()
    {
        if (!playButtonLabel) return;
        playButtonLabel.text = (planetAudio && planetAudio.isPlaying) ? "Pause" : "Écouter le son";
    }
}
