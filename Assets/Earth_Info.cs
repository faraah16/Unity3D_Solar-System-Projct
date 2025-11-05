using UnityEngine;
using TMPro;

public class EarthInfo : MonoBehaviour
{
    // 🟩 Variables publiques à lier dans Unity
    public GameObject panel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI bodyText;

    // 🟦 Variable interne pour savoir si le panneau est affiché
    private bool isVisible = false;

    void Start()
    {
        // Cache le panneau au démarrage
        panel.SetActive(false);
    }

    // 🟠 Appelé quand on clique sur la planète Terre
    private void OnMouseDown()
    {
        isVisible = !isVisible;
        panel.SetActive(isVisible);
    }

    // 🔵 Appelé par le bouton "Fermer"
    public void Hide()
    {
        panel.SetActive(false);
        isVisible = false;
    }
}