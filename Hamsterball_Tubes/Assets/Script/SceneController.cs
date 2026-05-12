using UnityEngine;
using UnityEngine.SceneManagement; // WAJIB ADA buat pindah scene

public class SceneController : MonoBehaviour
{
    // Fungsi ini yang bakal dipanggil sama tombol
    public void PindahKeScene(string namaScene)
{
    Debug.Log("TOMBOL DIPENCET! Nama Scene: " + namaScene); // Tambahin ini
    Time.timeScale = 1f;
    SceneManager.LoadScene(namaScene);
}

    // Fungsi buat keluar dari game
    public void KeluarGame()
    {
        Debug.Log("Game Keluar...");
        Application.Quit();
    }
}