using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinPanelManager : MonoBehaviour
{
    [Header("UI Panel & Teks")]
    public GameObject winPanel;
    public TextMeshProUGUI winnerText;     // Teks "1P WIN!"
    public TextMeshProUGUI p1ScoreText;    // Teks "1P Score : 07.20"
    public TextMeshProUGUI p2ScoreText;    // Teks "2P Score : 10.08"

    [Header("Pengaturan Scene")]
    public string mainMenuSceneName = "MainMenu";

    // Status apakah player sudah masuk garis finish
    private bool isP1AtFinish = false;
    private bool isP2AtFinish = false;
    private bool gameEnded = false;

    void Start()
    {
        // Pastikan panel disembunyikan saat mulai
        if (winPanel != null) winPanel.SetActive(false);
    }

    void Update()
    {
        // Kalau game udah selesai, nggak usah ngecek tombol P lagi
        if (gameEnded) return;

        // Mengecek apakah ada player di finish DAN menekan tombol 'P'
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Tombol P dipencet! Status - P1 di finish: " + isP1AtFinish + ", P2 di finish: " + isP2AtFinish);
            if (isP1AtFinish || isP2AtFinish)
            {
                ShowWinPanel();
            }
        }
    }

    // Fungsi ini akan dipanggil dari FinishDetector.cs nanti
    public void PlayerReachedFinish(int playerNumber)
    {
        Debug.Log("PlayerReachedFinish dipanggil untuk Player: " + playerNumber);
        if (playerNumber == 1) isP1AtFinish = true;
        if (playerNumber == 2) isP2AtFinish = true;
    }

    private void ShowWinPanel()
    {
        gameEnded = true;
        Time.timeScale = 0f; // Menghentikan game

        if (winPanel != null) winPanel.SetActive(true);

        // Menentukan pemenang
        if (isP1AtFinish && !isP2AtFinish) 
        {
            winnerText.text = "1P WIN!";
        } 
        else if (isP2AtFinish && !isP1AtFinish) 
        {
            winnerText.text = "2P WIN!";
        }
        else if (isP1AtFinish && isP2AtFinish) 
        {
            winnerText.text = "DRAW!"; // Kalau pencet P pas dua-duanya udah masuk finish barengan
        }

        // Mengambil skor dari data yang disave oleh GameTimer.cs
        // Jika player belum finish, kita kasih keterangan "DNF" (Did Not Finish)
        string w1 = isP1AtFinish ? PlayerPrefs.GetString("WaktuP1", "00:00:00") : "DNF";
        string w2 = isP2AtFinish ? PlayerPrefs.GetString("WaktuP2", "00:00:00") : "DNF";

        if (p1ScoreText != null) p1ScoreText.text = "1P Score : " + w1;
        if (p2ScoreText != null) p2ScoreText.text = "2P Score : " + w2;
    }

    // --- FUNGSI UNTUK TOMBOL ---

    public void Btn_MainMenu()
    {
        Time.timeScale = 1f; // Kembalikan waktu normal
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Btn_ChooseLevel()
    {
        // Tombol ini belum dikoding sesuai permintaan (ntar aja)
        Debug.Log("Tombol Choose Level dipencet! (Kodingannya ntar)");
    }
}
