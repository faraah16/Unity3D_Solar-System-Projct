using UnityEngine;

[CreateAssetMenu(menuName="SolarSystem/Planet Data", fileName="PlanetData_")]
public class PlanetData : ScriptableObject
{
    public string displayName;        // "Terre"
    [TextArea(6,10)] public string description;
    public AudioClip audioClip;       // son de la planète (si tu en as un)
    public string detailSceneName;    // "EarthDetail"
}
