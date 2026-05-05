using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;       // Tarik Bola P1 ke Kamera 1, Bola P2 ke Kamera 2
    
    [Header("Position Settings")]
    public Vector3 offset = new Vector3(0, 5, -7); // Atur jarak aman di sini
    
    // Kita pindah ke LateUpdate agar sinkron dengan pergerakan bola yang sudah di-Interpolate
    void LateUpdate()
    {
        if (target == null) return;

        // Langsung nempel ke posisi target + jarak yang kita tentukan
        transform.position = target.position + offset;

        // Biar kamera selalu melototin bolanya
        transform.LookAt(target);
    }
}