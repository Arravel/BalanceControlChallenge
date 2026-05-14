using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panel UI")]
    [Tooltip("Tarik/Drag GameObject Panel Pause dari Hierarchy ke sini")]
    public GameObject pauseMenuPanel;

    [Header("Pengaturan Scene")]
    [Tooltip("Tulis nama scene Main Menu kamu di sini (harus persis sama besar kecilnya)")]
    public string mainMenuSceneName = "MainMenu";

    private bool isPaused = false;

    void Start()
    {
        // Pastikan saat game mulai, panel pause dalam keadaan mati (hide)
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        
        // Pastikan waktu berjalan normal saat mulai (jaga-jaga kalau sebelumnya kepause)
        Time.timeScale = 1f; 
    }

    void Update()
    {
        // Mengecek apakah tombol ESC ditekan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Kalau sedang pause, maka resume
            }
            else
            {
                PauseGame(); // Kalau sedang main, maka pause
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu (semua fisika & pergerakan berhenti)
    }

    // Fungsi ini bisa dipanggil juga dari Tombol Resume di UI
    public void ResumeGame()
    {
        isPaused = false;
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Menjalankan waktu kembali
    }

    // Fungsi ini dipanggil dari Tombol Restart di UI
    public void RestartGame()
    {
        // PENTING: Kembalikan waktu jadi normal sebelum merestart scene
        Time.timeScale = 1f; 
        
        // Memuat ulang scene yang sedang aktif / dimainkan saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi ini dipanggil dari Tombol Exit ke Main Menu di UI
    public void ExitToMainMenu()
    {
        // PENTING: Kembalikan waktu jadi normal sebelum pindah scene
        Time.timeScale = 1f; 
        
        // Memuat scene menu utama
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
