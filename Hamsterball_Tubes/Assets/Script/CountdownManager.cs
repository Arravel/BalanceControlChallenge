using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    [Header("UI Text Hitung Mundur")]
    public TextMeshProUGUI countdownText; // Tarik teks "3" lu ke sini

    [Header("Komponen Game (Wajib Isi)")]
    public GameTimer gameTimerScript;
    public BallController player1;
    public BallControllerP2 player2;

    void Start()
    {
        // 1. Kunci pergerakan & matikan timer pas game baru mulai
        if (player1 != null) player1.canMove = false;
        if (player2 != null) player2.canMove = false;
        if (gameTimerScript != null) gameTimerScript.isRunning = false;

        // 2. Mulai proses hitung mundur
        StartCoroutine(MulaiHitungMundur());
    }

    // Fungsi "Sihir" Coroutine buat bikin jeda waktu
    IEnumerator MulaiHitungMundur()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f); // Tunggu 1 detik

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        // Hilangkan tulisan GO
        countdownText.gameObject.SetActive(false);

        // 3. LEPAS KUNCI! Pemain bisa gerak & Timer jalan
        if (player1 != null) player1.canMove = true;
        if (player2 != null) player2.canMove = true;
        if (gameTimerScript != null) gameTimerScript.isRunning = true;
        
        Debug.Log("BALAPAN DIMULAI!");
    }
}