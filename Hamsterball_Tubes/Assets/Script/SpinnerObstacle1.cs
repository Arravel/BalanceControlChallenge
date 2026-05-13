using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpinnerObstacle1 : MonoBehaviour
{
    [Header("Pengaturan Putaran")]
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);
    
    [Header("Pengaturan Pukulan")]
    public float dayaPukul = 20f; // Makin gede, makin jauh bolanya mental

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    // FUNGSI BARU: Nembak bola pas ketabrak
    private void OnCollisionEnter(Collision collision)
    {
        // Cek apakah yang ditabrak itu bola (pastikan bola lu dikasih tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Hitung arah pentalan: Menjauh dari tengah baling-baling
                Vector3 arahMental = collision.contacts[0].point - transform.position;
                
                // Tambahin dikit nilai Y biar bolanya mental agak ngangkat ke udara
                arahMental.y = 0.5f; 
                arahMental = arahMental.normalized;

                // Tembak bolanya pakai Impulse (daya ledak instan)
                ballRb.AddForce(arahMental * dayaPukul, ForceMode.Impulse);
                
                Debug.Log("JEDAAAR! Bola dipukul baling-baling!");
            }
        }
    }
}