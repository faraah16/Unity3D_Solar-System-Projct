using UnityEngine;

public class EarthAndMoonRotation : MonoBehaviour
{
    [Header("Rotation de la Terre")]
    [SerializeField] private float earthRotationSpeed = 10f;

    [Header("Révolution de la Lune")]
    [SerializeField] private Transform moon;       // Référence à l’objet Moon
    [SerializeField] private float moonOrbitSpeed = 20f;
    [SerializeField] private float moonOrbitRadius = 2f;

    private float angle; // pour suivre l'orbite de la Lune

    void Update()
    {
        // 1️⃣ Faire tourner la Terre sur elle-même
        transform.Rotate(Vector3.up, earthRotationSpeed * Time.deltaTime, Space.Self);

        // 2️⃣ Faire tourner la Lune autour de la Terre
        if (moon != null)
        {
            angle += moonOrbitSpeed * Time.deltaTime;
            float radians = angle * Mathf.Deg2Rad;

            // Position orbitale de la Lune autour de la Terre
            Vector3 orbitPosition = new Vector3(
                Mathf.Cos(radians) * moonOrbitRadius,
                0f,
                Mathf.Sin(radians) * moonOrbitRadius
            );

            moon.localPosition = orbitPosition;
        }
    }
}
