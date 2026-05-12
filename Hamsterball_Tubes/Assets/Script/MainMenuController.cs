using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainButtonsPanel;  // Panel Menu Utama
    public GameObject nameInputPanel;    // Panel Input Nama
    public GameObject levelSelectPanel;  // Panel Pilih Level

    [Header("Name Inputs")]
    public TMP_InputField p1InputField;
    public TMP_InputField p2InputField;

    void Start()
    {
        // Kondisi Awal: Cuma Menu Utama yang idup
        if (mainButtonsPanel != null) mainButtonsPanel.SetActive(true);
        if (nameInputPanel != null) nameInputPanel.SetActive(false);
        if (levelSelectPanel != null) levelSelectPanel.SetActive(false);
    }

    // 1. Ditekan tombol "PLAY GAME" di Menu Utama
    public void BukaInputNama()
    {
        mainButtonsPanel.SetActive(false);
        nameInputPanel.SetActive(true);
    }

    // 2. Ditekan tombol "MULAI/LANJUT" di Panel Input Nama
    public void LanjutPilihLevel()
    {
        // Ambil teks dari input field
        string namaP1 = p1InputField.text;
        string namaP2 = p2InputField.text;

        // Validasi: Kalau kosong, kasih nama default
        if (string.IsNullOrEmpty(namaP1)) namaP1 = "Player 1";
        if (string.IsNullOrEmpty(namaP2)) namaP2 = "Player 2";

        // Simpan ke memori (PlayerPrefs)
        PlayerPrefs.SetString("NamaPemain1", namaP1);
        PlayerPrefs.SetString("NamaPemain2", namaP2);
        PlayerPrefs.Save();

        Debug.Log("Nama Disimpan: " + namaP1 + " vs " + namaP2);

        // Tutup panel nama, buka panel level
        nameInputPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    // 3. Ditekan tombol "LEVEL 1", "LEVEL 2" di Panel Pilih Level
    public void PindahKeLevel(string namaLevel)
    {
        Debug.Log("Pindah ke scene: " + namaLevel);
        SceneManager.LoadScene(namaLevel);
    }

    // Tombol Back (Opsional, kalau lu bikin tombol kembali)
    public void KembaliKeMenuUtama()
    {
        levelSelectPanel.SetActive(false);
        nameInputPanel.SetActive(false);
        mainButtonsPanel.SetActive(true);
    }
}