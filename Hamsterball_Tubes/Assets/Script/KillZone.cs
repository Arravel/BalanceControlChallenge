using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Fungsi ini terpicu otomatis saat bola masuk ke area transparan
    private void OnTriggerEnter(Collider other)
    {
        // 1. Cek apakah itu Player 1
        BallController p1 = other.GetComponent<BallController>();
        if (p1 != null)
        {
            p1.Respawn();
            Debug.Log("P1 Jatuh, Respawn!");
        }

        // 2. Cek apakah itu Player 2
        BallControllerP2 p2 = other.GetComponent<BallControllerP2>();
        if (p2 != null)
        {
            p2.Respawn();
            Debug.Log("P2 Jatuh, Respawn!");
        }
    }
}