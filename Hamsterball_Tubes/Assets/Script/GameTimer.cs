using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("UI Timer")]
    public TextMeshProUGUI gameTimerText; 
    public TextMeshProUGUI timerP1Text;   
    public TextMeshProUGUI timerP2Text;   

    [Header("UI Scoreboard")]
    public GameObject panelScoreboard; // Nanti tarik Panel Scoreboard kamu ke sini di Inspector

    private float currentTime;
    public bool isRunning = false;
    private bool p1Done = false;
    private bool p2Done = false;

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            gameTimerText.text = FormatTime(currentTime);
        }
    }

    public void P1Finish()
    {
        if (!p1Done)
        {
            p1Done = true;
            string finalTime = FormatTime(currentTime);
            if (timerP1Text != null) {
                timerP1Text.text = "P1: " + finalTime;
            } else {
                Debug.LogWarning("timerP1Text belum dipasang di Inspector GameTimer!");
            }
            
            // SIMPAN WAKTU P1 UNTUK SCOREBOARD
            PlayerPrefs.SetString("WaktuP1", finalTime);
            PlayerPrefs.Save();
            
            Debug.Log("P1 Finish! Waktu disimpan.");
            CheckStop();
        }
    }

    public void P2Finish()
    {
        if (!p2Done)
        {
            p2Done = true;
            string finalTime = FormatTime(currentTime);
            if (timerP2Text != null) {
                timerP2Text.text = "P2: " + finalTime;
            } else {
                Debug.LogWarning("timerP2Text belum dipasang di Inspector GameTimer!");
            }

            // SIMPAN WAKTU P2 UNTUK SCOREBOARD
            PlayerPrefs.SetString("WaktuP2", finalTime);
            PlayerPrefs.Save();

            Debug.Log("P2 Finish! Waktu disimpan.");
            CheckStop();
        }
    }

    private void CheckStop()
    {
        // Kalau P1 dan P2 sudah finish, hentikan timer utama
        if (p1Done && p2Done) 
        {
            isRunning = false;
            
            // Panggil fungsi ShowScoreboard setelah jeda 1 detik
            if (panelScoreboard != null)
            {
                Invoke("ShowScoreboard", 1f);
            }
        }
    }

    void ShowScoreboard() 
    {
        // Munculkan panel scoreboard di layar
        panelScoreboard.SetActive(true);
    }

    public string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milli = Mathf.FloorToInt((time * 100) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milli);
    }
}