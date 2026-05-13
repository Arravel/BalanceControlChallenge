using UnityEngine;

public class SpinnerObstacle : MonoBehaviour
{
    [Header("Pengaturan Putaran (Spinner)")]
    [Tooltip("Kecepatan dan arah putaran per detik. \n- Horizontal: Isi nilai Y (misal: 0, 100, 0)\n- Vertical: Isi nilai X atau Z (misal: 100, 0, 0)")]
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    void Update()
    {
        // Memutar objek setiap frame berdasarkan rotationSpeed
        // Dikalikan Time.deltaTime agar putaran stabil meskipun FPS naik turun
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
