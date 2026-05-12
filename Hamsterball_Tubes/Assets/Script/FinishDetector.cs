using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    public GameTimer timerScript; 

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