using UnityEngine;

public class BallControllerP2 : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = true; 
    private Rigidbody rb;

    void Start() => rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        if (!canMove) return; 

        float inputX = 0; // Ini yang bikin lurus di map kamu
        float inputZ = 0; // Ini yang bikin kiri-kanan di map kamu

        // Memetakan ulang tombol Arrow agar sinkron dengan orientasi map
        // Arrow Atas & Bawah mengisi inputX karena sumbu X adalah 'maju' di map kamu
        if (Input.GetKey(KeyCode.UpArrow))    inputX = 1;  // Atas = Maju
        if (Input.GetKey(KeyCode.DownArrow))  inputX = -1; // Bawah = Mundur
        
        // Arrow Kiri & Kanan mengisi inputZ
        if (Input.GetKey(KeyCode.LeftArrow))  inputZ = 1;  // Kiri = Kiri
        if (Input.GetKey(KeyCode.RightArrow)) inputZ = -1; // Kanan = Kanan

        // Masukkan ke Vector3 (X, Y, Z)
        // inputX masuk ke posisi X, inputZ masuk ke posisi Z
        Vector3 movement = new Vector3(inputX, 0.0f, inputZ);
        
        rb.AddForce(movement * speed, ForceMode.Acceleration);
    }
}