using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = true; 
    private Rigidbody rb;
    private Vector3 startPosition; // Simpan posisi awal

    private float externalX = 0;
    private float externalZ = 0;

    // Fungsi untuk menerima input dari ESP32
    public void SetExternalInput(float x, float z)
    {
        externalX = x;
        externalZ = z;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Catat posisi awal bola saat game mulai
        startPosition = transform.position;
    }

    // Fungsi untuk mengembalikan bola ke posisi awal
    public void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;        // Stop meluncur
        rb.angularVelocity = Vector3.zero; // Stop muter
        Debug.Log("Respawn: Bola kembali ke titik awal.");
    }

    // Deteksi jika bola jatuh mengenai area "FallZone"
    private void OnTriggerEnter(Collider other)
    {
        // Pastikan objek di bawah/jurang dikasih Tag "FallZone"
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

        // 2. Gabungkan dengan input Keyboard (W,S,A,D)
        if (Input.GetKey(KeyCode.W)) inputX = 1;  
        if (Input.GetKey(KeyCode.S)) inputX = -1; 
        if (Input.GetKey(KeyCode.A)) inputZ = 1;  
        if (Input.GetKey(KeyCode.D)) inputZ = -1; 

        Vector3 movement = new Vector3(inputX, 0.0f, inputZ);

        // 3. Normalisasi agar kecepatan serong tidak curang
        if (movement.magnitude > 1) 
        {
            movement.Normalize();
        }
        
        rb.AddForce(movement * speed, ForceMode.Acceleration);
    }
}