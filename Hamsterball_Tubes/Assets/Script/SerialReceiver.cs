using UnityEngine;

public class SerialReceiver : MonoBehaviour 
{
    public BallController player1; 
    public BallControllerP2 player2; 

    // TAMBAHIN INI BIAR KITA TAU SCRIPTNYA HIDUP
    void Start()
    {
        Debug.Log("SerialReceiver Siap! Nunggu koneksi dari SerialController...");
    }

    void OnConnectionEvent(bool success)
    {
        if (success) Debug.Log("SIP! ESP32 SUDAH NYAMBUNG");
        else Debug.Log("WADUH! KONEKSI GAGAL/PORT SALAH");
    }

    void OnMessageArrived(string msg)
    {
        // (Isi fungsi lu yang lama tetep sama)
        try {
            string[] data = msg.Split(',');
            if (data.Length == 2) {
                float x = float.Parse(data[0], System.Globalization.CultureInfo.InvariantCulture);
                float z = float.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture);
                if(player1 != null) player1.SetExternalInput(x, z);
                if(player2 != null) player2.SetExternalInput(x, z);
            }
        } catch (System.Exception) {}
    }
}