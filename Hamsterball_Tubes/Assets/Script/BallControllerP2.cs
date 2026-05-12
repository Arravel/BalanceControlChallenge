using UnityEngine;

public class BallControllerP2 : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = true; 
    private Rigidbody rb;
    private Vector3 startPosition; // Simpan posisi awal

    private float externalX = 0;
    private float externalZ = 0;

    // Fungsi untuk menerima input dari ESP32 (lewat SerialReceiver)
    public void SetExternalInput(float x, float z)
    {
        externalX = x;
        externalZ = z;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Catat posisi awal bola P2 saat game mulai
        startPosition = transform.position;
    }

    // Fungsi untuk mengembalikan bola ke posisi awal
    public void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;        
        rb.angularVelocity = Vector3.zero; 
        Debug.Log("P2 Respawn: Kembali ke titik awal.");
    }

    // Deteksi jika bola jatuh mengenai area dengan tag "FallZone"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallZone"))
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return; 

        // 1. Ambil input dari ESP32
        float inputX = externalX; 
        float inputZ = externalZ;

        // 2. Gabungkan dengan input Arrow Keys (Atas, Bawah, Kiri, Kanan)
        if (Input.GetKey(KeyCode.UpArrow))    inputX = 1;  
        if (Input.GetKey(KeyCode.DownArrow))  inputX = -1; 
        if (Input.GetKey(KeyCode.LeftArrow))  inputZ = 1;  
        if (Input.GetKey(KeyCode.RightArrow)) inputZ = -1; 

        Vector3 movement = new Vector3(inputX, 0.0f, inputZ);

        // 3. Normalisasi agar kecepatan diagonal adil dengan P1
        if (movement.magnitude > 1) 
        {
            movement.Normalize();
        }
        
        rb.AddForce(movement * speed, ForceMode.Acceleration);
    }
}