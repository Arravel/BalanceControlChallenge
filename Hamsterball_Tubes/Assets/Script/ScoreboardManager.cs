using UnityEngine;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    [Header("UI Baris Player 1")]
    public TextMeshProUGUI p1NameText;
    public TextMeshProUGUI p1TimeText;

    [Header("UI Baris Player 2")]
    public TextMeshProUGUI p2NameText;
    public TextMeshProUGUI p2TimeText;

    [Header("UI Baris Player 3")]
    public TextMeshProUGUI p3NameText;
    public TextMeshProUGUI p3TimeText;

    [Header("UI Baris Player 4")]
    public TextMeshProUGUI p4NameText;
    public TextMeshProUGUI p4TimeText;

    // Otomatis dipanggil saat Panel Scoreboard diaktifkan
    void OnEnable()
    {
        TampilkanData();
    }

    public void TampilkanData()
    {
        // 1. Ambil Nama dari PlayerPrefs
        // Kalau datanya nggak ada, dia bakal nampilin teks default (misal: "---" atau "Player 3")
        string nama1 = PlayerPrefs.GetString("NamaPemain1", "Player 1");
        string nama2 = PlayerPrefs.GetString("NamaPemain2", "Player 2");
        string nama3 = PlayerPrefs.GetString("NamaPemain3", "Player 3");
        string nama4 = PlayerPrefs.GetString("NamaPemain4", "Player 4");

        // 2. Ambil Waktu dari PlayerPrefs
        string waktu1 = PlayerPrefs.GetString("WaktuP1", "00:00:00");
        string waktu2 = PlayerPrefs.GetString("WaktuP2", "00:00:00");
        string waktu3 = PlayerPrefs.GetString("WaktuP3", "00:00:00");
        string waktu4 = PlayerPrefs.GetString("WaktuP4", "00:00:00");

        // 3. Masukkan ke Text UI Player 1
        if (p1NameText != null) p1NameText.text = nama1;
        if (p1TimeText != null) p1TimeText.text = waktu1;

        // 4. Masukkan ke Text UI Player 2
        if (p2NameText != null) p2NameText.text = nama2;
        if (p2TimeText != null) p2TimeText.text = waktu2;

        // 5. Masukkan ke Text UI Player 3
        if (p3NameText != null) p3NameText.text = nama3;
        if (p3TimeText != null) p3TimeText.text = waktu3;

        // 6. Masukkan ke Text UI Player 4
        if (p4NameText != null) p4NameText.text = nama4;
        if (p4TimeText != null) p4TimeText.text = waktu4;

        Debug.Log("Scoreboard 4 Baris Berhasil Diupdate!");
    }
}