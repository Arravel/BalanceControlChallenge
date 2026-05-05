using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = true; 
    private Rigidbody rb;

    void Start() => rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        if (!canMove) return; 

        float inputX = 0; // Horizontal
        float inputZ = 0; // Vertical

        // Memetakan ulang tombol agar sesuai dengan orientasi map baru
        if (Input.GetKey(KeyCode.W)) inputX = 1;  // W sekarang lurus (sebelumnya D)
        if (Input.GetKey(KeyCode.S)) inputX = -1; // S sekarang mundur
        if (Input.GetKey(KeyCode.A)) inputZ = 1;  // A sekarang kiri
        if (Input.GetKey(KeyCode.D)) inputZ = -1; // D sekarang kanan

        // Kita tukar penempatan variabelnya di Vector3
        // Agar W/S mengisi sumbu yang membuat bola maju sesuai map
        Vector3 movement = new Vector3(inputX, 0.0f, inputZ);
        
        rb.AddForce(movement * speed, ForceMode.Acceleration);
    }
}