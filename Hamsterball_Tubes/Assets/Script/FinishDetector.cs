using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    public GameTimer timerScript; 
    public WinPanelManager winPanelManager; // Tambahan untuk deteksi tombol P


    private void OnTriggerEnter(Collider other)
    {
        // Deteksi Player 1
        if (other.GetComponent<BallController>() != null)
        {
            BallController p1 = other.GetComponent<BallController>();
            if (p1.canMove)
            {
                p1.canMove = false;
                timerScript.P1Finish();
                
                if (winPanelManager != null) {
                    winPanelManager.PlayerReachedFinish(1); // Kasih tau P1 udah masuk
                } else {
                    Debug.LogError("WinPanelManager BELUM DIMASUKKAN ke dalam FinishDetector!");
                }
                
                FreezeBola(other.GetComponent<Rigidbody>());
            }
        }

        // Deteksi Player 2
        if (other.GetComponent<BallControllerP2>() != null)
        {
            BallControllerP2 p2 = other.GetComponent<BallControllerP2>();
            if (p2.canMove)
            {
                p2.canMove = false;
                timerScript.P2Finish();

                if (winPanelManager != null) {
                    winPanelManager.PlayerReachedFinish(2); // Kasih tau P2 udah masuk
                } else {
                    Debug.LogError("WinPanelManager BELUM DIMASUKKAN ke dalam FinishDetector!");
                }

                FreezeBola(other.GetComponent<Rigidbody>());
            }
        }
    }

    void FreezeBola(Rigidbody rb)
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}