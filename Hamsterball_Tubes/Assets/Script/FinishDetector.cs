using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    // Fungsi ini otomatis jalan saat ada objek masuk ke area Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah yang masuk punya script BallController (P1)
        if (other.GetComponent<BallController>() != null)
        {
            other.GetComponent<BallController>().canMove = false;
            Debug.Log("Player 1 Finish!");
        }

        // Cek apakah yang masuk punya script BallControllerP2 (P2)
        if (other.GetComponent<BallControllerP2>() != null)
        {
            other.GetComponent<BallControllerP2>().canMove = false;
            Debug.Log("Player 2 Finish!");
        }
        
        // Opsional: Bikin bola langsung berhenti total (nggak ngglundung lagi)
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}