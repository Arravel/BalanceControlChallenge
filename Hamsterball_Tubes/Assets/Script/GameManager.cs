using UnityEngine;
using TMPro; // Pake TMP biar teksnya bagus

public class GameManager : MonoBehaviour
{
    [Header("UI Display Teks di Game Scene")]
    public TextMeshProUGUI namaP1TextTop; // Teks nama P1 di pojok layar game
    public TextMeshProUGUI namaP2TextTop; // Teks nama P2 di pojok layar game

    void Start()
    {
        // Ambil data nama dari PlayerPrefs (data yang disimpan di menu tadi)
        // Kalau ga ketemu, pake default "P1" / "P2"
        string namaP1 = PlayerPrefs.GetString("NamaPemain1", "P1");
        string namaP2 = PlayerPrefs.GetString("NamaPemain2", "P2");

        // Pasang nama ke UI Game saat game dimulai
        if (namaP1TextTop != null) namaP1TextTop.text = namaP1;
        if (namaP2TextTop != null) namaP2TextTop.text = namaP2;

        Debug.Log("Game Mulai dengan nama: " + namaP1 + " vs " + namaP2);
    }
}